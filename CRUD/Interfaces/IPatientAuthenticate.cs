using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Interfaces
{
    public interface IPatientAuthenticate
    {
        public void AddPatient(string name, string phone, int age);
        public void ViewAllPatients();
        public void ViewPatient(int id);
        public void UpdatePatientPhone(int id, string newPhone, bool isStaff);
    }
}
