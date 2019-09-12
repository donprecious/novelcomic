using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Webnovel
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebHostExtensions.Run(BuildWebHost(args));
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			return SentryWebHostBuilderExtensions.UseSentry(WebHostBuilderExtensions.UseStartup<Startup>(WebHost.CreateDefaultBuilder(args)), "https://4e998488c0c640f0909ec970523e1bbb@sentry.io/1530136").Build();
		}
	}
}
