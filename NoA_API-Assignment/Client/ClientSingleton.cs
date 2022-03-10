using System.Net.Http;
using System.Net.Http.Headers;

namespace NoA_API_Assignment.Client
{
	public class ClientSingleton
	{
		private static ClientSingleton current; // This instance
		public HttpClient Client { get; } // The client we want

		// Constructor
		private ClientSingleton()
		{
			Client = new HttpClient();
			Client.DefaultRequestHeaders.Accept.Clear();
			Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		// Non thread safe singleton returner
		public static ClientSingleton GetInstance()
		{
			if (current == null)
			{
				current = new ClientSingleton();
			}
			return current;
		}
	}
}