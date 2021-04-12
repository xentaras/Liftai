using Application;
using Microsoft.Extensions.Options;
using System;

namespace Testai
{
    public static class MockOptions
	{
		public static IOptions<T> GetOptions<T>()
			where T : class, new()
		{
			if (typeof(T) == typeof(PastatoKofiguracija))
			{
				return (IOptions<T>)Options.Create(new PastatoKofiguracija
				{
					Aukstai = 10,
					Liftai = 2
				});
			}

			throw new Exception("Nera tokiu nustatymu");
		}
	}
}
