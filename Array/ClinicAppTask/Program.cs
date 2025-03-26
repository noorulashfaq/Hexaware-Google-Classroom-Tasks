using System;

class DoctorProgram
{
    static void Main(string[] args)
    {
        Doctor[] doctors = {
            new Doctor { Name = "Dr. Noor", Specialization = "Cardiologist", Experience = 15 },
            new Doctor { Name = "Dr. Ashfaq", Specialization = "Dermatologist", Experience = 10 },
            new Doctor { Name = "Dr. Vijay", Specialization = "Neurologist", Experience = 20 }
        };

        foreach (var doctor in doctors)
        {
            Console.WriteLine(doctor);
        }
    }
}
