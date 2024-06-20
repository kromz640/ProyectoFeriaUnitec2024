#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BMP280.h>

// Dirección I2C del sensor BMP280
#define BMP280_ADDRESS 0x76 // Si no funciona, intenta con 0x77

Adafruit_BMP280 bmp; // I2C

void setup() {
  Serial.begin(9600);
  Serial.println(F("Prueba del BMP280"));

  if (!bmp.begin(BMP280_ADDRESS)) {
    Serial.println("No se encontró el sensor BMP280, revisa la conexión!");
    while (1);
  }
}

void loop() {
  Serial.print("Temperatura: ");
  Serial.print(bmp.readTemperature());
  Serial.println(" °C");

  Serial.print("Presión: ");
  Serial.print(bmp.readPressure() / 100.0F);
  Serial.println(" hPa");

  Serial.print("Altitud aproximada: ");
  Serial.print(bmp.readAltitude(1013.25)); // Ajustar el nivel de presión al nivel del mar
  Serial.println(" m");

  Serial.println();
  delay(2000); // Espera de 2 segundos entre lecturas
}
