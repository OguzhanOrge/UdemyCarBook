using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.CarBook.Domain.Entities
{
	public class Car
	{
		public int CarID { get; set; }
		public int BrandID { get; set; }
		public Brand Brand { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public int Km { get; set; }
		public string Transmissions {  get; set; }
		public byte Seat { get; set; }
		public byte Luggage { get; set; }
		public string Fuel { get; set; }
		public string BigImageUrl { get; set; }
		public List<CarFeature> CarFeature	{ get; set; }
		public List<CarDescription> CarDescription { get; set; }
		public List<CarPricing> CarPricing { get; set; }


	}
}
