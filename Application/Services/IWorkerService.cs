using Application.Models.DTOs.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IWorkerService
    {
        Task<bool> RejectWorkAsync(RejectWorkRequest request);
        Task<bool> AcceptWorkAsync(AcceptWorkRequest request);
        Task<bool> SetWorkDoneAsync(SetWorkDoneRequest request);
        Task<ProfileDTO?> GetWorkerProfile(string email);
        IEnumerable<RequestDTO> SeeInactiveRequests(string email);
        IEnumerable<RequestDTO> SeeActiveRequests(string email);
        Task<bool> RegisterInNewCategory(CategoryRegisterRequest request);
        IEnumerable<RequestDTO> SeeCompletedTasks(string email);
    }
}
