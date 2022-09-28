using Hospital.Building;
using Hospital.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;


namespace Hospital.Game
{
    public class Game
    {
        private string? data;
        public List<HospitalBuilding>? buildings;
        private int c = 0;
        private ConsoleKeyInfo k = new();
        private string? doctorsNameSurname;

        public Game(List<HospitalBuilding>? buildings)
        {
            this.buildings = buildings;
            using StreamReader sw = new(new FileStream("Doctors.txt", FileMode.OpenOrCreate));
            doctorsNameSurname += sw.ReadLine();
            doctorsNameSurname += "\n";
        }

        public void Serializer()
        {
            while (true)
            {

                Console.WriteLine("- Sellect Serialize -");
                Console.WriteLine("Json [j]");
                Console.WriteLine("XML [x]");
                k = Console.ReadKey();



                if (k.Key == ConsoleKey.X)
                {
                    XmlSerialize();
                }
                else if (k.Key == ConsoleKey.J)
                {
                }
                else
                    throw new ArgumentException("Cant find service");
            }
        }

        public void XmlSerialize()
        {
            var xml = new XmlSerializer(typeof(Doctor));
            using var fs = new FileStream("Doctors.xml", FileMode.OpenOrCreate);
            xml.Serialize(fs, buildings);

            Console.WriteLine("Ready");
        }

        public void AddDoctor(FileStream doctors)
        {
            Doctors.DoctorWorker s = new();
            Console.WriteLine("Enter name of Doctor: ");
            s.name = Console.ReadLine();
            Console.WriteLine("Enter surname of Doctor: ");
            s.surname = Console.ReadLine();
            if(s.name == "" || s.surname == "")
            {
                throw new Exception("Ad ve soyad bos ola bilmez");
                return;
            }

            using StreamWriter sw = new(doctors);

            sw.WriteLine(s);


        }


        public void ChooseDoctor(Doctors.Doctor doctor)
        {
            Console.Clear();


            #region If Else for reserve
            Console.WriteLine($"---- Free times of {doctor.name} ----");
            if (doctor.time1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("09;00 -- 12;00 -> 1");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("09;00 -- 12;00 (Reserved)");
            }
            if (doctor.time2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("12;00 -- 15;00 -> 2");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("12;00 -- 15;00 (Reserved)");
            }
            if (doctor.time3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("15;00 -- 18;00 -> 3");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("15;00 -- 18;00 (Reserved)");
            }
            Console.ForegroundColor = ConsoleColor.White;

            #endregion

            data = Console.ReadLine();


            if (data == "1" && doctor.time1)
                doctor.time1 = false;
            else if (data == "2" && doctor.time2)
                doctor.time2 = false;
            else if (data == "3" && doctor.time3)
                doctor.time3 = false;
            else
            {

            }

        }

        public void Filter()
        {
            Console.Clear();
            Console.WriteLine("Show me doctors (upper work experience than this value) -- 1");
            Console.WriteLine("Show me doctors (who is free at this time) -- 2");
            Console.WriteLine("Show me doctors (who is boy) -- 3");
            Console.WriteLine("Show me doctors (who is girl) -- 4");
            data = Console.ReadLine();

            if (data == "1")
            {
                foreach (var doctor in buildings)
                {
                    doctor.GetDoctors().ShowDoctorsGreaterThan(2000);
                }

                Console.WriteLine("Enter name of doctor: ");
                data = Console.ReadLine();

                int i = 0;

                foreach (var item in buildings[i++].GetDoctors())
                {
                    if (item.name == data)
                    {
                        ChooseDoctor(item);
                    }
                }
            }

        }

        public void ControlClinic(HospitalBuilding H)
        {
            while (true)
            {

                Console.WriteLine("Show Hospital -- [1]");
                Console.WriteLine("Show Doctors -- [2]");
                Console.WriteLine("Add doctor -- [3]");
                k = Console.ReadKey();
                H.doctors = new();

                if (k.Key == ConsoleKey.D1)
                {
                    H.Show();
                }
                else if (k.Key == ConsoleKey.D2)
                {
                    if(H.GetDoctors().Count == 0)
                    {
                        Console.WriteLine("Dont have doctor");
                    }
                    else
                        H.ShowDoctors();
                }
                else if(k.Key == ConsoleKey.D3)
                {
                    try
                    {
                        AddDoctor(new FileStream("Doctors.txt", FileMode.OpenOrCreate, FileAccess.Write));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } 
            }

        }


        public void Register()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Semaska -- [1]");
            Console.WriteLine("Merkezi Klinika -- [2]");
            Console.WriteLine("Medikal Klinika -- [3]");
            Console.WriteLine("Sellect specific Clinic -- [4]");
            Console.ForegroundColor = ConsoleColor.White;
            k = Console.ReadKey();

            if (k.Key == ConsoleKey.D1)
            {
                buildings[1]?.Show();
                buildings[1]?.ShowDoctors();
                Console.WriteLine("Enter name of Doctor: ");
                data = Console.ReadLine();
                foreach (var item in buildings[1].doctors)
                {
                    if (item.name == data)
                    {
                        ChooseDoctor(item);
                    }
                }
            }
            else if (k.Key == ConsoleKey.D2)
            {
                buildings[0]?.Show();
                buildings[0]?.ShowDoctors();
                Console.WriteLine("Enter name of Doctor: ");
                data = Console.ReadLine();
                foreach (var item in buildings[0].doctors)
                {
                    if (item.name == data)
                    {
                        ChooseDoctor(item);
                    }
                }
            }
            else if (k.Key == ConsoleKey.D3)
            {
                buildings[2]?.Show();
                buildings[2]?.ShowDoctors();
                Console.WriteLine("Enter name of Doctor: ");
                data = Console.ReadLine();
                foreach (var item in buildings[2].doctors)
                {
                    if (item.name == data)
                    {
                        ChooseDoctor(item);
                    }
                }
            }
            else if (k.Key == ConsoleKey.D4)
            {
                HospitalBuilding h = new();
                Console.WriteLine("Enter name of clinic");
                h.name = Console.ReadLine();
                ControlClinic(h);
            }
            else
                Console.WriteLine("\a");


        }

        public void Map()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Welcome to map, U can discover clinics here ---");
                Console.WriteLine("See the clinics [1]");
                Console.WriteLine("See all doctors [2]");
                Console.WriteLine("Filter [3]");
                Console.WriteLine("Go back [esc]");
                k = Console.ReadKey();

                if (k.Key == ConsoleKey.D1)
                {
                    buildings.Show();
                    Thread.Sleep(4000);
                }
                else if (k.Key == ConsoleKey.D2)
                {
                    buildings.ShowAllDoctors();
                    Thread.Sleep(4000);
                }
                else if (k.Key == ConsoleKey.D3)
                {
                    Filter();
                    Thread.Sleep(4000);

                }
                else if (k.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else
                {
                    throw new ArgumentException("Service yoxdur");
                }

            }



        }

        public void MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------- Welcome to Hospital register ------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Register -- [1]");
            Console.WriteLine("Map -- [2]");
            Console.ForegroundColor = ConsoleColor.White;
            k = Console.ReadKey();

            switch (k.Key)
            {
                case ConsoleKey.D1:
                    Register();
                    break;
                case ConsoleKey.D2:
                    try
                    {
                        Map();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case ConsoleKey.D3:
                    break;
                default:
                    break;
            }
        }





    }


}
