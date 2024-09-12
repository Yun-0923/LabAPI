using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabAPI.Models;
using Newtonsoft.Json;

namespace LabAPI.Controllers
{
    public class CornonavirusForViewController : Controller
    {
        private readonly dbLabContext _context;

        public CornonavirusForViewController(dbLabContext context)
        {
            _context = context;
        }

        // GET: CornonavirusForView
        public async Task<IActionResult> Index()
        {
            string url = "https://covid-19.nchc.org.tw/2023_dt_json.php?dt_name=10&ext=全國_全區";
            HttpClient client = new HttpClient();

            client.MaxResponseContentBufferSize = Int32.MaxValue;

            var resp = await client.GetStringAsync(url);
            var collection = JsonConvert.DeserializeObject<IEnumerable<Cornonavirus>>(resp);
            return View(collection);
        }

        
    }
}
