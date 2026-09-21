using StackExchange.Redis;

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
IDatabase db = redis.GetDatabase();

// CREAR
db.HashSet("usuario:1", new HashEntry[]
{
    new HashEntry("nombre", "Axel"),
    new HashEntry("edad", 20),
    new HashEntry("carrera", "Programacion")
});

Console.WriteLine("Usuario creado");

// CONSULTAR
string? nombre = db.HashGet("usuario:1", "nombre");
string? edad = db.HashGet("usuario:1", "edad");
string? carrera = db.HashGet("usuario:1", "carrera");

Console.WriteLine("Nombre: " + nombre);
Console.WriteLine("Edad: " + edad);
Console.WriteLine("Carrera: " + carrera);

// ACTUALIZAR
db.HashSet("usuario:1", "edad", 21);

Console.WriteLine("Edad actualizada: " + db.HashGet("usuario:1", "edad"));

// ELIMINAR
db.KeyDelete("usuario:1");

Console.WriteLine("Usuario eliminado");