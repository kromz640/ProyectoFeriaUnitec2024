#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BMP280.h>

Adafruit_BMP280 bmp;

void setup() {
  Serial.begin(9600);
  if (!bmp.begin(0x76)) {
    Serial.println("No se encontro el sensor BMP280.");
    while (1);
  }
}

void loop() {
  float temperatura = bmp.readTemperature();
  float presion = bmp.readPressure() / 100.0F;  // Convertir Pa a hPa
  float altitud = bmp.readAltitude(1013.25);    // Ajusta al nivel de presion del mar en tu area
  
  // Enviar los datos en el formato correcto
  Serial.print(temperatura);
  Serial.print(",");
  Serial.print(presion);
  Serial.print(",");
  Serial.println(altitud);
  
  delay(2000);  // Esperar 2 segundos antes de la siguiente lectura
}
