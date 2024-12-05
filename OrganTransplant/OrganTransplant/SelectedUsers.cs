using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganTransplant
{
    internal class SelectedUsers
    {
        public Persons SelectedDonor { get; private set; }
        public Persons SelectedBernt { get; private set; }
        public Doctor SelectedDoctor { get; private set; }

        public SelectedUsers()
        {

        }
        public SelectedUsers(Persons bernt)
        {
            SelectedBernt = bernt;
        }

        public void SelectDonor(List<Persons> donors)
        {
            Console.Clear();
            Console.WriteLine("Select a Donor:");
            for (int i = 0; i < donors.Count; i++)
            {
                var donor = donors[i];
                Console.WriteLine($"{i + 1}. {donor.GetFirstName()} {donor.GetLastName()} (Success Ratio: {donor.GetDonorSuccessRatio()}%)");
            }
            Console.WriteLine($"{donors.Count + 1}. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            if (choice > 0 && choice <= donors.Count)
            {
                SelectedDonor = donors[choice - 1];
                Console.WriteLine($"Selected Donor: {SelectedDonor.GetFirstName()} {SelectedDonor.GetLastName()}");
            }
            else
            {
                Console.WriteLine("Invalid choice or operation cancelled.");
            }
        }

        public void SelectDoctor(List<Doctor> doctors)
        {
            Console.Clear();
            Console.WriteLine("Select a Doctor:");
            for (int i = 0; i < doctors.Count; i++)
            {
                var doctor = doctors[i];
                Console.WriteLine($"{i + 1}. {doctor.GetDoctorName()} {doctor.GetDoctorLastName()} (Skill Level: {doctor.GetDoctorSuccessRatio()}%)");
            }
            Console.WriteLine($"{doctors.Count + 1}. Cancel");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice > 0 && choice <= doctors.Count)
            {
                SelectedDoctor = doctors[choice - 1];
                Console.WriteLine($"Selected Doctor: {SelectedDoctor.GetDoctorName()} {SelectedDoctor.GetDoctorLastName()}");
            }
            else
            {
                Console.WriteLine("Invalid choice or operation cancelled.");
            }
        }

        public Persons GetSelectedDonor()
        {
            return SelectedDonor;
        }

        public Doctor GetSelectedDoctor()
        {
            return SelectedDoctor;
        }

        public Persons GetBernt()
        {
            return SelectedBernt;
        }
    }
}