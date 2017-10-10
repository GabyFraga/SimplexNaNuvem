using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimplexPatGaby
{
    /// <summary>
    /// Constroi e inicializa o webservice. Estruturas geradas pelo projeto do VisualStudio
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Executa o webservice atravez de um metodo run
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Constroi o webservice.
        /// </summary>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
