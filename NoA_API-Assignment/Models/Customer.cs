using System;

namespace NoA_API_Assignment.Models
{
	[Serializable]
	public class Customer
	{
		// if using this line it will change the name to whatever we write here, instead of our local variable name
		//[JsonProperty("customer_name")]
		public string CustomerName { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }
		public decimal TotalSales { get; set; }
		public DateTime FinalPurchaseDate { get; set; }
		public String PantoneValue { get; set; }

		// Custom ToString method
		public override string ToString()
		{
			return $"Customer name: {CustomerName}, Email: {Email}, Age: {Age}, Total sales: {TotalSales}, Latest date of purchase: {FinalPurchaseDate}, Pantone value: {PantoneValue}";
		}
	}
}