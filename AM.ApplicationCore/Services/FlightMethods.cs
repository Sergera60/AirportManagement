using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {

       public List<Flight> Flights { get; set; }= new List<Flight>();
        /*public List<Flight> GetFlights(string filterType, string filterValue)
        {
            var filteredFlights = Flights.Where(flight =>
            {
                // Get the property of the Flight class by its name (filterType)
                var property = flight.GetType().GetProperty(filterType);
                if (property != null)
                {
                    // Get the value of the property and compare it with filterValue
                    var value = property.GetValue(flight)?.ToString();
                    return value == filterValue;
                }
                return false;
            }).ToList();
            return filteredFlights;
        }*/
        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            return Flights.Where(flight =>
            {
                var property = flight.GetType().GetProperty(filterType);
                return property != null && property.GetValue(flight)?.ToString() == filterValue;
            }).ToList();
        }

       /* public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            Console.WriteLine("---------------------using for loop ----------------------------");
            // Using a for loop to iterate over the list of flights
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    flightDates.Add(Flights[i].FlightDate);
                }
            }

            Console.WriteLine("---------------------using foreach ----------------------------");
            //using foreach 
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    flightDates.Add(flight.FlightDate);
                }
            }   
            return flightDates;
        }
       */

        //III Le langage LINQ
        /* public List<DateTime> GetFlightDates(string destination)
         {
             // Use LINQ to filter flights by destination and select the flight dates
             var flightDates = (from flight in Flights
                                where flight.Destination == destination
                                select flight.FlightDate).ToList();

             return flightDates;
         }*/
        public List<DateTime> GetFlightDates(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                          .Select(f => f.FlightDate)
                          .ToList();
        }



        public void ShowFlightDetails(Plane plane)
        {
            // Use LINQ to filter flights by the given plane and select the relevant details
            var flightDetails = from flight in Flights
                                where flight.Plane == plane
                                select new { flight.FlightDate, flight.Destination };

            // Display the flight details (date and destination)
            foreach (var flight in flightDetails)
            {
                Console.WriteLine($"Flight Date: {flight.FlightDate}, Destination: {flight.Destination}");
            }
        }


        /*public int ProgrammedFlightNumber(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);

            // Use LINQ to filter flights within the specified week
            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < endDate);
        }*/

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(7);
            return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < endDate);
        }


        public double DurationAverage(string destination)
        {
            // Use LINQ to calculate the average duration of flights to the specified destination
            return Flights.Where(f => f.Destination == destination)
                          .Average(f => f.EstimatedDuration);
        }


        public List<Flight> OrderedDurationFlights()
        {
            // Use LINQ to order flights by EstimatedDuration in descending order
            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();
        }


        public List<Traveller> SeniorTravellers(Flight flight)
        {
            // Get all travellers and order them by birth date (oldest first)
            return flight.passengers.OfType<Traveller>()
                                    .OrderBy(p => p.BirthDate)
                                    .Take(3)
                                    .ToList();
        } 
        public void DestinationGroupedFlights()
        {
            // Group flights by destination
            var groupedFlights = Flights.GroupBy(f => f.Destination);

            // Display the destination and the list of flight dates
            foreach (var group in groupedFlights)
            {
                Console.WriteLine($"Destination {group.Key}");

                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm}");
                }
            }
        }

        //IV Expressions Lambda / Les méthodes LINQ prédéfinies
        //16
        public delegate void FlightDetailsDel(Plane plane);
        public delegate double DurationAverageDel(string destination);
        //17
        public FlightDetailsDel flightDetailsDelegate;
        public DurationAverageDel durationAverageDelegate;

        // Constructor to assign the delegates
       /* public FlightMethods()
        {
            // Assign ShowFlightDetails to FlightDetailsDel
            flightDetailsDelegate = ShowFlightDetails;

            // Assign DurationAverage to DurationAverageDel
            durationAverageDelegate = DurationAverage;
        }*/
        //18
        public FlightMethods()
        {
            // Lambda expression for FlightDetailsDel
            flightDetailsDelegate = (Plane plane) =>
            {
                var flightDetails = from flight in Flights
                                    where flight.Plane == plane
                                    select new { flight.FlightDate, flight.Destination };

                foreach (var flight in flightDetails)
                {
                    Console.WriteLine($"Flight Date: {flight.FlightDate}, Destination: {flight.Destination}");
                }
            };

            // Lambda expression for DurationAverageDel
            durationAverageDelegate = (string destination) =>
            {
                return Flights.Where(f => f.Destination == destination)
                              .Average(f => f.EstimatedDuration);
            };
        }





    }
}
