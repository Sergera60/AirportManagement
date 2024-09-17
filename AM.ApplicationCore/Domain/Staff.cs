using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff :Passenger
    {
     public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        public long Salary { get; set; }




        public override string ToString()
        {
            return $"{$"Passenger: {FirstName} {LastName}, Passport: {PassportNumber}, Email: {EmailAddress}, Tel: {TelNumber}, BirthDate: {BirthDate.ToShortDateString()}"}, Function: {Function}, Employment Date: {EmployementDate.ToShortDateString()}, Salary: {Salary}";
        }

        public Staff(DateTime birthDate, string passportNumber, string emailAddress, string firstName, string lastName, string telNumber, ICollection<Flight> flights, DateTime employmentDate, string function, long salary)
          : base(birthDate, passportNumber, emailAddress, firstName, lastName, telNumber, flights)
        {
            EmployementDate = employmentDate;
            Function = function;
            Salary = salary;
        }
        public Staff() : base()
        { }


        // i want to inherit the function called PassengerType that print in console I am a passenger I am a Staff Member
        public override void PassengerType()
        {
            Console.WriteLine("I am a passenger ,I am a Staff Member");
            
        }


        // Existing properties...



    }
}