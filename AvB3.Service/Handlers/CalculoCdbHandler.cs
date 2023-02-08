using AvB3.Service.Commands;
using AvB3.Service.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AvB3.Service.Handlers
{
	public class CalculoCdbHandler : IRequestHandler<CalculoCdbCommand, GenericCommandResult>
	{

		private readonly double _cdi = 0.9 / 100;
		private readonly double _tb = 160 / 100;
		private readonly List<double> _meses = new List<double>();
		public CalculoCdbHandler()
		{
		}

		public async Task<GenericCommandResult> Handle(CalculoCdbCommand request, CancellationToken cancellationToken)
		{
			
			try
			{
				request.Validate();
				if(!request.IsValid)
				{
					return new GenericCommandResult(false, "Command inválido", request.Notifications);
				}
				

				for (int i = 0; i < request.Prazo; i++)
				{
					var valorBase = (_meses == null || _meses.Count < 1) ? request.ValorMonetario : _meses[i - 1];
					var result = valorBase * (1 + (_cdi * _tb));
					_meses.Add(result);
				}

				var rendimentoBruto = _meses.Last() - request.ValorMonetario;
				var impostoPct = getImposto(request.Prazo);
				var impostoValor = (impostoPct / 100) * rendimentoBruto;
				var rendimentoLiquido = rendimentoBruto - impostoValor;

				var rendimentoResult = new CalculoCdbResult(rendimentoBruto, rendimentoLiquido, impostoValor, impostoPct);
				var obj = new GenericCommandResult(true, "Calculo realizado", rendimentoResult);
				return await Task.FromResult(obj);
			}
			catch (Exception ex)
			{

				return new GenericCommandResult(false, "Erro ao calcular investimento", null);
			}

		}

		private double getImposto(int prazo)
		{
			if(prazo <= 6)
			{
				return 22.5;
			}else if(prazo > 6 && prazo <= 12) {
				return 20;
			}
			else if (prazo > 12 && prazo <= 24)
			{
				return 17.5;
			}else
			{
				return 15;
			}
		}
	}
}
