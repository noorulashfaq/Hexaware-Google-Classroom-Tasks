//using ClinicApp.Exceptions;
//using ClinicApp.Interfaces;
//using ClinicApp.Models;
//using ClinicApp.Services;
//using System;

//namespace ClinicApp
//{
//    internal class Program
//    {
//        IDoctorAuthenticate doctorAuthenticate;
//        DoctorService doctorService;
//        IAdminWork adminWork;
//        public Program()
//        {
//            doctorService = new DoctorService();
//        }
//        void PrintAdminMenu()
//        {
//            Console.WriteLine("1. Login");
//            Console.WriteLine("2. View Doctor Listing");
//            Console.WriteLine("3. Activate/De-Activate Doctor");
//            Console.WriteLine("4. Exit");

//        }
//        void PrintDoctorMenu()
//        {
//            Console.WriteLine("1. Register Doctor");
//            Console.WriteLine("2. Login");
//            Console.WriteLine("3. Exit");
//        }
//        void AdminInteraction()
//        {
//            adminWork = doctorService;
//            int choice = 0;
//            bool isLoggedIn = false;
//            do
//            {
//                PrintAdminMenu();
//                Console.WriteLine("Enter your choice");
//                while (!int.TryParse(Console.ReadLine(), out choice))
//                {
//                    Console.WriteLine("Please enter a valid choice");
//                }
//                switch (choice)
//                {
//                    case 1:
//                        isLoggedIn = AdminLogin(adminWork);
//                        break;
//                    case 2:
//                        if (isLoggedIn)
//                        {
//                            PrintDoctors(adminWork);
//                        }
//                        else
//                        {
//                            Console.WriteLine("Please login to view the doctor listing");
//                        }
//                        break;
//                    case 3:
//                        if (isLoggedIn)
//                        {
//                            ChangeStatus(adminWork);
//                        }
//                        else
//                        {
//                            Console.WriteLine("Please login to change the doctor status");
//                        }
//                        break;
//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }

//            } while (choice != 4);

//        }

//        private void ChangeStatus(IAdminWork adminWork)
//        {
//            Console.WriteLine("Enter Doctor Id");
//            int doctorId;
//            while (!int.TryParse(Console.ReadLine(), out doctorId))
//            {
//                Console.WriteLine("Please enter a valid doctor Id");
//            }
//            Console.WriteLine("Enter Status (Available/NotAvailable)");
//            DoctorStatus status;
//            while (!Enum.TryParse(Console.ReadLine(), out status))
//            {
//                Console.WriteLine("Please enter a valid status");
//            }
//            try
//            {
//                if (adminWork.ChangeDoctorStatus(doctorId, status))
//                {
//                    Console.WriteLine("Doctor status changed successfully");
//                }
//            }
//            catch (CollectionEmptyException cee)
//            {
//                Console.WriteLine(cee.Message);
//            }
//            catch (NoSuchEntityException nsee)
//            {
//                Console.WriteLine(nsee.Message);
//            }
//            catch (InvalidOperationException ioe)
//            {
//                Console.WriteLine(ioe.Message);
//            }
//        }

//        private void PrintDoctors(IAdminWork adminWork)
//        {
//            try
//            {
//                var doctors = adminWork.GetDoctors();
//                foreach (var doctor in doctors)
//                {
//                    Console.WriteLine(doctor);
//                    Console.WriteLine("---------------------");
//                }
//            }
//            catch (CollectionEmptyException cee)
//            {
//                Console.WriteLine(cee.Message);
//            }
//        }

//        private bool AdminLogin(IAdminWork adminWork)
//        {
//            Console.WriteLine("Enter Username");
//            string username = Console.ReadLine() ?? "";
//            Console.WriteLine("Enter Password");
//            string password = Console.ReadLine() ?? "";
//            if (adminWork.AdminLogin(username, password))
//            {
//                Console.WriteLine("Login Successful");
//                return true;
//            }
//            Console.WriteLine("Invalid username or password");
//            return false;

//        }

//        void DoctorInteraction()
//        {
//            doctorAuthenticate = doctorService;
//            int choice = 0;
//            do
//            {
//                PrintDoctorMenu();
//                Console.WriteLine("Enter your choice");
//                while (!int.TryParse(Console.ReadLine(), out choice))
//                {
//                    Console.WriteLine("Please enter a valid choice");
//                }
//                switch (choice)
//                {
//                    case 1:
//                        //doctorAuthenticate.RegisterDoctor();
//                        break;
//                    case 2:
//                        Login(doctorAuthenticate);
//                        break;
//                    case 3:
//                        Console.WriteLine("Exiting from Doctor Interaction");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//            } while (choice != 3);
//        }

