using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvB3.Service.Models
{
	public class CalculoCdbResult
	{
		public double ValorBruto { get; private set; }
		public double ValorLiquido { get; private set; }
		public double ImpostoValor{ get; private set; }
		public double ImpostoPct { get; private set; }
		public CalculoCdbResult(double valorBruto, double valorLiquido, double impostoValor, double impostoPct)
		{
			ValorBruto = valorBruto;
			ValorLiquido = valorLiquido;
			ImpostoValor = impostoValor;
			ImpostoPct = impostoPct;
		}
	}
}
