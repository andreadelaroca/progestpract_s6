using System.Runtime.InteropServices;

internal class Program
{
	public static int[] votos = new int[100];
	public static int[] votos_candidatos = new int[5];

	private static string NombreCandidato(int i) => $"Candidato N°{i + 1}";

	public static void generar_votos()
	{
		Random random = new Random();

		for(int i = 0; i < 100; i++) 
			votos[i] = random.Next(0, 5);
	}

	public static void contar_votos()
	{
		for(int i = 0; i < 100; i++)
		{
			votos_candidatos[votos[i]]++;
		}
		
		Console.WriteLine("Cantidad de votos");
		Console.WriteLine("-------------------------------------");

		for(int i = 0; i < 5; i++)
		{
			Console.WriteLine($"{NombreCandidato(i)}: {votos_candidatos[i]}");
		}
	}

	public static void candidato_ganador()
	{
		// Encontrar el máximo de votos
		int max = votos_candidatos[0];
		for (int i = 1; i < 5; i++)
		{
			if (votos_candidatos[i] > max)
				max = votos_candidatos[i];
		}

		// Buscar y comparar candidatos con votos máximos
		int[] ganadores = new int[5];
		int cantGanadores = 0;
		for (int i = 0; i < 5; i++)
		{
			if (votos_candidatos[i] == max)
			{
				ganadores[cantGanadores] = i;
				cantGanadores++;
			}
		}

		Console.WriteLine("-------------------------------------");
		if (cantGanadores == 1)
		{
			Console.WriteLine($"El ganador es el {NombreCandidato(ganadores[0])} con {max} votos.");
		}
		else
		{
			string listado = "";
			for (int i = 0; i < cantGanadores; i++)
			{
				string nombre = NombreCandidato(ganadores[i]);
				if (i == 0) listado = nombre;
				else if (i == cantGanadores - 1) listado += " y " + nombre;
				else listado += ", " + nombre;
			}
			Console.WriteLine("Empate entre los ganadores: " + listado + $" con {max} votos cada uno.");
		}
		Console.WriteLine("-------------------------------------");
	}

	public static void porcentaje_de_votos()
	{
		int[] porcentajes = new int[5];

		for(int i = 0; i < 5; i++)
		{
			// Calcular el porcentaje en el ejercicio es inútil si la cantidad de votos es 100
			porcentajes[i] = (int)(((double)votos_candidatos[i] / 100) * 100);
		}

		Console.WriteLine("Porcentaje de votos");
		Console.WriteLine("-------------------------------------");
		for(int i = 0; i < 5; i++)
		{
			Console.WriteLine($"{NombreCandidato(i)}: {porcentajes[i]}%");
		}
	}

	public static void buscar_empate()
	{
		int empates = 0;

		for (int i = 0; i < 5; i++)
		{
			for (int j = i + 1; j < 5; j++)
			{
				if (votos_candidatos[i] == votos_candidatos[j])
				{
					Console.WriteLine($"Hay un empate entre {NombreCandidato(i)} y {NombreCandidato(j)}.");
					empates++;
				}
			}
		}
		if (empates == 0)
		{
			Console.WriteLine("No hay empates.");
		}
		else
		{
			Console.WriteLine($"En total, hay {empates} empate(s).");
		}
	}

	public static void Main(string[] args)
	{
		generar_votos();
		Console.WriteLine("-------------------------------------");
		contar_votos();
		candidato_ganador();
		porcentaje_de_votos();
		buscar_empate();
	}
}
