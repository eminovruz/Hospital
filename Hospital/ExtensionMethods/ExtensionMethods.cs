namespace Hospital.ExtensionMethods;

static class ExtensionMethods
{
    static public void Show(this List<Building.HospitalBuilding> buildings)
    {
        foreach (var building in buildings)
        {
            building.Show();
        }
    }

    static public void ShowAllDoctors(this List<Building.HospitalBuilding> buildings)
    {
        foreach (var building in buildings)
        {
            building.ShowDoctors();
        }
    }

    static public void ShowDoctorsGreaterThan(this List<Doctors.Doctor> doctors, int value)
    {
        foreach (var doctor in doctors)
        {
            if (doctor.workExperience >= value)
                Console.WriteLine(doctor);
        }
    }

}

