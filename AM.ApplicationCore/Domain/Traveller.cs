using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }



        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Passport: {PassportNumber}, Email: {EmailAddress}, Tel: {TelNumber}, BirthDate: {BirthDate.ToShortDateString()}, HealthInformation: {HealthInformation}, Nationality{Nationality}";
        }



        public Traveller(DateTime birthDate, string passportNumber, string emailAddress, string firstName, string lastName, string telNumber, ICollection<Flight> flights, string healthInformation, string nationality) :
            base(birthDate, passportNumber, emailAddress, firstName, lastName, telNumber, flights)
        {
            HealthInformation = healthInformation;
            Nationality = nationality;


        }
public Traveller() : base()
        { }

        public override void PassengerType()
        {
            Console.WriteLine("I am a passenger ,I am a Traveller");

        }



    }
    
    }
