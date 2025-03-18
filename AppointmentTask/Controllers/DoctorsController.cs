using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentTask.Data;
using AppointmentTask.Models;

[Authorize(Roles = "Doctor")]
public class DoctorsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public DoctorsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var doctorId = _userManager.GetUserId(User);
        var doctor = await _userManager.FindByIdAsync(doctorId);

        if (doctor == null)
        {
            return Unauthorized();
        }

        var appointments = await _context.Appointments
            .Include(a => a.Patient) 
            .Where(a => a.DoctorId == doctorId)
            .ToListAsync();

        return View(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var doctorId = _userManager.GetUserId(User);
        var doctor = await _userManager.FindByIdAsync(doctorId);

        if (doctor == null)
        {
            return Unauthorized();
        }

        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }

        if (appointment.DoctorId != doctorId)
        {
            return Unauthorized();
        }

        if (!Enum.TryParse(status, out AppointmentStatus newStatus) || !Enum.IsDefined(typeof(AppointmentStatus), newStatus))
        {
            return BadRequest("Invalid status.");
        }

        appointment.Status = newStatus;
        _context.Update(appointment);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
