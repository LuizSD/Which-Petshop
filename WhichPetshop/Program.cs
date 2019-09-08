using System;

namespace WhichPetshop
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Bem vindo ao Qual Petshop!");

			Console.WriteLine();
			Console.WriteLine("Qual a data do banho (dd/mm/yyyy)?");
			var dataBanho = Console.ReadLine();

			DateTime dt;
			while (!DateTime.TryParse(dataBanho, out dt))
			{
				Console.WriteLine();
				Console.WriteLine("Favor informar a data no formato: dd/mm/yyyy!");
				dataBanho = Console.ReadLine();
			}

			Console.WriteLine();
			Console.WriteLine("Quantidade de câes pequenos?");
			var caesPequenos = Console.ReadLine();

			Console.WriteLine();
			Console.WriteLine("Quantidade de câes grandes?");
			var caesGrandes = Console.ReadLine();
			
			Solucao solucao = new Solucao();
			Console.WriteLine();
			Console.WriteLine(solucao.VerificaMelhorCanil(DateTime.Parse(dataBanho), int.Parse(caesPequenos), int.Parse(caesGrandes)));

			Console.WriteLine();
			Console.WriteLine("Pressione qualquer tecla para sair!");
			Console.ReadKey();
		}
	}
}
