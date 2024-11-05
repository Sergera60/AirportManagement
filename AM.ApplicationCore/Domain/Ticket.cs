using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; }
        public string Siege { get; set; }
        public bool VIP { get; set; }

        public virtual  Flight flight { get; set; }

        [ForeignKey("flight")]
        public int FlightFK { get; set; }

        public virtual Passenger passenger { get; set; }

        [ForeignKey("Passanger")]
        public int PassengerFK { get; set; }




    }
}
