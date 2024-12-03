using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AM.UI.WEB.Controllers
{
    public class PlaneController : Controller
    {

        IServiceFlight sf;
        IServicePlane sp;

        public PlaneController(IServiceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }


        // GET: PlaneController
        public ActionResult Index()
        {

            return View(sp.GetMany());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {

            return View(sp.GetById(id));
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            ViewBag.PlaneType =
new SelectList(sp.GetMany(), "PlaneType", "Information");
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane collection, IFormFile PilotImage)
        {
            try
            {
                sp.Add(collection);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.PlaneType =
new SelectList(sp.GetMany(), "PlaneType", "Information");

            return View(sp.GetById(id));
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Plane collection, IFormFile PilotImage)
        {
            try
            {
                var plane = sp.GetById(id);
                plane.Capacity = collection.Capacity;
                plane.ManufactureDate = collection.ManufactureDate;
                plane.PlaneType = collection.PlaneType;
                sp.Update(plane);
                sp.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
          
            return View(sp.GetById(id));
        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Plane collection)
        {
            try
            {
                var flight = sp.GetById(id);
                sp.Delete(flight);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
