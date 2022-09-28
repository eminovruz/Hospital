namespace Hospital.Doctors
{
    

    public class Doctor
    {
        public string? name;
        public string? surname;
        public int age;
        public int workExperience;
        public TimeOnly startWork;
        public TimeOnly endWork;
        public bool time1 = true;
        public bool time2 = true;
        public bool time3 = true;

        public Doctor()
        {

        }

        public Doctor(string? name, string? surname, int age, int workExperience, TimeOnly startwork, TimeOnly endWork)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.workExperience = workExperience;
        }

        public override string ToString()
        {
            return @$"----------------------------
Name {name},
surname {surname},
age {age},
work Experience(with hours) {workExperience},
work start {startWork},
work end  {endWork}";
        }
    }


    public class DoctorWorker : Doctor  // Sade hekim
    {
        


    }
}
