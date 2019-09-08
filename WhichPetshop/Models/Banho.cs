using WhichPetshop.Enums;

namespace WhichPetshop.Models
{
	public class Banho
	{
		public TamanhoCachorroEnum TamanhoCachorro { get; set; }
		public Periodo Periodo { get; set; }
		public double ValorBanho { get; set; }
	}
}
