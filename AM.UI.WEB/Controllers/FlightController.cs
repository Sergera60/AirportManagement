using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
       //static AMContext ctx = new AMContext();
       // static IUnitOfWork uow = new UnitOfWork(ctx);
        IServiceFlight sf ;
        IServicePlane sp;

        public FlightController(IServiceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }



        // GET: FlightController
        public ActionResult Index()
        {
            return View(sf.GetMany());
        }
        public ActionResult Sort()
        {
            return View("Index", sf.SortFlights());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var ser = sf.GetById(id);
            if (ser == null)
            {
                return NotFound();
            }
            return View(ser);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.PlaneId =
new SelectList(sp.GetMany(), "PlaneId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    collection.Pilot = PilotImage.FileName;
                }
                sf.Add(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
           
            ViewBag.PlaneId =
             new SelectList(sp.GetMany(), "PlaneId", "Information");
           
            return View(sf.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection, IFormFile PilotImage)
        {
            try
            {

                var flights = sf.GetById(id);
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    collection.Pilot = PilotImage.FileName;
                }

        
                flights.Destination = collection.Destination;
                flights.Departure = collection.Departure;
                flights.FlightDate = collection.FlightDate;
                flights.EffectiveArrival = collection.EffectiveArrival;
                flights.EstimatedDuration = collection.EstimatedDuration;
                flights.PlaneId = collection.PlaneId;
                flights.Airline = collection.Airline;
                flights.Pilot = collection.Pilot;
                sf.Update(flights);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
          
            return View(sf.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
               var flight =sf.GetById(id);

                if (flight == null) { return NotFound(); }
                sf.Delete(flight);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
