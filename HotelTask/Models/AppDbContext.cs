using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models
{
    public class AppDbContext
    {
        private Room[] rooms = new Room[0];

        public void AddRoom(Room room)
        {
            Array.Resize(ref rooms, rooms.Length + 1);
            rooms[^1] = room;
            Console.WriteLine("teze otaq mubarek olsun");
        }

        public void FindAllRoomById(int roomId)
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].Id == roomId)
                {
                    Console.WriteLine($"axtarilan id-ye uygun otaqlar: {rooms[i].Name}");
                }
                else
                {
                    Console.WriteLine("axtarilan id-ye uygun otaq yoxdur");
                }
            }
        }

        public void MakeReservation(int? roomId, int musteriSayi)
        {
            if (roomId == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                for (int i = 0; i < rooms.Length; i++)
                {
                    if (rooms[i].Id == roomId)
                    {
                        if (rooms[i].IsAvailable == true)
                        {
                            if (rooms[i].PersonCapacity >= musteriSayi)
                            {
                                Console.WriteLine("bu otaq rezerv edilmeye uygundur");
                                rooms[i].IsAvailable = false;
                            }
                            else
                            {
                                Console.WriteLine("personal capasity-ye uygun deyil");
                            }
                        }
                        else
                        {
                            throw new NotAvailableException();
                        }
                    }
                    else
                    {
                        Console.WriteLine("bele bir otaq yoxdur");
                    }
                }
            }
        }
    }
}