//        private void Login(IDoctorAuthenticate doctorAuthenticate)
//        {
//            Console.WriteLine("Enter Doctor Id");
//            int doctorId;
//            while (!int.TryParse(Console.ReadLine(), out doctorId))
//            {
//                Console.WriteLine("Please enter a valid doctor Id");
//            }
//            Console.WriteLine("Enter Password");
//            string password = Console.ReadLine() ?? "";
//            Doctor result = doctorAuthenticate.Login(doctorId, password);
//            if (result != null)
//            {
//                Console.WriteLine("Login Successful");
//                Console.WriteLine("Welcome Doctor. Here are your details");
//                Console.WriteLine(result);
//            }
//            else
//            {
//                Console.WriteLine("Login Failed");
//            }
//        }

//        static void Main(string[] args)
//        {
//            Program program = new Program();
//            program.UserInteraction();

//        }

//        private void UserInteraction()
//        {
//            int choice = 0;
//            do
//            {
//                Console.WriteLine("1. Admin");
//                Console.WriteLine("2. Doctor");
//                Console.WriteLine("3. Exit");
//                Console.WriteLine("Enter your choice");
//                while (!int.TryParse(Console.ReadLine(), out choice))
//                {
//                    Console.WriteLine("Please enter a valid choice");
//                }
//                switch (choice)
//                {
//                    case 1:
//                        AdminInteraction();
//                        break;
//                    case 2:
//                        DoctorInteraction();
//                        break;
//                    case 3:
//                        Console.WriteLine("Exiting from the application");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//            } while (choice != 3);
//        }
//    }
//}

////class Program
////{
////    static void Main()
////    {
////        PatientService patientService = new PatientService();

////        while (true)
////        {
////            Console.WriteLine("Patient Management System");
////            Console.WriteLine("1. Add Patient");
////            Console.WriteLine("2. View All Patients");
////            Console.WriteLine("3. View Single Patient");
////            Console.WriteLine("4. Change Patient Phone (Staff Only)");
////            Console.WriteLine("5. Exit");
////            Console.Write("Enter your choice: ");
////            int choice;

////            if (!int.TryParse(Console.ReadLine(), out choice))
////            {
////                Console.WriteLine("Invalid input! Please enter a number.\n");
////                continue;
////            }

////            switch (choice)
////            {
////                case 1:
////                    Console.Write("Enter Name: ");
////                    string name = Console.ReadLine();
////                    Console.Write("Enter Phone: ");
////                    string phone = Console.ReadLine();
////                    Console.Write("Enter Age: ");
////                    int age = int.Parse(Console.ReadLine());

////                    patientService.AddPatient(name, phone, age);
////                    break;

////                case 2:
////                    patientService.ViewAllPatients();
////                    break;

////                case 3:
////                    Console.Write("Enter Patient ID: ");
////                    int id = int.Parse(Console.ReadLine());
////                    patientService.ViewPatient(id);
////                    break;

////                case 4:
////                    Console.Write("Enter Patient ID: ");
////                    int patientId = int.Parse(Console.ReadLine());
////                    Console.Write("Enter New Phone Number: ");
////                    string newPhone = Console.ReadLine();
////                    Console.Write("Are you staff? (yes/no): ");
////                    bool isStaff = Console.ReadLine().ToLower() == "yes";

////                    patientService.UpdatePatientPhone(patientId, newPhone, isStaff);
////                    break;

////                case 5:
////                    Console.WriteLine("Exiting the system...");
////                    return;

////                default:
////                    Console.WriteLine("Invalid choice! Please try again.\n");
////                    break;
////            }
////        }
////    }
////}
///
class Program
{
	static void Main(string[] args)
	{
		Patient patient1 = Patient.GetInstance(1, "Noor", "1234567890", 21);
		Console.WriteLine(patient1);

		Patient patient2 = Patient.GetInstance(2, "Ashfaq", "0987654321", 20);
		Console.WriteLine(patient1);

		Console.WriteLine(patient1 == patient2);
	}
}