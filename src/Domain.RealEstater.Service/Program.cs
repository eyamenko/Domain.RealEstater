using ServiceNetCore.Contracts;

namespace Domain.RealEstater.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BuildService(args).Run();
        }

        private static IService BuildService(string[] args)
        {
            return ServiceNetCore.Service.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}