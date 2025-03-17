using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentTask.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Doctor ID is required.")]
        public string DoctorId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Appointment time is required.")]
        public DateTime AppointmentTime { get; set; }

        // ✅ Either PatientId (Logged-in user) or Email (Guest) should be provided
        public string? PatientId { get; set; }

        [EmailAddress]
        public string? Email { get; set; }  // Guest Email

        public string? Status { get; set; }  // Optional for updates
    }
}
