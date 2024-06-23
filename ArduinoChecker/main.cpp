#include <iostream>
#include <chrono>
#include <thread>
#include "ArduinoChecker.h"

using namespace std;

int main()
{
    wcout << L"Probando conexion en COM5..." << endl;

    auto start = chrono::high_resolution_clock::now();

    while (true) {
        auto elapsed = chrono::high_resolution_clock::now() - start;
        if (chrono::duration_cast<chrono::milliseconds>(elapsed).count() > 3500) {
            break;
        }
        this_thread::sleep_for(chrono::milliseconds(100));
        wcout << L"\rProgreso: " << min(100, static_cast<int>(chrono::duration_cast<chrono::milliseconds>(elapsed).count() / 35.0)) << L"%" << flush;
    }

    ArduinoChecker verificador(L"COM5", CBR_9600);
    
    int resultado = verificador.verificarConexion();

    cout << (resultado == 1 ? "Placa conectada, OK STATUS" : "Placa no conectada, verifica las conexiones") << endl;
    cout << "Presiona cualquier tecla para continuar..." << endl;
    cin.get();

    return resultado;
}
