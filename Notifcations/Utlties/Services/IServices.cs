using Notifcations.Models.Entities;

namespace Notifcations.Utlties.Services {
    public interface IServices {
        Task<bool> EmailTakenByAnotherUser(string email);
        Task<bool> RoleIsExist(string role);
        Task<int> CreateMessage(Message message);
        Task<int> CountNotifcationUser(string email);
    }
}
