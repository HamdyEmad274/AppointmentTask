﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentTask.Models;

namespace AppointmentTask.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task<List<Appointment>> GetAppointmentsByPatientIdAsync(string patientId);

        Task<Appointment?> GetAppointmentByTimeAsync(DateTime timeSlot);
        Task<bool> CreateAppointmentAsync(Appointment appointment);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}
