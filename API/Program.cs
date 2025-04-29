using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Automatically detects the environment and adds the correct settings file
                    var env = context.HostingEnvironment.EnvironmentName;
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                          //.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//using API;

//namespace API
//{
//    public class Program
//    {
//        static string env = "";
//        public static void Main(string[] args)
//        {
//            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//            env = config.GetSection("Env").Value ?? "";
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureAppConfiguration((a, config) =>
//                {
//                    config.AddJsonFile("appsettings.json");
//                    config.AddJsonFile($"appsettings.{env}.json");
//                })
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                    webBuilder.ConfigureKestrel(options =>
//                    {
//                        options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(15);
//                    });
//                });
//    }
//}