﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.CarBook.Domain.Entities
{
	public class CarFeature
	{
		public int CarFeatureID { get; set; }
		public int CarID { get; set; }
		public Car car { get; set; }
		public int FeatureID { get; set; }
		public Feature feature { get; set; }
		public bool Available { get; set; }
	}
}
