using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentTask.Models;
using AppointmentTask.Repositories;

namespace AppointmentTask.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task<bool> CreateAppointmentAsync(Appointment appointment)
        {
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
