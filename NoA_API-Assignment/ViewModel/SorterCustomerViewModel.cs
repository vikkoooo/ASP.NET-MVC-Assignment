using System.Collections.Generic;
using NoA_API_Assignment.Models;

namespace NoA_API_Assignment.ViewModel
{
	public class SorterCustomerViewModel
	{
		public Customer Customer { get; set; }
		public List<Customer> Group1 { get; set; }
		public List<Customer> Group2 { get; set; }
	}
}