using System;
using System.Collections.Generic;
using WhichPetshop.Enums;
using WhichPetshop.Models;
using System.Linq;

namespace WhichPetshop
{
	public class Solucao
	{
		private readonly List<Petshop> _petshops;

		public Solucao()
		{
			_petshops = new List<Petshop>();

			Petshop mcFeliz = new Petshop
			{
				Banhos = new List<Banho>(MontaListaBanho(40.00, (40.00 * 1.2), 20.00, (20.00 * 1.2))),
				Distancia = 2,
				Nome = "Meu Canino Feliz"
			};
			_petshops.Add(mcFeliz);

			Petshop vRex = new Petshop
			{
				Banhos = new List<Banho>(MontaListaBanho(50.00, 55.00, 15.00, 20.00)),
				Distancia = 1.7,
				Nome = "Vai Rex"
			};
			_petshops.Add(vRex);

			Petshop cChawgas = new Petshop
			{
				Banhos = new List<Banho>(MontaListaBanho(45.00, 45.00, 30.00, 30.00)),
				Distancia = 0.8,
				Nome = "ChowChawgas"
			};
			_petshops.Add(cChawgas);
		}

		public string VerificaMelhorCanil(DateTime data, int qtdCaesPequenos, int qtdCaesGrandes)
		{
			string txtRetorno = string.Empty;
			Periodo periodoData = VerificaData(data);

			var banhosMcFeliz = _petshops.Where(w => w.Nome.Contains("Feliz"))
							.Select(s => s.Banhos).FirstOrDefault();

			var banhosRex = _petshops.Where(w => w.Nome.Contains("Rex"))
							.Select(s => s.Banhos).FirstOrDefault();

			var banhosChawgas = _petshops.Where(w => w.Nome.Contains("Chawgas"))
							.Select(s => s.Banhos).FirstOrDefault();

			CanilValorTotal canilMc = new CanilValorTotal
			{
				Distancia = _petshops.FirstOrDefault(f => f.Nome.Contains("Feliz")).Distancia,
				NomeCanil = _petshops.FirstOrDefault(f => f.Nome.Contains("Feliz")).Nome,
				ValorTotal = CauculaValor(qtdCaesPequenos, qtdCaesGrandes, banhosMcFeliz.Where(w => w.Periodo == periodoData).ToList())
			};

			CanilValorTotal canilRex = new CanilValorTotal
			{
				Distancia = _petshops.FirstOrDefault(f => f.Nome.Contains("Rex")).Distancia,
				NomeCanil = _petshops.FirstOrDefault(f => f.Nome.Contains("Rex")).Nome,
				ValorTotal = CauculaValor(qtdCaesPequenos, qtdCaesGrandes, banhosRex.Where(w => w.Periodo == periodoData).ToList())
			};

			CanilValorTotal canilChawgas = new CanilValorTotal
			{
				Distancia = _petshops.FirstOrDefault(f => f.Nome.Contains("Chawgas")).Distancia,
				NomeCanil = _petshops.FirstOrDefault(f => f.Nome.Contains("Chawgas")).Nome,
				ValorTotal = CauculaValor(qtdCaesPequenos, qtdCaesGrandes, banhosChawgas.Where(w => w.Periodo == periodoData).ToList())
			};

			List<CanilValorTotal> canilList = new List<CanilValorTotal> {canilMc, canilRex, canilChawgas};
			txtRetorno = VerificaValor(canilList);

			return txtRetorno;
		}

		private List<Banho> MontaListaBanho(double valorGrandeUtil, double valorGrandeFds, double valorPequenoUtil, double valorPequenoFds)
		{
			List<Banho> banhos = new List<Banho>();

			Banho banhoGrandeDiaUtil = new Banho
			{
				Periodo = Periodo.DiaUtil,
				TamanhoCachorro = TamanhoCachorroEnum.Grande,
				ValorBanho = valorGrandeUtil
			};
			banhos.Add(banhoGrandeDiaUtil);

			Banho banhoGrandeFds = new Banho
			{
				Periodo = Periodo.FinalSemana,
				TamanhoCachorro = TamanhoCachorroEnum.Grande,
				ValorBanho = valorGrandeFds
			};
			banhos.Add(banhoGrandeFds);

			Banho banhoPequenoDiaUtil = new Banho
			{
				Periodo = Periodo.DiaUtil,
				TamanhoCachorro = TamanhoCachorroEnum.Pequeno,
				ValorBanho = valorPequenoUtil
			};
			banhos.Add(banhoPequenoDiaUtil);

			Banho banhoPequenoFds = new Banho
			{
				Periodo = Periodo.FinalSemana,
				TamanhoCachorro = TamanhoCachorroEnum.Pequeno,
				ValorBanho = valorPequenoFds
			};
			banhos.Add(banhoPequenoFds);

			return banhos;
		}

		private Periodo VerificaData(DateTime data)
		{
			bool dataFds = false;

			if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
				dataFds = true;

			return dataFds ? Periodo.FinalSemana : Periodo.DiaUtil;
		}

		private double CauculaValor(int qtdCaesPequenos, int qtdCaesGrandes, List<Banho> banhos)
		{
			var valorBanhoPequeno = banhos.FirstOrDefault(f => f.TamanhoCachorro == TamanhoCachorroEnum.Pequeno).ValorBanho;
			var valorBanhoGrande = banhos.FirstOrDefault(f => f.TamanhoCachorro == TamanhoCachorroEnum.Grande).ValorBanho;

			double valorTotal = (valorBanhoPequeno * qtdCaesPequenos) + (valorBanhoGrande * qtdCaesGrandes);

			return valorTotal;
		}

		private string VerificaValor(List<CanilValorTotal> canilList)
		{
			string resposta = string.Empty;
			double valor = 0;

			var valorMinimo = canilList.Where(w => w.ValorTotal == canilList.Min(m => m.ValorTotal));

			if (valorMinimo.Count() > 1)
			{
				valor = valorMinimo.FirstOrDefault().ValorTotal;
				var canilMaisPerto = canilList.FirstOrDefault(w => w.ValorTotal == valor && w.Distancia == canilList.Min(m => m.Distancia));

				resposta = string.Format("O canil '{0}' é o mais indicado, com um valor total de R${1}.", canilMaisPerto.NomeCanil, canilMaisPerto.ValorTotal.ToString("0.00"));
			}
			else if (valorMinimo.Count() == 1)
			{
				valor = valorMinimo.FirstOrDefault().ValorTotal;
				var canil = canilList.FirstOrDefault(w => w.ValorTotal == valor);

				resposta = string.Format("O canil '{0}' é o mais indicado, com um valor total de R${1}.", canil.NomeCanil, canil.ValorTotal.ToString("0.00"));
			}

			return resposta;
		}
	}
}
