using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationAreeVerdiMilanoProgetto.Models;

namespace WebApplicationAreeVerdiMilanoProgetto.Controllers
{
    public class AreeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "https://dati.comune.milano.it/dataset/da6bc86d-c27f-4256-84eb-86c35dad7d0e/resource/3fe3c952-c632-4b8e-a4a3-616ef39414a0/download/ds339_territorioambiente_aree-verdi-zona-superficie_2014.json";

            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var aree = JsonConvert.DeserializeObject<List<AreaVerde>>(json);
                return View(aree);
            }
        }

        // Metodo per la ricerca
        public async Task<IActionResult> Search(string localita)
        {
            string url = "https://dati.comune.milano.it/dataset/da6bc86d-c27f-4256-84eb-86c35dad7d0e/resource/3fe3c952-c632-4b8e-a4a3-616ef39414a0/download/ds339_territorioambiente_aree-verdi-zona-superficie_2014.json";

            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                var aree = JsonConvert.DeserializeObject<List<AreaVerde>>(json);

                // Se il campo di ricerca è vuoto restituisce tutte le aree
                if (string.IsNullOrWhiteSpace(localita))
                {
                    return View("Index", aree);  // Non eseguiamo alcun filtro
                }

                // Altrimenti, filtra le aree in base alla località
                var risultati = aree
                    .Where(a => a.Nomelocalità != null && a.Nomelocalità.Contains(localita, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return View("Index", risultati);
            }
        }
    }
}
