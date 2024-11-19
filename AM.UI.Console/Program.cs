// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Numerics;

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


//III Le langage LINQ
Console.WriteLine("-------------------------------------------------");
var parisFlightDates = flightMethods.GetFlightDates("Paris");
Console.WriteLine("Flight dates to Paris:");
foreach (var date in parisFlightDates)
{
    Console.WriteLine(date);
}

// Test ShowFlightDetails method for a specific plane (e.g., Airbusplane)
Console.WriteLine("\nFlight details for Airbusplane:");
flightMethods.ShowFlightDetails(TestData.Airbusplane);




// Example 11 - Programmed flights within a week from a start date
int flightCount = flightMethods.ProgrammedFlightNumber(new DateTime(2022, 05, 01));
Console.WriteLine($"Flights in the week: {flightCount}");

// Example 12 - Average duration of flights to Paris
double averageDuration = flightMethods.DurationAverage("Paris");
Console.WriteLine($"Average flight duration to Paris: {averageDuration}");

// Example 13 - Flights ordered by estimated duration
var orderedFlights = flightMethods.OrderedDurationFlights();
Console.WriteLine("\nFlights ordered by duration:");
foreach (var flight in orderedFlights)
{
    Console.WriteLine($"{flight.Destination} - Duration: {flight.EstimatedDuration} minutes");
}

// Example 14 - Top 3 oldest travellers on a flight
/*var seniorTravellers = flightMethods.SeniorTravellers(TestData.flight1);
Console.WriteLine("\nTop 3 oldest travellers on flight1:");
foreach (var traveller in seniorTravellers)
{
    Console.WriteLine($"{traveller.FirstName} {traveller.LastName} - Birth Date: {traveller.BirthDate}");
}
*/
// Example 15 - Group flights by destination and display details
Console.WriteLine("\nFlights grouped by destination:");
flightMethods.DestinationGroupedFlights();
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");

//IV Expressions Lambda / Les méthodes LINQ prédéfinies
flightMethods.Flights.Add(new Flight
{
    Destination = "Paris",
    FlightDate = new DateTime(2022, 05, 01, 12, 10, 0),
    EstimatedDuration = 120,
    Plane = TestData.Airbusplane
});
flightMethods.Flights.Add(new Flight
{
    Destination = "Madrid",
    FlightDate = new DateTime(2022, 05, 02, 13, 00, 0),
    EstimatedDuration = 180,
    Plane = TestData.BoingPlane
});

// Test FlightDetailsDel delegate
Console.WriteLine("Testing FlightDetailsDel:");
flightMethods.flightDetailsDelegate(TestData.Airbusplane);

// Test DurationAverageDel delegate
Console.WriteLine("\nTesting DurationAverageDel:");
double avgDuration = flightMethods.durationAverageDelegate("Paris");
Console.WriteLine($"Average flight duration to Paris: {avgDuration}");


//V Les méthodes d’extension
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("-------------------------------------------------");
Passenger passenger = new Passenger
{
    FirstName = "john",
    LastName = "doe"
};

// Utilisation de la méthode d'extension UpperFullName
string formattedName = passenger.UpperFullName();
Console.WriteLine(formattedName); // Affiche : John Doe


AMContext context = new AMContext();
//generate a context.Flights.Add()


/*context.Flights.Add(new Flight
{
    Destination = "Paris",
    FlightDate = new DateTime(2022, 05, 01, 12, 10, 0),
    EstimatedDuration = 120,
    Plane = TestData.Airbusplane,
    Airline = "yeey",
    Departure = "Lagos",
    EffectiveArrival = new DateTime(2022, 05, 01, 14, 10, 0),
});









context.SaveChanges();*/
Console.WriteLine("-------------------------------------------------");
Console.WriteLine(context.Flights.First().Plane.Capacity);


/////////////////////////////////////////////////////////
IUnitOfWork uow = new UnitOfWork(context);
IServiceFlight f = new ServiceFlight(uow);
IServicePlane p = new ServicePlane(uow);
IServicePassanger pass  = new ServicePassanger(uow);





