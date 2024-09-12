using LabAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LabAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CornonavirusController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Cornonavirus>> Get()
        {
            string url = "https://covid-19.nchc.org.tw/2023_dt_json.php?dt_name=10&ext=全國_全區";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

            var resp = await client.GetStringAsync(url);
            var collection = JsonConvert.DeserializeObject<IEnumerable<Cornonavirus>>(resp);
            return collection;
        }
    }
}
