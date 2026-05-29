using DMS.Models;
using DMS.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DMS.Controllers
{
    public class LocationController : Controller
    {
        private readonly EFCtx _db;
       // private readonly Database _ef;

        public LocationController(EFCtx db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"]?.ToString();
            var locations = _db.Locations.ToList();
            return View(locations);
        }


        public IActionResult create()
        {

            return View();
        }

        public IActionResult Update(int id)
        {
            var location = _db.Locations.Where(l => l.LoID == id).FirstOrDefault();

            if (location == null)
            {
                return NotFound(); 
            }
            return View(location); 
        }

        public IActionResult LoList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getLoData()

        {
            var abc = _db.Locations.ToList();
            return Json(new { xyz = abc });
        }

        [HttpPost]
        public IActionResult submitupdate([FromBody] LocVM lo)
        {
            try
            {
                var existingLocation = _db.Locations.FirstOrDefault(x => x.LoID == lo.LID);
                if (existingLocation != null)
                {
                    existingLocation.ShortName = lo.SNm;
                    existingLocation.FullName = lo.FNm;
                    existingLocation.LoCode = lo.LCd;

                    _db.SaveChanges();
                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Location not found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        public IActionResult save([FromBody] LocVM lo)
        {
            try
            {
                Location loc = new Location();
                loc.ShortName = lo.SNm;
                loc.FullName   = lo.FNm;
                loc.LoCode = lo.LCd;
                _db.Locations.Add(loc);
                _db.SaveChanges();
                return Json(new { success = true, msg = "Sucess" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "An error occured" });
            }

        }

        [HttpDelete]
        [Route("location/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var location = _db.Locations.FirstOrDefault(l => l.LoID == id);
                if (location != null)
                {
                    _db.Locations.Remove(location);
                    _db.SaveChanges();
                    return Json(new { success = true, msg = "Deleted successfully." });
                }
                return Json(new { success = false, msg = "Location not found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "Error: " + ex.Message });
            }
        }
    }
}
