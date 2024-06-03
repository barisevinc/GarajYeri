using GarajYeri.Data;
using GarajYeri.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarajYeri.Web.Controllers
{
    public class VehicleProcessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleProcessController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _context.VehicleProcesses.Where(vp => vp.IsDeleted == false) });
            

        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.VehicleProcesses.Find(id));

        }

        [HttpPost]
        public IActionResult HArdDelete(VehicleProcess vehicleProcess)
        {
            _context.VehicleProcesses.Remove(vehicleProcess);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var vehicleProcess=_context.VehicleProcesses.Find(id);

            if(vehicleProcess != null)
            {
                vehicleProcess.IsDeleted = true;
                _context.VehicleProcesses.Update(vehicleProcess);
                try
                {
                    _context.SaveChanges();
                    return Ok(vehicleProcess);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                return BadRequest("Gönderilen ID geçersizdir");
            }
            
        }

        [HttpPost]
        public IActionResult Update(VehicleProcess vehicleProcess)
        {
            _context.VehicleProcesses.Update(vehicleProcess);
            _context.SaveChanges(); 
            return Ok(vehicleProcess);
        }

        [HttpPost]
        public IActionResult Add(VehicleProcess vehicleProcess)
        {
            _context.VehicleProcesses.Add(vehicleProcess);
            _context.SaveChanges();
            return Ok(vehicleProcess);
        }
    }
}
