using Flunt.Validations;

namespace AvB3.Service.Commands.Contracts
{
	public class CalculoCdbContract<TCommand> : Contract<TCommand> where TCommand : CalculoCdbCommand
	{
		public CalculoCdbContract(TCommand command)
		{
			Requires()
				.IsTrue(command.Prazo > 1, "ValorMenorQueDois", "O prazo precisa ser de pelo menos dois meses");

		}
	}
}
