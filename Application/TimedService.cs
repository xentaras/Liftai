using Application.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class TimedService : IHostedService, IDisposable
	{
		Timer m_Timer;
		ILiftuValdymoPultas m_ValdymoPultas;

		public TimedService(ILiftuValdymoPultas valdymoPultas)
		{
			m_ValdymoPultas = valdymoPultas;
		}

		public Task StartAsync(CancellationToken stoppingToken)
		{
			m_Timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
			return Task.CompletedTask;
		}

		private void DoWork(object state)
		{
			m_ValdymoPultas.Tikas();
		}

		public Task StopAsync(CancellationToken stoppingToken)
		{
			m_Timer?.Change(Timeout.Infinite, 0);
			return Task.CompletedTask;
		}

		public void Dispose() => m_Timer?.Dispose();
	}
}
