using HotelTask.Models;

namespace HotelTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool f = false;
            Hotel[] hotels = new Hotel[0];
            AppDbContext dbContext = new AppDbContext();
            do
            {
                Console.WriteLine("1. sisteme giris");
                Console.WriteLine("0. cixis");
                string secim1 = Console.ReadLine();
                switch (secim1)
                {
                    case "0":
                        f = true;
                        break;
                    case "1":
                        Console.WriteLine("sisteme giris olundu...");
                        bool f2 = true;
                        while (f2)
                        {
                            Console.WriteLine("1. hotel yarat");
                            Console.WriteLine("2. butun hotelleri gor");
                            Console.WriteLine("3. hotel sec");
                            Console.WriteLine("0. exit");
                            string secim2 = Console.ReadLine();
                            switch (secim2)
                            {
                                case "0":
                                    f2 = false;
                                    break;
                                case "1":
                                    Console.Write("yeni hotelin adini daxil edin:");
                                    string hotelName = Console.ReadLine();
                                    Array.Resize(ref hotels, hotels.Length + 1);
                                    hotels[^1] = new Hotel(hotelName);
                                    Console.WriteLine("hotel yaradildi");
                                    break;
                                case "2":
                                    Console.WriteLine("butun hoteller:");
                                    if (hotels.Length == 0)
                                    {
                                        Console.WriteLine("hec bir hotel yoxdur!");
                                    }
                                    else
                                    {
                                        foreach (var hotel in hotels)
                                        {
                                            Console.WriteLine(hotel.Name+", ");
                                        }
                                    }
                                    break;
                                case "3":
                                    Console.Write("hotel adini daxil edin:");
                                    string secilenHotelAdi = Console.ReadLine();

                                    Hotel secilenHotel = null;
                                    foreach (var hotel in hotels)
                                    {
                                        if (hotel.Name == secilenHotelAdi)
                                        {
                                            secilenHotel = hotel;
                                            break;
                                        }
                                    }

                                    if (secilenHotel != null)
                                    {
                                        bool f3 = true;
                                        while (f3)
                                        {
                                            Console.WriteLine("1. room yarat");
                                            Console.WriteLine("2. roomlari gor");
                                            Console.WriteLine("3. rezervasiya et");
                                            Console.WriteLine("0. exit");
                                            string secim3 = Console.ReadLine();
                                            switch (secim3)
                                            {
                                                case "0":
                                                    f3 = false;
                                                    break;
                                                case "1":
                                                    Console.Write("yeni room adini daxil edin:");
                                                    string roomName = Console.ReadLine();
                                                    Console.Write("room qiymeyini daxil edin: ");
                                                    int roomPrice = int.Parse(Console.ReadLine());
                                                    Console.Write("otaq tutumunu daxil edin: ");
                                                    int personCapacity = int.Parse(Console.ReadLine());

                                                    dbContext.AddRoom(new Room(roomName, roomPrice, personCapacity));
                                                    break;
                                                case "2":
                                                    Console.Write("axtarmaq istediyiniz otagin adini daxil edin:");
                                                    int axtarilanOtaqAdi = int.Parse(Console.ReadLine());
                                                    dbContext.FindAllRoomById(axtarilanOtaqAdi);
                                                    break;
                                                case "3":
                                                    Console.Write("rezervasiya etmek istediyiniz otaq ID-ni daxil edin:");
                                                    int? roomId = int.Parse(Console.ReadLine());
                                                    Console.Write("musteri sayini daxil edin:");
                                                    int musteriSayi = int.Parse(Console.ReadLine());

                                                    try
                                                    {
                                                        dbContext.MakeReservation(roomId, musteriSayi);
                                                    }
                                                    catch (NotAvailableException)
                                                    {
                                                        Console.WriteLine("bu otaq artiq rezervasiya edilib");
                                                    }
                                                    catch (NullReferenceException)
                                                    {
                                                        Console.WriteLine("otaq ID-si bos ola bilmez");
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("duzgun secim edin");
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("bu adda hotel tapilmadi");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("duzgun secim edin");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("duzgun secim edin");
                        break;
                }
            }
            while (!f);
        }
    }
}
