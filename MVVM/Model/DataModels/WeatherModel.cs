using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
	public class WeatherModel
	{
		public Daily daily { get; set; }
	}


	public class Daily
	{
		public List<Data> data { get; set; }
	}


	public class Data 
	{
		public string day { get; set; }
		public string weather { get; set; }
		public double temperature { get; set; }
		public double temperature_min { get; set; }
		public double temperature_max { get; set; }
		public double feels_like { get; set; }
	}

}
