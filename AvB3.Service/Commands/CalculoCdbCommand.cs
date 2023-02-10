using AvB3.Service.Commands.Contracts;
using Flunt.Notifications;
using MediatR;

namespace AvB3.Service.Commands
{
	public class CalculoCdbCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
	{
		public Double ValorMonetario { get; private set; }
		public int Prazo { get; private set; }

		public CalculoCdbCommand(double valorMonetario, int prazo)
		{
			ValorMonetario = valorMonetario;
			Prazo = prazo;
		}


		public void Validate()
		{
			AddNotifications(new CalculoCdbContract<CalculoCdbCommand>(this));
		}
	}
}
