#ifndef SENSORBMP280_H
#define SENSORBMP280_H

#include <mysql_driver.h>
#include <mysql_connection.h>
#include <cppconn/driver.h>
#include <cppconn/exception.h>
#include <cppconn/prepared_statement.h>
#include <string>
#include <thread>
#include <atomic>

class SensorBMP280 {
private:
    sql::mysql::MySQL_Driver *driver;
    sql::Connection *con;
    sql::PreparedStatement *pstmt;
    std::string puerto;
    int baudios;
    std::atomic<bool> detenerLectura;
    std::thread hiloLectura;

public:
    SensorBMP280(std::string puerto, int baudios);
    ~SensorBMP280();
    void conectarBaseDatos();
    void iniciarLectura();
    void detenerLecturaDatos();
    void leerDatosArduino();
    void enviarDatos(float temperatura, float presion, float altitud);
    bool autenticarAdmin();
};

#endif
