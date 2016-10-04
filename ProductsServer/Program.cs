using ProductsServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var sh = new ServiceHost(typeof(ProductsService));
            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
}
