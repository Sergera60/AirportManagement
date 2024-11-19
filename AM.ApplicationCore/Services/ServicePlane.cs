using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services;

    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    public void DeletePlanes()
    {  // delete planes older than 10 years

        Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);


    }

    public IEnumerable<Flight> GetFlights(int n)
    {

        var e = GetMany().OrderByDescending(p => p.PlaneId)
                        .Take(n)
                        .SelectMany(p => p.flight)
                        .OrderBy(f => f.FlightDate);
        return e;
    }

    public IEnumerable<Passenger> GetPassengers(Plane plane)
        {
           return plane.flight.SelectMany(f => f.Tickets)
                              .Select(p => p.passenger);
        }

    public bool IsAvailablePlane(Flight f, int n)
    {
      
        return f.Plane.Capacity - f.Tickets.Count() >= n;
    }


}

   

