using System;

class SemanaTemperaturas
{
    public double[] Celsius { get; private set; }
    public double[] Fahrenheit { get; private set; }

    public SemanaTemperaturas()
    {
        Celsius = new double[7];
        Fahrenheit = new double[7];
    }

    public void RegistrarTemperaturas()
    {
        for (int i = 0; i < 7; i++)
        {
            Console.Write($"Temperatura del día {i + 1} en °C: ");
            Celsius[i] = Convert.ToDouble(Console.ReadLine());
            Fahrenheit[i] = ConvertirAFahrenheit(Celsius[i]);
        }
    }

    private double ConvertirAFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }

    public void MostrarTemperaturas()
    {
        Console.WriteLine("\nTemperaturas registradas:");
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine($"Día {i + 1}: {Celsius[i]} °C ↔ {Fahrenheit[i]} °F");
        }
    }

    public void MostrarEstadisticas()
    {
        double suma = 0;
        int diasSobre30 = 0;
        int diasBajoCero = 0;
        int diaMasFrio = 0;
        int diaMasCaluroso = 0;

        for (int i = 0; i < 7; i++)
        {
            suma += Celsius[i];
            if (Celsius[i] > 30) diasSobre30++;
            if (Celsius[i] < 0) diasBajoCero++;
            if (Celsius[i] < Celsius[diaMasFrio]) diaMasFrio = i;
            if (Celsius[i] > Celsius[diaMasCaluroso]) diaMasCaluroso = i;
        }

        double promedio = suma / 7;

        Console.WriteLine($"\nTemperatura promedio: {promedio:F2} °C");
        Console.WriteLine($"Día más frío: Día {diaMasFrio + 1} con {Celsius[diaMasFrio]} °C");
        Console.WriteLine($"Día más caluroso: Día {diaMasCaluroso + 1} con {Celsius[diaMasCaluroso]} °C");
        Console.WriteLine($"Días por encima de 30 °C: {diasSobre30}");
        Console.WriteLine($"Días bajo cero: {diasBajoCero}");
    }
}

class Programa
{
    static void Main()
    {
        SemanaTemperaturas semana = new SemanaTemperaturas();
        semana.RegistrarTemperaturas();
        semana.MostrarTemperaturas();
        semana.MostrarEstadisticas();
    }
}

