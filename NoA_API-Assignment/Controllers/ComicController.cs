using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using NoA_API_Assignment.Models;

namespace NoA_API_Assignment.Controllers
{
	public class ComicController : Controller
	{
		private HttpClient client; // declare client
		private string url = "https://xkcd.com/info.0.json"; // our api address
		
		// ActionResult needs to be async
		public async Task<ActionResult> Debug()
		{
			InitializeClient();
			
			HttpResponseMessage response = await client.GetAsync(url); // try to get a response

			if (response.IsSuccessStatusCode)
			{
				var jsonString = await response.Content.ReadAsStringAsync(); // this will be our json string
				var comic = JsonConvert.DeserializeObject<Comic>(jsonString); // deserialize the string
				
				return Content(comic.num.ToString()); // print something to check it was converted correct
			}
			else
			{
				return Content("no response");
			}
		}
		
		// Initialize our HTTP client. Maybe there is a better place to do this? Now we kinda initialize every time
		// we load our page
		// TODO: optimize the initialization of the client
		public void InitializeClient()
		{
			client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}