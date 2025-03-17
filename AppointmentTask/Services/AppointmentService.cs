using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentTask.DTOs;
using AppointmentTask.Models;
using AppointmentTask.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTask.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentService(IAppointmentRepository appointmentRepository, UserManager<IdentityUser> userManager)
        {
            _appointmentRepository = appointmentRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task<bool> CreateAppointmentAsync(AppointmentDTO appointmentDto)
        {
            var doctor = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == appointmentDto.DoctorId);

            if (doctor == null || !(await _userManager.IsInRoleAsync(doctor, "Doctor")))
            {
                return false; // ❌ Doctor does not exist or is not a Doctor
            }

            var existingAppointment = await _appointmentRepository.GetAppointmentByTimeAsync(appointmentDto.AppointmentTime);
            if (existingAppointment != null)
            {
                return false; // ❌ Time slot already taken
            }

            var appointment = new Appointment
            {
                DoctorId = appointmentDto.DoctorId,
                AppointmentTime = appointmentDto.AppointmentTime,
                Status = AppointmentStatus.Pending
            };

            // ✅ Ensure either PatientId or GuestEmail is assigned
            if (!string.IsNullOrEmpty(appointmentDto.PatientId))
            {
                appointment.PatientId = appointmentDto.PatientId;
            }
            else if (!string.IsNullOrEmpty(appointmentDto.Email))
            {
                appointment.GuestEmail = appointmentDto.Email;
            }
            else
            {
                return false; // ❌ Invalid request: No PatientId or Email
            }

            return await _appointmentRepository.CreateAppointmentAsync(appointment);
        }

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            return await _appointmentRepository.DeleteAppointmentAsync(id);
        }
    }
}
