using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Webnovel
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
            var host = BuildWebHost(args);
            await host.InitAsync();
            host.Run();
            //   CreateWebHostBuilder(args).Build().Run();
            //WebHostExtensions.Run(host);
        }

		public static IWebHost BuildWebHost(string[] args)
		{
			return SentryWebHostBuilderExtensions.UseSentry(WebHostBuilderExtensions.UseStartup<Startup>(WebHost.CreateDefaultBuilder(args)), "https://4e998488c0c640f0909ec970523e1bbb@sentry.io/1530136").Build();
		} 
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
	}
}
