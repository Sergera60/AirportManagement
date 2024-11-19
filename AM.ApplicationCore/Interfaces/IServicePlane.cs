using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {


        IEnumerable<Passenger> GetPassengers(Plane plane);
        IEnumerable<Flight> GetFlights(int n);
        bool IsAvailablePlane(Flight f , int n);
        void DeletePlanes();
    }
}
