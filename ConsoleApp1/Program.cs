using StackExchange.Redis;
using System;

// 1. Conexión a Redis
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
    "100.69.194.69:6379,password=ABC12345_"
);

IDatabase db = redis.GetDatabase();


// ==========================
// AGREGAR DATOS
// ==========================

// Nombres
db.ListRightPush("usuario:1:nombre", "fany");
db.ListRightPush("usuario:1:nombre", "jesus");

// Edades
db.ListRightPush("usuario:1:edad", 19);
db.ListRightPush("usuario:1:edad", 5);

// Carreras
db.ListRightPush("usuario:1:carrera", "Informatica");
db.ListRightPush("usuario:1:carrera", "conta");

Console.WriteLine("Datos agregados exitosamente.");


// ==========================
// CONSULTAR NOMBRES
// ==========================

Console.WriteLine("\nNOMBRES:");

RedisValue[] nombres = db.ListRange("usuario:1:nombre");

foreach (RedisValue nombre in nombres)
{
    Console.WriteLine("- " + nombre);
}


// ==========================
// CONSULTAR EDADES
// ==========================

Console.WriteLine("\nEDADES:");

RedisValue[] edades = db.ListRange("usuario:1:edad");

foreach (RedisValue edad in edades)
{
    Console.WriteLine("- " + edad);
}


// ==========================
// CONSULTAR CARRERAS
// ==========================

Console.WriteLine("\nCARRERAS:");

RedisValue[] carreras = db.ListRange("usuario:1:carrera");

foreach (RedisValue carrera in carreras)
{
    Console.WriteLine("- " + carrera);
}