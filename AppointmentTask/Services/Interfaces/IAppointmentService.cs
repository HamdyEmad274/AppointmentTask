using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentTask.DTOs;
using AppointmentTask.Models;

namespace AppointmentTask.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task<List<AppointmentDTO>> GetAppointmentsByPatientIdAsync(string patientId);
        Task<bool> CancelAppointmentAsync(int appointmentId, string patientId);


        Task<bool> CreateAppointmentAsync(AppointmentDTO appointment);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}
