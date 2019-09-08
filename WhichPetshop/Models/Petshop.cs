using System.Collections.Generic;

namespace WhichPetshop.Models
{
	public class Petshop
	{
		public string Nome { get; set; }
		public double Distancia { get; set; }
		public List<Banho> Banhos { get; set; }
	}
}
