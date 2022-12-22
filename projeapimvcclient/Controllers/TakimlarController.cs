using Microsoft.AspNetCore.Mvc;
using MvcClient.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace MvcClient.Controllers
{
    public class TakimlarController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("https://localhost:44332/api/Takimlar").Result;
            List<Takimlar> Takimlars = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Takimlars = JsonConvert.DeserializeObject<List<Takimlar>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(Takimlars);
        }
        public IActionResult Add()
        {

            return View(new Takimlar());
        }
        [HttpPost]
        public IActionResult Add(Takimlar Takimlar)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(Takimlar), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PostAsync("https://localhost:44332/api/Takimlar", content).Result;
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
            var responseMessage = httpClient.GetAsync($"https://localhost:44332/api/Takimlar/{id}").Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var takimlar = JsonConvert.DeserializeObject<Sporcular>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(takimlar);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(Takimlar Takimlar)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(Takimlar), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PutAsync($"https://localhost:44332/api/Takimlar/{Takimlar.TID}", content).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"https://localhost:44332/api/Takimlar/{id}").Result;
            return RedirectToAction("Index");

        }
    }
}
