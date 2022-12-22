using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MvcClient.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace MvcClient.Controllers
{
    public class SporcularController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("https://localhost:44332/api/Sporcular").Result;
            List<Sporcular> Sporculars = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Sporculars = JsonConvert.DeserializeObject<List<Sporcular>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(Sporculars);
        }
        public IActionResult Add()
        {

            return View(new Sporcular());
        }
        [HttpPost]
        public IActionResult Add(Sporcular Sporcular)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(Sporcular), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PostAsync("https://localhost:44332/api/Sporcular", content).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ekleme İşlemi Başarısız");
            return View();
        }
        public IActionResult Edit(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync($"https://localhost:44332/api/Sporcular/{id}").Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var sporcular = JsonConvert.DeserializeObject<Sporcular>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(sporcular);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(Sporcular Sporcular)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(Sporcular), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PutAsync($"https://localhost:44332/api/Sporcular/{Sporcular.Id}", content).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"https://localhost:44332/api/Sporcular/{id}").Result;
            return RedirectToAction("Index");

        }

    }
}
