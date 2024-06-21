#include "SensorBMP280.h"
#include <iostream>
#include <fstream>
#include <windows.h>

using namespace sql;
using namespace std;

SensorBMP280::SensorBMP280(string puerto, int baudios) {
    this->puerto = puerto;
    this->baudios = baudios;
    driver = mysql::get_mysql_driver_instance();
    detenerLectura = false;
    conectarBaseDatos();
}

SensorBMP280::~SensorBMP280() {
    if (con) {
        delete con;
    }
    if (hiloLectura.joinable()) {
        hiloLectura.join();
    }
}

void SensorBMP280::conectarBaseDatos() {
    try {
        con = driver->connect("tcp://localhost:3306", "root", "passwd");
        con->setSchema("webAppClima");
    } catch (SQLException &e) {
        cerr << "Error conectando a la base de datos: " << e.what() << endl;
        con = nullptr;
    }
}

bool SensorBMP280::autenticarAdmin() {
    ifstream archivo("pwdb.txt");
    string passwd;
    if (archivo.is_open()) {
        getline(archivo, passwd);
        archivo.close();
        if (passwd == "root") {
            return true;
        }
    }
    if (archivo.is_open()) {
        archivo.close();
    }
    return false;
}

void SensorBMP280::iniciarLectura() {
    detenerLectura = false;
    hiloLectura = std::thread(&SensorBMP280::leerDatosArduino, this);
}

void SensorBMP280::detenerLecturaDatos() {
    detenerLectura = true;
    if (hiloLectura.joinable()) {
        hiloLectura.join();
    }
}

void SensorBMP280::leerDatosArduino() {
    HANDLE hSerial;
    DCB dcbSerialParams = { 0 };
    COMMTIMEOUTS timeouts = { 0 };

    hSerial = CreateFile(puerto.c_str(), GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
    if (hSerial == INVALID_HANDLE_VALUE) {
        cerr << "Error abriendo el puerto serial" << endl;
        return;
    }

    dcbSerialParams.DCBlength = sizeof(dcbSerialParams);
    if (!GetCommState(hSerial, &dcbSerialParams)) {
        cerr << "Error obteniendo estado del puerto serial" << endl;
        CloseHandle(hSerial);
        return;
    }

    dcbSerialParams.BaudRate = baudios;
    dcbSerialParams.ByteSize = 8;
    dcbSerialParams.StopBits = ONESTOPBIT;
    dcbSerialParams.Parity = NOPARITY;

    if (!SetCommState(hSerial, &dcbSerialParams)) {
        cerr << "Error configurando el puerto serial" << endl;
        CloseHandle(hSerial);
        return;
    }

    timeouts.ReadIntervalTimeout = 50;
    timeouts.ReadTotalTimeoutConstant = 50;
    timeouts.ReadTotalTimeoutMultiplier = 10;
    timeouts.WriteTotalTimeoutConstant = 50;
    timeouts.WriteTotalTimeoutMultiplier = 10;

    if (!SetCommTimeouts(hSerial, &timeouts)) {
        cerr << "Error configurando los timeouts del puerto serial" << endl;
        CloseHandle(hSerial);
        return;
    }

    char szBuff[25] = { 0 };
    DWORD dwBytesRead = 0;
    while (!detenerLectura) {
        if (!ReadFile(hSerial, szBuff, 24, &dwBytesRead, NULL)) {
            cerr << "Error leyendo del puerto serial" << endl;
        } else {
            // PARSEAR LOS DATOS LEIDOS DEL PUERTO SERIAL
            char* token = strtok(szBuff, ",");
            if (token != nullptr) {
                float temperatura = atof(token);
                token = strtok(NULL, ",");
                if (token != nullptr) {
                    float presion = atof(token);
                    token = strtok(NULL, ",");
                    if (token != nullptr) {
                        float altitud = atof(token);

                        enviarDatos(temperatura, presion, altitud);
                    }
                }
            }
        }
        Sleep(2000); // ESPERAR 2 SEGUNDOS ANTES DE LA SIGUIENTE LECTURA
    }

    CloseHandle(hSerial);
}

void SensorBMP280::enviarDatos(float temperatura, float presion, float altitud) {
    try {
        if (con == nullptr) {
            conectarBaseDatos();
        }
        pstmt = con->prepareStatement("INSERT INTO tblLecturas (fecha_hora, temperatura, presion, altitud) VALUES (NOW(), ?, ?, ?)");
        pstmt->setDouble(1, temperatura);
        pstmt->setDouble(2, presion);
        pstmt->setDouble(3, altitud);
        pstmt->executeUpdate();
        delete pstmt;
        cout << "Datos enviados a la base de datos." << endl;
    } catch (SQLException &e) {
        cerr << "Error enviando datos a la base de datos: " << e.what() << endl;
    }
}
