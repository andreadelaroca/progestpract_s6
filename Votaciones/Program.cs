internal class Program
{
	public static int[] votos = new int[100];
	public static int[] votos_candidatos = new int[5];

	public static void generar_votos()
	{
		Random random = new Random();

		for(int i = 0; i < 100; i++) 
			votos[i] = random.Next(1, 5);
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
			Console.WriteLine($"Candidato N°{i+1}: {votos_candidatos[i]}");
		}
	}

	public static void candidato_ganador()
	{
		int ganador = 1;

		for(int i = 1; i < 5; i++)
		{
			if(votos_candidatos[ganador] < votos_candidatos[i])
				ganador = i;
		}

		Console.WriteLine("-------------------------------------");
		Console.WriteLine($"El ganador de la votación es el candidato N°{ganador+1}");
		Console.WriteLine("-------------------------------------");
	}

	public static void porcentaje_de_votos()
	{
		int[] porcentajes = new int[5];

		for(int i = 0; i < 5; i++)
		{
			// Calcular el porcentaje es inútil jaja, la cantidad de votos de por si es 100
			porcentajes[i] = (int)(((double)votos_candidatos[i] / 100) * 100);
		}

		Console.WriteLine("Porcentaje de votos");
		Console.WriteLine("-------------------------------------");
		for(int i = 0; i < 5; i++)
		{
			Console.WriteLine($"Candidato N°{i+1}: {porcentajes[i]}%");
		}
	}

	public static void Main(string[] args)
	{
		generar_votos();
		Console.WriteLine("-------------------------------------");
		contar_votos();		
		candidato_ganador();
		porcentaje_de_votos();
	}
}
