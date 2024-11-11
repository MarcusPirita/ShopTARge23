using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopTARge23.Models;

namespace ShopTARge23.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly HttpClient _httpClient;

        public ChuckNorrisController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ChuckNorrisSearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> GetRandomJoke()
        {
            var joke = await FetchRandomJoke();
            var viewModel = new ChuckNorrisSearchViewModel
            {
                JokeText = joke.Value,
                JokeUrl = joke.Url,
            };
            return View("Index", viewModel);
        }

        private async Task<ChuckNorrisJoke> FetchRandomJoke()
        {
            var response = await _httpClient.GetStringAsync("https://api.chucknorris.io/jokes/random");
            return JsonConvert.DeserializeObject<ChuckNorrisJoke>(response);
        }
    }
}
