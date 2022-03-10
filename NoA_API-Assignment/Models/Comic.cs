using System;
using Newtonsoft.Json;

namespace NoA_API_Assignment.Models
{
	[Serializable]
	public class Comic
	{
		// if using this line it will change the name to whatever we write here, instead of our local variable name
		//[JsonProperty("month_")]
		public string month { get; set; }
		public int num { get; set; }
		public string link { get; set; }
		public string year { get; set; }
		public string news { get; set; }
		public string safe_title { get; set; }
		public string transcript { get; set; }
		public string alt { get; set; }
		public string img { get; set; }
		public string title { get; set; }
		public string day { get; set; }
		public string group { get; set; }
		
		// public Comic()
		// {
		// 	group = null;
		// }
	}
}