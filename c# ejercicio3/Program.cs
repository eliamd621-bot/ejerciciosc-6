using System;
using System.Collections.Generic;
using System.Linq;

class Estudiante
{
    public string Nombre = "";
    public string Apellido = "";
    public int[] Notas = new int[4];
    public double Promedio => (Notas[0] + Notas[1] + Notas[2] + Notas[3]) / 4.0;

    // Primer apellido (por si se ingresan dos apellidos)
    public string PrimerApellido => Apellido.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

    public string Literal
    {
        get
        {
            double p = Promedio;
            if (p >= 90) return "A";
            if (p >= 80) return "B";
            if (p >= 70) return "C";
            return "F"; // Reprobado
        }
    }
}

class Program
{
    static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = (Console.ReadLine() ?? "").Trim();
            if (texto.Length > 0) return texto;
            Console.WriteLine("Este campo no puede estar vacío.");
        }
    }

    static int LeerNota(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int nota) && nota >= 0 && nota <= 100)
                return nota;
            Console.WriteLine("Nota inválida. Debe ser un número entre 0 y 100.");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var estudiantes = new List<Estudiante>();
        string continuar;

        do
        {
            var e = new Estudiante();
            e.Nombre = LeerTexto("Nombre: ");
            e.Apellido = LeerTexto("Apellido: ");
            for (int i = 0; i < 4; i++)
                e.Notas[i] = LeerNota($"Nota{i + 1}: ");
            estudiantes.Add(e);

            Console.Write("¿Desea ingresar otro estudiante? (S/N): ");
            continuar = (Console.ReadLine() ?? "").Trim().ToUpper();
            Console.WriteLine();
        } while (continuar == "S");

        // Ordenado por el primer apellido
        var ordenados = estudiantes
            .OrderBy(e => e.PrimerApellido, StringComparer.CurrentCultureIgnoreCase)
            .ThenBy(e => e.Nombre, StringComparer.CurrentCultureIgnoreCase)
            .ToList();

        string linea = new string('=', 75);
        Console.WriteLine("Colegio Dios es bueno.");
        Console.WriteLine("Calificaciones del cuatrimestre");
        Console.WriteLine(linea);
        Console.WriteLine($"{"Nombre",-15}{"Apellido",-15}{"Nota1",6}{"Nota2",6}{"Nota3",6}{"Nota4",6}{"Promedio",10}{"Literal",8}");
        Console.WriteLine(linea);

        foreach (var e in ordenados)
        {
            Console.WriteLine($"{e.Nombre,-15}{e.Apellido,-15}{e.Notas[0],6}{e.Notas[1],6}{e.Notas[2],6}{e.Notas[3],6}{e.Promedio,10:0.##}{e.Literal,8}");
        }

        Console.WriteLine(linea);
        Console.WriteLine($"Estudiantes en A:          {ordenados.Count(e => e.Literal == "A")}");
        Console.WriteLine($"Estudiantes en B:          {ordenados.Count(e => e.Literal == "B")}");
        Console.WriteLine($"Estudiantes en C:          {ordenados.Count(e => e.Literal == "C")}");
        Console.WriteLine($"Estudiantes en Reprobados: {ordenados.Count(e => e.Literal == "F")}");

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
