using Hospital.Game;
using Hospital.Building;
using Hospital.Doctors;
using Hospital.Interfaces;
using Hospital.ExtensionMethods;

namespace Hospital;

public class Program
{

    static void Main()
    {
        #region Lists & Buildings
        
        List<HospitalBuilding>? buildings = new();

        MerkeziKlinika m1 = new MerkeziKlinika(Guid.NewGuid(), "Merkezi klinika", new TimeOnly(11, 45), new TimeOnly(19, 45), new List<Doctor>()
        {
            new Doctor("GuleBatin", "Hesenova", 85,2000, new TimeOnly(), new TimeOnly()),
            new Doctor("Nuray", "Novruz", 11,150,new TimeOnly(), new TimeOnly()),
            new Doctor("Emin", "Novruz", 11,150,new TimeOnly(), new TimeOnly()),
        });

        Semaska s1 = new Semaska(Guid.NewGuid(), "Semaska", new TimeOnly(11, 45), new TimeOnly(19, 45), new List<Doctor>()
        {
            new Doctor("Aysel", "Memmedova", 33,2122, new TimeOnly(), new TimeOnly()),
            new Doctor("Ilkin", "Memmedli", 22,4150,new TimeOnly(), new TimeOnly()),
        });

        MedikaHospital k1 = new MedikaHospital(Guid.NewGuid(), "Medika Hospital", new TimeOnly(11, 45), new TimeOnly(19, 45), new List<Doctor>()
        {
            new Doctor("Ayan", "Qurbanzade", 33,2122, new TimeOnly(), new TimeOnly()),
            new Doctor("Aydin", "Aminov", 22,4150,new TimeOnly(), new TimeOnly()),
        });
        #endregion

        buildings?.Add(m1);
        buildings?.Add(s1);
        buildings?.Add(k1);

        Game.Game game = new(buildings);

        while (true)
        {
            game.MainMenu();




        }


    }



}