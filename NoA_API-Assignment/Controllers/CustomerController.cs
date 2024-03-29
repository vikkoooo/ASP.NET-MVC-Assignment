﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using NoA_API_Assignment.Models;
using NoA_API_Assignment.ViewModel;

namespace NoA_API_Assignment.Controllers
{
	public class CustomerController : Controller
	{
		private List<Customer> group1, group2, group3;

		public ActionResult Index()
		{
			// Create dummy list of dummy class Customer
			var customers = new List<Customer>
			{
				new Customer
				{
					CustomerName = "John",
					Age = 33,
					Email = "john@gmail.com",
					TotalSales = 4000,
					FinalPurchaseDate = new DateTime(2021, 3, 29),
					PantoneValue = "17-4587"
				},
				new Customer
				{
					CustomerName = "George",
					Age = 32,
					Email = "george@gmail.com",
					TotalSales = 6000,
					FinalPurchaseDate = new DateTime(2021, 2, 12),
					PantoneValue = "21-4587"
				},
				new Customer
				{
					CustomerName = "Peter",
					Age = 28,
					Email = "peter@gmail.com",
					TotalSales = 2000,
					FinalPurchaseDate = new DateTime(2021, 1, 10),
					PantoneValue = "20-4587"
				}
			};

			// Serialize the list to json string
			var outputJson = JsonConvert.SerializeObject(customers);

			/*
			 * The output will look like this. The [] brackets indicates it's a list
			 * 
			 * [{"CustomerName":"John","Email":"john@gmail.com","Age":33,"TotalSales":4000.0,"FinalPurchaseDate":"2021-03-29T00:00:00","PantoneValue":"17-4587"},
			 * {"CustomerName":"George","Email":"george@gmail.com","Age":32,"TotalSales":6000.0,"FinalPurchaseDate":"2021-02-12T00:00:00","PantoneValue":"21-4587"},
			 * {"CustomerName":"Peter","Email":"peter@gmail.com","Age":28,"TotalSales":2000.0,"FinalPurchaseDate":"2021-01-10T00:00:00","PantoneValue":"20-4587"}]
			 */

			// Deserialize into a list. This is the same output I will get when I get the correct API back
			var customerList = JsonConvert.DeserializeObject<List<Customer>>(outputJson);

			// If we in fact get something back from the deserialization, lets group it according to instructions
			if (customerList.Count > 0)
			{
				try
				{
					GroupData(customerList);
					//SortLists();
				}
				catch (Exception e)
				{
					// TBH, I don't know how to handle the exceptions nice in this kind of application.
					// If it was Windows Forms or Console application I would give a MessageBox or Console.WriteLine
					// In this case, at least we get to see the stacktrace. Not very useful for the user tho.
					return Content(e.StackTrace);
				}
			}

			// testing what groups they came in
			foreach (var e in group1)
			{
				Console.WriteLine($"Group1: {e.ToString()}");
			}

			foreach (var e in group2)
			{
				Console.WriteLine($"Group2: {e.ToString()}");
			}

			foreach (var e in group3)
			{
				Console.WriteLine($"Group3: {e.ToString()}");
			}

			string test = customerList[0].PantoneValue;
			return Content(outputJson);
		}
		
		// Sorts the input into 3 different group lists
		private void GroupData(List<Customer> input)
		{
			group1 = new List<Customer>();
			group2 = new List<Customer>();
			group3 = new List<Customer>();

			foreach (var e in input)
			{
				// this will give us integer value of input until first occurrence of '-' character
				int value = Int32.Parse(StringTrimmer(e.PantoneValue));

				if (value % 3 == 0)
				{
					group1.Add(e);
				}
				else if (value % 2 == 0)
				{
					group2.Add(e);
				}
				else
				{
					group3.Add(e);
				}
			}
		}

		// Input string will be something like: 17-4587, and we want the first part
		private string StringTrimmer(string untrimmed)
		{
			int stopIndex = untrimmed.IndexOf('-');

			if (stopIndex > 0)
			{
				// should return a string of "17" if input was "17-4587"
				return untrimmed.Substring(0, stopIndex);
			}

			// if input doesn't contain any '-' character, do nothing
			return untrimmed;
		}

		//	/customer/sorter
		public ActionResult Sorter()
		{
			SortLists();
			
			var customer = new Customer() { CustomerName = "test name" };

			List<Customer> tempList = new List<Customer>() {new Customer() {CustomerName = "test name 1"}};
			tempList.Add(new Customer() {CustomerName = "test name 2"});


			var viewModel = new SorterCustomerViewModel() {Group1 = tempList};
			
			return View(viewModel);
			return Content("sorter method was called");
		}
		
		// Method to sort lists with objects according to a value in the object
		private void SortLists()
		{
			// create anonymous types list
			var unsorted = CreateList(new {name = "Hibiscus", priority = 3 });
			unsorted.Add(new {name = "Rose", priority = 1});
			unsorted.Add(new {name = "Lili", priority = 4});


			var sorted = CreateList(new {name = "", priority = 0 });
			sorted.Clear();
			sorted = unsorted.OrderBy(x => x.priority).ToList();
			//Console.WriteLine(String.Join(Environment.NewLine, sorted));
			
			// print results in console
			Console.WriteLine("unsorted list");
			foreach (var entry in unsorted)
			{
				Console.WriteLine(entry.name + " " + entry.priority);
			}
			
			Console.WriteLine("-------------");
			Console.WriteLine("sorted list");
			
			foreach (var entry in sorted)
			{
				Console.WriteLine(entry.name + " " + entry.priority);
			}
			
			
			
		}

		// helper method to create list of anonymous type
		private static List<T> CreateList<T>(params T[] elements)
		{
			return new List<T>(elements);
		}
	}
}