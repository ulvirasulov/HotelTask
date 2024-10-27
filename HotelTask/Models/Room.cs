using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models
{
    public class Room
    {
        static int _id;
        public bool isAvailable;
        public bool IsAvailable { get; set; }
        public Room(string name, int price, int personCapacity)
        {
            PersonCapacity = personCapacity;
            Name = name;
            Price = price;
            isAvailable = true;
            Id = ++_id;
        }
        public int Id { get; }
        public string Name { get; set; }
        public int Price { get; set; }
        private int _personalCapasity = 1;
        public int PersonCapacity
        {
            get { return _personalCapasity; }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _personalCapasity = value;
                }
                else
                {
                    Console.WriteLine("personal capasity 4-den artiq ola bilmez");
                }
            }
        }
        public string ShowInfo()
        {
            string info = $"id: {Id}, name: {Name}, price: {Price}, PersonCapacity: {PersonCapacity}, is available: {isAvailable}";
            return info;
        }
        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
