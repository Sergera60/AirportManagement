// See https://aka.ms/new-console-template for more information



using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");




FlightMethods flightMethods = new FlightMethods();

// Assign the listFlights from TestData to the Flights property of FlightMethods
flightMethods.Flights = TestData.listFlights;


Console.WriteLine(flightMethods);

Console.WriteLine("-----------------------------------------------");









Console.WriteLine("-------------------------------------------------");

var flightsss = flightMethods.GetFlights("Destination", "Paris");


foreach (var item in flightsss)
{
    Console.WriteLine(item.ToString());
}

