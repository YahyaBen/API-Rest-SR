using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.Helper;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ClientApi _api = new ClientApi();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<ClientData> clients = new List<ClientData>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("/api/Clients");

            if (res.IsSuccessStatusCode)
            {
                var resultats = res.Content.ReadAsStringAsync().Result;
                clients = JsonConvert.DeserializeObject < List<ClientData>>(resultats);
            }
            return View(clients);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public async Task<IActionResult> Details(int Id)
        {
            var ClientId = new ClientData();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("/api/Clients/"+Id); //Microsoft.AspNet.WebApi.Client 

            if (res.IsSuccessStatusCode)
            {
                var resultats = res.Content.ReadAsStringAsync().Result;
                ClientId = JsonConvert.DeserializeObject<ClientData>(resultats);
            }
            return View(ClientId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientData ClientAdd)
        {
            HttpClient client = _api.initial();
            var ajouter = await client.PostAsJsonAsync<ClientData>("api/clients", ClientAdd); //Microsoft.AspNet.WebApi.Client  
            if (ajouter.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var ClientId = new ClientData();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.DeleteAsync("/api/Clients/" + Id); //Microsoft.AspNet.WebApi.Client 

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
