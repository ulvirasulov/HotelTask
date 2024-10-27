using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models
{
    public class Hotel
    {
		private string _name;
		static int _id;
		public int Id { get; }
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
        public Hotel(string name)
        {
            Name = name;
			Id = ++_id;
        }
    }
}
