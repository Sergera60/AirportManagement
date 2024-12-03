using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
       static AMContext ctx = new AMContext();
        static IUnitOfWork uow = new UnitOfWork(ctx);
        IServiceFlight sf = new ServiceFlight(uow) ;

        // GET: FlightController
        public ActionResult Index()
        {
            return View(sf.GetMany());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection)
        {
            try
            {
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
            sf.GetById(id);
            if (sf.GetById(id) == null)
            {
                return NotFound();
            }
            return View(sf);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
              var flights = sf.GetById(id);
                flights.Destination = collection.Destination;
                flights.Departure = collection.Departure;
                flights.FlightDate = collection.FlightDate;
                flights.EffectiveArrival = collection.EffectiveArrival;
                flights.EstimatedDuration = collection.EstimatedDuration;
                flights.PlaneId = collection.PlaneId;
                flights.Airline = collection.Airline;
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
            if (sf.GetById(id) == null)
            {
                return NotFound();
            }
            return View();
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
