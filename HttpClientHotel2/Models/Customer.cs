using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientHotel2.Models
{
	//[Serializable]
	//[Table("Customers")]
	public class Customer
	{
		//[Key]
		public int CustomerId { get; set; }
		//[MaxLength(30)]
		public string ForeName { get; set; }
		//[MaxLength(40)]
		public string SurName { get; set; }
		//[MaxLength(20)]
		public string Title { get; set; }
		public double Billing { get; set; }
		public string Prefs { get; set; }


		public virtual ICollection<Reservation> Reservations { get; set; }

		//representation string//
		public override string ToString()
		{
			return base.ToString() + "\t Id:" + CustomerId + Title + " " + ForeName + " " + SurName;
		}

		//constructor//
		public Customer(string fore = "Field Required", string sur = "Field Required", double nonRefundable = 0.0, string pre = "None")
		{
			ForeName = fore;
			SurName = sur;
			Billing = nonRefundable;
			Prefs = pre;
		}

	}
}
