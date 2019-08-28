using Microsoft.Extensions.DependencyInjection;
using PetShop.Consol;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Implementation;
using PetShop.Core.DomainService;
using PetShop.InfraStructure.Data;
using System;

namespace Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.initData();
            ServiceCollection serCollect = new ServiceCollection();
            serCollect.AddScoped<IPetRepository, PetRepository>();
            serCollect.AddScoped<IPetService, PetService>();
            serCollect.AddScoped<IPrinter, Printer>();

            ServiceProvider service = serCollect.BuildServiceProvider();
            IPrinter printer = service.GetRequiredService<IPrinter>();
            printer.startUI();
        }
    }
}
