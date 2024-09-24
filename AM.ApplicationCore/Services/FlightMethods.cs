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
        public List<Flight> GetFlights(string filterType, string filterValue)
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
        }
        public List<DateTime> GetFlightDates(string destination)
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







    }
}
