using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientHotel2.Models
{
	//public enum BedType
	//{
	//	Single,
	//	Twin,
	//	Double
	//}


	//[Serializable]
	//[Table("Rooms")]
	public class Room
	{
		//[Key]
		public int RoomId { get; set; }
		public string RoomUrl { get; set; }
		public string Name { get; set; }
		public string Beds { get; set; }
		public double Rates { get; set; }
		public string Details { get; set; }

		public virtual ICollection<Reservation> Reservations { get; set; }

		public override string ToString()
		{
			return base.ToString()+"\t"+this.RoomId+"\t"+this.Name+"\t"+this.Beds+"\t"+this.Rates+"\t"+this.Details;
		}

		//default constructor//
		public Room()
		{
			Beds = "Double";
			Rates = 200.0;
			Details = "Our standard room.";
			ICollection<Reservation> Reservations = new List<Reservation>();
		}

		//constructor//
		public Room(string img, string title = "Standard Room", string bed = "Double", double rate = 200.0, string det = "Lorem Ipsum")
		{
			RoomUrl = img;
			Name = title;
			Beds = bed;
			Rates = rate;
			Details = det;
			ICollection<Reservation> Reservations = new List<Reservation>();
		}


	}
}
