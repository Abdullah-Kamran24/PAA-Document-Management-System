using DMS.Models;
using DMS.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS.Controllers
{
    public class MOController : Controller
    {
        private readonly EFCtx _db;

        public MOController(EFCtx db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"]?.ToString();
            var mainOffices = _db.MainOffices
                                 .Include(mo => mo.Location)
                                 .ToList();

            return View(mainOffices);
        }

        public IActionResult Create()
        {
            var locations = _db.Locations.ToList();
            return View(locations);
        }

        public IActionResult Update(int id)
        {
            var office = _db.MainOffices.FirstOrDefault(m => m.MoID == id);
            if (office == null)
                return NotFound();

            ViewBag.LocationList = _db.Locations.ToList();
            return View(office);
        }

        public IActionResult MoList()
        {
            return View();
        }

        [HttpGet]
        [Route("MO/GetMoData")]
        public IActionResult GetMoData()
        {
            var mos = _db.MainOffices
                         .Include(m => m.Location)
                         .ToList()
                         .Select(m => new
                         {
                             m.MoID,
                             m.MoCode,
                             m.ShortName,
                             m.FullName,
                             LocationName = m.Location != null ? m.Location.ShortName : "N/A"
                         });

            return Json(new { records = mos });
        }

        [HttpPost]
        public IActionResult Save([FromBody] MoVM mo)
        {
            try
            {
                MainOffice newMo = new MainOffice
                {
                    ShortName = mo.SNm,
                    FullName = mo.FNm,
                    MoCode = mo.MCd,
                    LoId = mo.LoId
                };

                _db.MainOffices.Add(newMo);
                _db.SaveChanges();

                return Json(new { success = true, msg = "Saved successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "Error: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SubmitUpdate([FromBody] MoVM mo)
        {
            try
            {
                var main = _db.MainOffices.FirstOrDefault(x => x.MoID == mo.MID);
                if (main != null)
                {
                    main.MoCode = mo.MCd;
                    main.ShortName = mo.SNm;
                    main.FullName = mo.FNm;
                    main.LoId = mo.LoId;

                    _db.SaveChanges();
                    return Json(new { success = true, msg = "Updated successfully." });
                }

                return Json(new { success = false, msg = "Main Office not found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "Error: " + ex.Message });
            }
        }

        [HttpDelete]
        [Route("mo/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var office = _db.MainOffices.FirstOrDefault(m => m.MoID == id);
                if (office != null)
                {
                    _db.MainOffices.Remove(office);
                    _db.SaveChanges();
                    return Json(new { success = true, msg = "Main Office deleted successfully." });
                }
                return Json(new { success = false, msg = "Main Office not found." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "Error: " + ex.Message });
            }
        }

    }
}