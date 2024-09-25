using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension 
    {

        public static string UpperFullName(this Passenger passenger)
        {
            if (passenger == null || string.IsNullOrEmpty(passenger.FirstName) || string.IsNullOrEmpty(passenger.LastName))
                return string.Empty;

            string firstName = char.ToUpper(passenger.FirstName[0]) + passenger.FirstName.Substring(1).ToLower();
            string lastName = char.ToUpper(passenger.LastName[0]) + passenger.LastName.Substring(1).ToLower();

            return $"{firstName} {lastName}";
        }
    }
}
