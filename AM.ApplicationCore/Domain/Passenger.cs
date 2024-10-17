using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;

namespace AM.ApplicationCore.Domain
{

    public class Passenger
    {
        // public int ID { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public FullName FullName { get; set; }

        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long")]
        [MaxLength(25, ErrorMessage = "First Name cannot exceed 25 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression(@"\d{8}", ErrorMessage = "TelNumber must be exactly 8 digits")]
        public string TelNumber { get; set; }
        public ICollection<Flight> flights { get; set; }


        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Passport: {PassportNumber}, Email: {EmailAddress}, Tel: {TelNumber}, BirthDate: {BirthDate.ToShortDateString()}";
        }
        public Passenger(DateTime birthDate, string passportNumber, string emailAddress, string firstName, string lastName, string telNumber, ICollection<Flight> flights)
        {
            BirthDate = birthDate;
            PassportNumber = passportNumber;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            TelNumber = telNumber;
            this.flights = flights;
        }
        public Passenger()
        {
        }


        public bool CheckProfile(string firstName, string lastName)
        {
            if (firstName == FirstName && lastName == LastName)
            {
                return true;
            }
            return false;
        }
        public bool CheckProfile(string firstName ,string lastName ,string emailAddress )
        {

            if ( firstName == FirstName && lastName == LastName && emailAddress==EmailAddress)
            {
                return true;
            }

            return false;
        }

        public bool CheckProfile2(string lastName, string firstName, string email)
        {
            if (email == null)
            {
               return CheckProfile(firstName, lastName);
            }
            else
            {
                return CheckProfile(lastName,firstName,email) ;
            }
        }

        //generate a method that will be in inherited in other classes that print in console i am a passenger
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }



    }
}