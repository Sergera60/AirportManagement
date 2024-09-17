using System.ComponentModel;

namespace AM.ApplicationCore.Domain
{

    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Passenger> passengers { get; set; }


        public override string ToString()
        {
            return $"Flight: {FlightId} {Destination}, Departure: {Departure}, FlightDate: {FlightDate}, EffectiveArrival: {EffectiveArrival}, EstimatedDuration: {EstimatedDuration}, Plane {Plane}, passengers {passengers}";
        }


        public Flight(string destination, string departure, DateTime flightDate, int flightId, DateTime effectiveArrival, int estimatedDuration, Plane plane, ICollection<Passenger> passengers)
        {
            Destination = destination;
            Departure = departure;
            FlightDate = flightDate;
            FlightId = flightId;
            EffectiveArrival = effectiveArrival;
            EstimatedDuration = estimatedDuration;
            Plane = plane;
            this.passengers = passengers;
        }


        


    }
}