using ClinicApp.Exceptions;
using ClinicApp.Interfaces;

class PatientService : IPatientAuthenticate
{
    private List<Patient> patients = new List<Patient>();
    private int nextId = 1;

    public void AddPatient(string name, string phone, int age)
    {
        patients.Add(new Patient(nextId++, name, phone, age));
        Console.WriteLine("Patient added successfully!\n");
    }

    public void ViewAllPatients()
    {
        if (patients.Count == 0)
        {
            throw new CollectionEmptyException("No patients are available in the system");
            return;
        }

        Console.WriteLine("List of Patients:");
        foreach (var patient in patients)
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Phone: {patient.Phone}, Age: {patient.Age}");
        }
        Console.WriteLine();
    }

    public void ViewPatient(int id)
    {
        Patient patient = patients.Find(p => p.Id == id);
        if (patient == null)
        {
            throw new NoSuchEntityException("Patient with the given Id is not available in the system");
            return;
        }
        Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Phone: {patient.Phone}, Age: {patient.Age}\n");
    }

    public void UpdatePatientPhone(int id, string newPhone, bool isStaff)
    {
        if (!isStaff)
        {
            Console.WriteLine("Permission Denied! Only staff can change phone numbers.\n");
            return;
        }

        Patient patient = patients.Find(p => p.Id == id);
        if (patient == null)
        {
            Console.WriteLine("Patient not found.\n");
            return;
        }

        patient.Phone = newPhone;
        Console.WriteLine("Patient phone number updated successfully!\n");
    }
}
