using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MVC.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class GeneralController<Entity, Key> : Controller
        where Entity : class
    {
        private readonly HttpClient httpClient;

        public GeneralController()
        {
            URL url = new URL();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(url.GetDevelopment())
            };
        }

        public ActionResult Index()
        {
            return View();
        }

        // HTTP Get
        public async Task<IActionResult> Get()
        {
            using var response = await httpClient.GetAsync(typeof(Entity).Name);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseVM<Entity>>(apiResponse);

            return new JsonResult(result);
        }

        public async Task<IActionResult> Update()
        {
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}
