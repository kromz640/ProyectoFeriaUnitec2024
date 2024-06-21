#ifndef ARDUINOCHECKER_H
#define ARDUINOCHECKER_H

#include <windows.h>
#include <string>

class ArduinoChecker
{
public:
    ArduinoChecker(const std::wstring& puertoCom, DWORD velocidadBaudios);
    ~ArduinoChecker();

    int verificarConexion();

private:
    HANDLE hSerial;
    std::wstring puertoCom;
    DWORD velocidadBaudios;

    bool configurarPuertoSerie();
    bool enviarComando(const std::string& comando);
    bool leerRespuesta(char* respuesta, DWORD longitudMaxima, DWORD& bytesLeidos);
    void cerrarPuerto();
};

#endif // ARDUINOCHECKER_H
#pragma once
