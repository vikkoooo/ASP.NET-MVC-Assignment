using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using NoA_API_Assignment.Client;
using NoA_API_Assignment.Models;

namespace NoA_API_Assignment.Controllers
{
	public class ComicController : Controller
	{
		private HttpClient client; // declare client.
		private string url = "https://xkcd.com/info.0.json"; // our api address
		
		// ActionResult needs to be async. method runs when we go to /comic/debug
		public async Task<ActionResult> Debug()
		{
			client = ClientSingleton.GetInstance().Client; // Dependency injection of singleton http client
			HttpResponseMessage response = await client.GetAsync(url); // try to get a response

			if (response.IsSuccessStatusCode)
			{
				var jsonString = await response.Content.ReadAsStringAsync(); // this will be our json string
				var comic = JsonConvert.DeserializeObject<Comic>(jsonString); // deserialize the string

				// do stuff with the read data here
				// debugging mode just prints something
				comic.group = "group1";
				
				return Content(comic.num.ToString()); // print something to check it was converted correct
			}
			else
			{
				return Content("no response");
			}
		}
		
	}
}