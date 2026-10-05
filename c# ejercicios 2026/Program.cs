using System;
using System.Globalization;

class Program
{
    static double LeerNumero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string entrada = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
            if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor))
                return valor;
            Console.WriteLine("Valor inválido. Intente de nuevo.");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        double a = LeerNumero("Ingrese el primer valor: ");
        double b = LeerNumero("Ingrese el segundo valor: ");

        Console.WriteLine();
        Console.WriteLine($"Suma:           {a} + {b} = {a + b}");
        Console.WriteLine($"Resta:          {a} - {b} = {a - b}");
        Console.WriteLine($"Multiplicación: {a} * {b} = {a * b}");

        if (b == 0)
            Console.WriteLine("División:       No se puede dividir entre cero.");
        else
            Console.WriteLine($"División:       {a} / {b} = {a / b}");

        if (a < 0)
            Console.WriteLine($"Raíz cuadrada de {a}: no existe en los números reales.");
        else
            Console.WriteLine($"Raíz cuadrada de {a}: {Math.Sqrt(a)}");

        if (b < 0)
            Console.WriteLine($"Raíz cuadrada de {b}: no existe en los números reales.");
        else
            Console.WriteLine($"Raíz cuadrada de {b}: {Math.Sqrt(b)}");

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}
