#include <iostream>
#include <windows.h>
#include <mysql.h>
#include <vector>
#include <string>

void ErrorHandler(const char* functionName) {
    LPVOID lpMsgBuf;
    LPVOID lpDisplayBuf;
    DWORD dw = GetLastError();

    FormatMessageA(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL,
        dw,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPSTR)&lpMsgBuf,
        0, NULL);

    size_t displayBufSize = strlen((const char*)lpMsgBuf) + strlen(functionName) + 40;
    lpDisplayBuf = (LPVOID)LocalAlloc(LMEM_ZEROINIT, displayBufSize * sizeof(char));
    snprintf((char*)lpDisplayBuf, displayBufSize, "%s failed with error %d: %s", functionName, dw, lpMsgBuf);
    MessageBoxA(NULL, (LPCSTR)lpDisplayBuf, "Error", MB_OK);

    LocalFree(lpMsgBuf);
    LocalFree(lpDisplayBuf);
    ExitProcess(dw);
}

void InsertDataIntoDatabase(MYSQL* conn, float temperatura, float presion, float altitud) {
    const char* query = "INSERT INTO tbllecturas (fecha_hora, temperatura, presion, altitud) VALUES (NOW(), ?, ?, ?)";
    MYSQL_STMT* stmt = mysql_stmt_init(conn);
    if (!stmt) {
        std::cerr << "mysql_stmt_init() failed" << std::endl;
        return;
    }

    if (mysql_stmt_prepare(stmt, query, strlen(query))) {
        std::cerr << "mysql_stmt_prepare() failed: " << mysql_stmt_error(stmt) << std::endl;
        mysql_stmt_close(stmt);
        return;
    }

    MYSQL_BIND bind[3];
    memset(bind, 0, sizeof(bind));

    bind[0].buffer_type = MYSQL_TYPE_FLOAT;
    bind[0].buffer = (char*)&temperatura;
    bind[0].is_null = 0;
    bind[0].length = 0;

    bind[1].buffer_type = MYSQL_TYPE_FLOAT;
    bind[1].buffer = (char*)&presion;
    bind[1].is_null = 0;
    bind[1].length = 0;

    bind[2].buffer_type = MYSQL_TYPE_FLOAT;
    bind[2].buffer = (char*)&altitud;
    bind[2].is_null = 0;
    bind[2].length = 0;

    if (mysql_stmt_bind_param(stmt, bind)) {
        std::cerr << "mysql_stmt_bind_param() failed: " << mysql_stmt_error(stmt) << std::endl;
        mysql_stmt_close(stmt);
        return;
    }

    if (mysql_stmt_execute(stmt)) {
        std::cerr << "mysql_stmt_execute() failed: " << mysql_stmt_error(stmt) << std::endl;
    }
    else {
        std::cout << "Data inserted successfully." << std::endl;
    }

    mysql_stmt_close(stmt);
}

int main() {
    MYSQL* conn;
    conn = mysql_init(NULL);

    if (conn == NULL) {
        std::cerr << "mysql_init() failed" << std::endl;
        return EXIT_FAILURE;
    }

    if (mysql_real_connect(conn, "localhost", "root", "passwd", "webAppClima", 3306, NULL, 0) == NULL) {
        std::cerr << "mysql_real_connect() failed: " << mysql_error(conn) << std::endl;
        mysql_close(conn);
        return EXIT_FAILURE;
    }

    HANDLE hSerial;
    DCB dcbSerialParams = { 0 };
    COMMTIMEOUTS timeouts = { 0 };
    DWORD bytesRead = 0;
    char buffer[1024] = { 0 };

    hSerial = CreateFileA("\\\\.\\COM5", GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);
    if (hSerial == INVALID_HANDLE_VALUE) {
        ErrorHandler("CreateFile");
    }

    dcbSerialParams.DCBlength = sizeof(dcbSerialParams);
    if (!GetCommState(hSerial, &dcbSerialParams)) {
        ErrorHandler("GetCommState");
    }

    dcbSerialParams.BaudRate = CBR_9600;
    dcbSerialParams.ByteSize = 8;
    dcbSerialParams.StopBits = ONESTOPBIT;
    dcbSerialParams.Parity = NOPARITY;

    if (!SetCommState(hSerial, &dcbSerialParams)) {
        ErrorHandler("SetCommState");
    }

    timeouts.ReadIntervalTimeout = 50;
    timeouts.ReadTotalTimeoutConstant = 50;
    timeouts.ReadTotalTimeoutMultiplier = 10;
    timeouts.WriteTotalTimeoutConstant = 50;
    timeouts.WriteTotalTimeoutMultiplier = 10;

    if (!SetCommTimeouts(hSerial, &timeouts)) {
        ErrorHandler("SetCommTimeouts");
    }

    std::cout << "Leyendo datos del sensor..." << std::endl;
    while (true) {
        if (!ReadFile(hSerial, buffer, sizeof(buffer) - 1, &bytesRead, NULL)) {
            ErrorHandler("ReadFile");
        }

        buffer[bytesRead] = '\0';
        std::cout << buffer << std::endl;

        // Procesar datos y guardarlos en la base de datos
        std::string data(buffer);
        size_t pos = 0;
        std::string token;
        std::vector<std::string> sensorData;
        while ((pos = data.find(',')) != std::string::npos) {
            token = data.substr(0, pos);
            sensorData.push_back(token);
            data.erase(0, pos + 1);
        }
        sensorData.push_back(data);  // Add the last element

        if (sensorData.size() == 3) {
            try {
                float temperatura = std::stof(sensorData[0]);
                float presion = std::stof(sensorData[1]);
                float altitud = std::stof(sensorData[2]);

                InsertDataIntoDatabase(conn, temperatura, presion, altitud);
            }
            catch (const std::exception& e) {
                std::cerr << "Error parsing sensor data: " << e.what() << std::endl;
            }
        }
        Sleep(50); // Esperar 50 milisegundos antes de leer de nuevo
    }

    CloseHandle(hSerial);
    mysql_close(conn);
    return 0;
}
