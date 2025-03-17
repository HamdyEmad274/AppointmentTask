using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using AppointmentTask.Models;
using AppointmentTask.Services;
using AppointmentTask.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentTask.Controllers
{
    [Authorize]  // Require authentication for all actions
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentsController(IAppointmentService appointmentService, UserManager<IdentityUser> userManager)
        {
            _appointmentService = appointmentService;
            _userManager = userManager;
        }

        // ✅ Show all appointments
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return View(appointments);
        }

        [Authorize(Roles = "Patient,Admin")]
        public async Task<IActionResult> Create()
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            ViewBag.Doctors = new SelectList(doctors, "Id", "Email"); // Show doctor emails
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Patient,Admin")]
        public async Task<IActionResult> Create(AppointmentDTO appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(appointmentDto);
            }

            // ✅ Ensure either PatientId (Logged-in) or Email (Guest) is set
            if (User.Identity.IsAuthenticated)
            {
                appointmentDto.PatientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            else if (string.IsNullOrEmpty(appointmentDto.Email))
            {
                ModelState.AddModelError("Email", "Please provide an email if you are not logged in.");
                return View(appointmentDto);
            }

            bool success = await _appointmentService.CreateAppointmentAsync(appointmentDto);

            if (success)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Failed to create appointment.");
            return View(appointmentDto);
        }

        // ✅ Show appointment details
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        // ✅ Show edit form
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        // ✅ Handle appointment update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                bool success = await _appointmentService.UpdateAppointmentAsync(appointment);
                if (success)
                    return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // ✅ Show delete confirmation page
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        // ✅ Handle appointment deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool success = await _appointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
