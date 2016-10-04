using Microsoft.ServiceBus;
using ProductsPortal.Models;
using ProductsServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace ProductsPortal.Controllers
{
    public class HomeController : Controller
    {
        static ChannelFactory<IProductsChannel> channelFactory;

        static HomeController()
        {
            // Create shared access signature token credentials for authentication.
            channelFactory = new ChannelFactory<IProductsChannel>(new NetTcpRelayBinding(),
                            "sb://thqnhat.servicebus.windows.net/products");

            channelFactory.Endpoint.EndpointBehaviors.Add(new TransportClientEndpointBehavior {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "15xAXY/6jEvgiSYQD5p51JJM7T9BN3j0CWUZQUlxIR0=")
            });
        }

        public ActionResult Index(string Identifier, string ProductName)
        {
            //var products = new List<Product>
            //    {new Product {Id = Identifier, Name = ProductName}};
            //return View(products);

            // Return a view of the products inventory.
            using (IProductsChannel channel = channelFactory.CreateChannel())
            {
                return View(from prod in channel.GetProducts()
                            select new Product { Id = prod.Id, Name = prod.Name, Quantity = prod.Quantity });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}