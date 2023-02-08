using AvB3.Service.Commands.Contracts;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
