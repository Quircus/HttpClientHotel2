using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HttpClientHotel2.Models;
using System.Linq;

namespace HttpClientHotel2
{


	class Program
	{
		static HttpClient client = new HttpClient();

		static void ShowRoom(Room Room)
		{
			Console.WriteLine($"Id: {Room.RoomId}\t\t" + $"Name: {Room.Name}\tRates: " +
				$"{Room.Rates}\tCategory: {Room.Beds}");
		}

		static async Task<Uri> CreateRoomAsync(Room Room)
		{
			HttpResponseMessage response = await client.PostAsJsonAsync(
				"api/Rooms", Room);
			response.EnsureSuccessStatusCode();

			// return URI of the created resource.
			return response.Headers.Location;
		}

		static async Task<Room> GetRoomAsync(string path)
		{
			Room Room = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				Room = await response.Content.ReadAsAsync<Room>();
			}
			return Room;
		}

		static async Task<Room> UpdateRoomAsync(Room Room)
		{
			HttpResponseMessage response = await client.PutAsJsonAsync(
				"api/Rooms/"+Room.RoomId, Room);
			response.EnsureSuccessStatusCode();
			// Deserialize the updated Room from the response body.
			Room = await response.Content.ReadAsAsync<Room>();
			return Room;
		}

		static async Task<HttpStatusCode> DeleteRoomAsync(string id)
		{
			HttpResponseMessage response = await client.DeleteAsync(
				$"api/Rooms/{id}");
			return response.StatusCode;
		}


		/// <summary>
		/// Customer async methods
		/// 
		static async Task<Customer> GetCustomerAsync(string path)
		{
			Customer guest = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				guest = await response.Content.ReadAsAsync<Customer>();
			}
			return guest;
		}

		/// reservation async methods
		/// 
		static async Task<Reservation> GetReservationAsync(string path)
		{
			Reservation book = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				book = await response.Content.ReadAsAsync<Reservation>();
			}
			return book;
		}


		/// </summary>

		static void Main()
		{
			RunAsync().GetAwaiter().GetResult();
		}

		static async Task RunAsync()
		{
			// Update port # in the following line.
			client.BaseAddress = new Uri("http://localhost:19017/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			Room test = new Room() { RoomUrl = "https://i.imgur.com/GJUUYRR.jpg", Name = "Test Suite", Beds = "Twin", Rates = 222.0, Details = "This charming test suite is entirely fictitious." };
			Console.WriteLine(test);
			Console.ReadLine();

			try
			{
				// Create a new Room
				Room testSuite = new Room() { RoomUrl = "https://i.imgur.com/GJUUYRR.jpg", Name = "Test Suite", Beds = "Twin", Rates = 222.0, Details = "This charming test suite is entirely fictitious." };
				Console.WriteLine(testSuite);
				Console.ReadLine();

				//var url = await CreateRoomAsync(testSuite);
				//Console.WriteLine($"Created at {url}");

				//// Get the Room
				//testSuite = await GetRoomAsync(url.PathAndQuery);
				//Console.Write("Get Room Async returns, using {0}", url.PathAndQuery);
				//ShowRoom(testSuite);

				//// Update the Room
				//Console.WriteLine("Updating Rates...");
				//testSuite.Rates = 80.0;
				//await UpdateRoomAsync(testSuite);

				//// Get the updated Room
				//testSuite = await GetRoomAsync(url.PathAndQuery);
				//Console.Write("Get Room Async returns, using {0}", url.PathAndQuery);
				//ShowRoom(testSuite);

				//// Delete the Room
				//var statusCode = await DeleteRoomAsync(testSuite.RoomId.ToString());
				//Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

				// Check Customer
				Customer testguest = new Customer();
				testguest = await GetCustomerAsync(client.BaseAddress+"api/Customers/2");
				Console.WriteLine(testguest);

				bool completed = testguest.GetType().GetProperties()
						.Where(p => p.GetValue(testguest) is string)
						.Select(p => (string)p.GetValue(testguest))
						.All(value => String.IsNullOrEmpty(value));

				Console.WriteLine(completed);

				// Add Reservation
				Reservation holiday = new Reservation();
				holiday.ReservationId = 10;
				holiday.CustomerId = 3;
				holiday.RoomId = 3;
				holiday.CheckIn = new DateTime(2017, 12, 27, 14, 0, 0);
				holiday.CheckOut = new DateTime(2017, 12, 29, 11, 0, 0);
				holiday.Nights = (int)Math.Ceiling((holiday.CheckOut - holiday.CheckIn).TotalDays);
				holiday.BookingLog = DateTime.Now;

				Console.WriteLine(holiday);

				Reservation h = new Reservation();

				completed = h.GetType().GetProperties()
					.Where(p => p.GetValue(h) is string)
					.Select(p => (string)p.GetValue(h))
					.All(value => String.IsNullOrEmpty(value));

				Console.WriteLine(completed);



			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			Console.ReadLine();


		}
	}
}