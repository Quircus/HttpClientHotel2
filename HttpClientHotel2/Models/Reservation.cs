using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientHotel2.Models
{
	//[Serializable]
	//[Table("Reservations")]
	public class Reservation
	{
		//[Key]
		public int ReservationId { get; set; }

		public int Nights { get; set; }
		public DateTime CheckIn { get; set; }
		public DateTime CheckOut { get; set; }

		//[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		//[ForeignKey("Room")]
		public int RoomId { get; set; }

		public DateTime BookingLog { get; set; }


		//representation string//
		public override string ToString()
		{
			string rep = "Object " + base.ToString() + " Id:" + RoomId + " CustiD:" + CustomerId + " RoomId:" + RoomId;
			rep += "\nStaying " + Nights + " nights from " + CheckIn + " to " + CheckOut + ". Booked " + BookingLog;
			return rep;
		}

		//constructor//
		public Reservation()
		{
			Nights = 1;
		}
	}
}
