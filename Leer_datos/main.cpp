#include <iostream>
#include "SensorBMP280.h"

using namespace std;

void mostrarMenu() {
    cout << "Menu:" << endl;
    cout << "1. Iniciar Lectura" << endl;
    cout << "2. Detener Lectura" << endl;
    cout << "3. Salir" << endl;
}

int main() {
    try {
        SensorBMP280 sensor("COM5", 9600);

        if (!sensor.autenticarAdmin()) {
            cerr << "Autenticacion fallida. Saliendo del programa." << endl;
            return 1;
        }

        int opcion;
        while (true) {
            mostrarMenu();
            cin >> opcion;

            switch (opcion) {
                case 1:
                    sensor.iniciarLectura();
                    break;
                case 2:
                    sensor.detenerLecturaDatos();
                    break;
                case 3:
                    sensor.detenerLecturaDatos();
                    return 0;
                default:
                    cerr << "Opcion invalida. Intente de nuevo." << endl;
            }
        }
    } catch (exception &e) {
        cerr << "Error: " << e.what() << endl;
    }

    return 0;
}
