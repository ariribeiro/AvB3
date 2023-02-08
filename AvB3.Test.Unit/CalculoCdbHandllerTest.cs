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
			var data = (CalculoCdbResult)result.Result.Data;
			Assert.IsNotNull(result);
			Assert.AreEqual(true, result.Result.Success);
			Assert.AreEqual(2470.6252406255517, data.ValorBruto);
			Assert.AreEqual(22470.62524062555, data.ValorBruto + command.ValorMonetario);
			Assert.AreEqual(17.5, data.ImpostoPct);
			Assert.AreEqual(432.3594171094715, data.ImpostoValor);
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