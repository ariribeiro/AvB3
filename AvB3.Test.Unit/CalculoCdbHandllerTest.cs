using AvB3.Service.Commands;
using AvB3.Service.Handlers;
using AvB3.Service.Models;

namespace AvB3.Test.Unit
{
	[TestClass]
	public class CalculoCdbHandllerTest
	{
		[TestMethod]
		public void DadoUmCommandValidoDeveCalcularInvestimento()
		{
			var handller = new CalculoCdbHandler();
			var command = new CalculoCdbCommand(20000, 13);
			var result = handller.Handle(command, new CancellationToken());
			CalculoCdbResult? data = result.Result.Data as CalculoCdbResult;
			Assert.IsNotNull(result);
			Assert.AreEqual(true, result.Result.Success);
			Assert.AreEqual(22679.96905856736, data?.ValorBruto);
			Assert.AreEqual(22210.97447331807, data?.ValorLiquido);
			Assert.AreEqual(17.5, data?.ImpostoPct);
			Assert.AreEqual(468.9945852492879, data?.ImpostoValor);
		}

		[TestMethod]
		public void DadoUmCommandInvalidoDeveRetornarMensagemErro()
		{
			var handller = new CalculoCdbHandler();

			var command = new CalculoCdbCommand(20000, 1);
			var result = handller.Handle(command, new CancellationToken());
			Assert.IsNotNull(result);
			Assert.AreEqual(false, result.Result.Success);
		}
	}
}