using ElectronNET.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AnimePreview
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
			           .ConfigureWebHostDefaults(webBuilder =>
			            {
				            webBuilder.UseElectron(args);
				            webBuilder.UseStartup<Startup>();
			            });
		}
	}
}