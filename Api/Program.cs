using System;
using System.IO;
using log4net;
using log4net.Config;
using Nancy.Hosting.Self;

namespace Api
{
    class Program
    {
        private static ILog _log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {

            XmlConfigurator.Configure(new FileInfo("./log4net.config"));
            _log.Info("Starting");

            using (var host = new NancyHost(new Uri("http://localhost:5000")))
            {
                host.Start();
                _log.Info("Running on http://localhost:5000");
                Console.ReadLine();
            }
        }
    }
}