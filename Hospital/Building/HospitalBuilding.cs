using Hospital.Interfaces;

namespace Hospital.Building
{
    [Serializable]
    public class HospitalBuilding
    {

        public Guid? Id { get; set; }
        public string? name;
        public List<Doctors.Doctor> doctors;
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }

        public HospitalBuilding() { }

        public HospitalBuilding(Guid? id, string? name, TimeOnly openTime, TimeOnly closeTime, List<Doctors.Doctor> doctors)
        {
            Id = id;
            this.name = name;
            this.OpenTime = openTime;
            this.CloseTime = closeTime;
            this.doctors = doctors;
        }

        public List<Doctors.Doctor> GetDoctors()
        {
            return this.doctors;
        }


        public void ShowDoctors()
        {
            Console.WriteLine("---------- DOCTORS ----------");
            
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }
        }

        virtual public void Show()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Id {Id}");
            Console.WriteLine($"Name {name}");
            Console.WriteLine($"Open time {OpenTime}");
            Console.WriteLine($"Close time {CloseTime}");
        }

    }

    public class Semaska : HospitalBuilding, Pediatriya, Reanimasiya, İnfeksionist
    {
        public Semaska(Guid? id, string? name, TimeOnly openTime, TimeOnly closeTime, List<Doctors.Doctor> doctors)
            :base(id, name, openTime, closeTime, doctors)
        { }

        public Semaska()
        {

        }

        public override void Show()
        {
            base.Show();
        }
    }

    public class MerkeziKlinika : HospitalBuilding, Pediatriya, Reanimasiya
    {
        public MerkeziKlinika(Guid? id, string? name, TimeOnly openTime, TimeOnly closeTime, List<Doctors.Doctor> doctors)
            : base(id, name, openTime, closeTime, doctors)
        { }

        public MerkeziKlinika()
        {

        }

        public override void Show()
        {
            base.Show();
        }
    }

    public class MedikaHospital : HospitalBuilding, Neyrocərrahiyyə, İnfeksionist
    {
        public MedikaHospital(Guid? id, string? name, TimeOnly openTime, TimeOnly closeTime, List<Doctors.Doctor> doctors)
            : base(id, name, openTime, closeTime, doctors)
        { }

        public MedikaHospital()
        {
                
        }

        public override void Show()
        {
            base.Show();
        }
    }
}
