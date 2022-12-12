namespace Notifcations.Utlties.Services {
    public interface IServices {
        Task<bool> EmailTakenByAnotherUser(string email);
        Task<bool> RoleIsExist(string role);
    }
}
