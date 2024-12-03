using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Security.Cryptography;

namespace AM.ApplicationCore.Domain
{

    public class Plane
    {
        [Key]
        [Range(1, int.MaxValue)]
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }        
       public virtual ICollection<Flight> flight { get; set; }
        [NotMapped]
        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }

        public override string ToString()
        {
            return $"Passenger: {PlaneId} {PlaneType}, Capacity: {Capacity}, ManufactureDate: {ManufactureDate}, flight {flight}";
        }
        public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType, ICollection<Flight> flight)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneId = planeId;
            PlaneType = planeType;
            this.flight = flight;
        }

        public Plane()
        {
        }
       
    }


    public enum PlaneType
    {
        Boring,
        Airbus
    }
}