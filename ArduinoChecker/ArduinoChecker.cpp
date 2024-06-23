#include "ArduinoChecker.h"
#include <iostream>

using namespace std;

ArduinoChecker::ArduinoChecker(const wstring& puertoCom, DWORD velocidadBaudios)
    : puertoCom(puertoCom), velocidadBaudios(velocidadBaudios), hSerial(INVALID_HANDLE_VALUE)
{
}

ArduinoChecker::~ArduinoChecker()
{
    cerrarPuerto();
}

int ArduinoChecker::verificarConexion()
{
    hSerial = CreateFile(puertoCom.c_str(), GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);

    if (hSerial == INVALID_HANDLE_VALUE) {
        cerr << "Error al abrir el puerto " << string(puertoCom.begin(), puertoCom.end()) << ".\n";
        return 0; 
    }

    if (!configurarPuertoSerie()) {
        cerrarPuerto();
        return 0; 
    }

    const string comando = "GET_MODEL\n";
    if (!enviarComando(comando)) {
        cerrarPuerto();
        return 0; 
    }

    char respuesta[100];
    DWORD bytesLeidos;
    if (!leerRespuesta(respuesta, sizeof(respuesta) - 1, bytesLeidos)) {
        cerrarPuerto();
        return 0; 
    }

    respuesta[bytesLeidos] = '\0'; 

    cout << "Placa conectada, modelo: " << respuesta << endl;

    cerrarPuerto();
    return 1; 
}

bool ArduinoChecker::configurarPuertoSerie()
{
    DCB dcbSerialParams = { 0 };
    dcbSerialParams.DCBlength = sizeof(dcbSerialParams);

    if (!GetCommState(hSerial, &dcbSerialParams)) {
        cerr << "Error al obtener el estado del puerto.\n";
        return false;
    }

    dcbSerialParams.BaudRate = velocidadBaudios;
    dcbSerialParams.ByteSize = 8;
    dcbSerialParams.StopBits = ONESTOPBIT;
    dcbSerialParams.Parity = NOPARITY;

    if (!SetCommState(hSerial, &dcbSerialParams)) {
        cerr << "Error al configurar el puerto serie.\n";
        return false;
    }

    COMMTIMEOUTS timeouts = { 0 };
    timeouts.ReadIntervalTimeout = 50;
    timeouts.ReadTotalTimeoutConstant = 50;
    timeouts.ReadTotalTimeoutMultiplier = 10;
    timeouts.WriteTotalTimeoutConstant = 50;
    timeouts.WriteTotalTimeoutMultiplier = 10;

    if (!SetCommTimeouts(hSerial, &timeouts)) {
        cerr << "Error al configurar los tiempos de espera.\n";
        return false;
    }

    return true;
}

bool ArduinoChecker::enviarComando(const string& comando)
{
    DWORD bytesEscritos;
    return WriteFile(hSerial, comando.c_str(), comando.length(), &bytesEscritos, NULL)
        ? true : (cerr << "Error al enviar el comando.\n", false);
}

bool ArduinoChecker::leerRespuesta(char* respuesta, DWORD longitudMaxima, DWORD& bytesLeidos)
{
    return ReadFile(hSerial, respuesta, longitudMaxima, &bytesLeidos, NULL)
        ? true : (cerr << "Error al leer la respuesta.\n", false);
}

void ArduinoChecker::cerrarPuerto()
{
    if (hSerial != INVALID_HANDLE_VALUE) {
        CloseHandle(hSerial);
        hSerial = INVALID_HANDLE_VALUE;
    }
}
