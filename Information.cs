using System;

namespace UniversityApp
{
    public class Information : IInformation
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public long EGN { get; set; }

        public string Gender { get; set; }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            if ((today.Day < birthDate.Day && today.Month <= birthDate.Month) || today.Month < birthDate.Month)
            {
                age -= 1;
            }

            return age;
        }
    }
}
