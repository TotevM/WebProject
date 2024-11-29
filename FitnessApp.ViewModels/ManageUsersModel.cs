namespace FitnessApp.ViewModels
{
    public class ManageUsersModel
    {
        public string Id { get; set; } = null!; 
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public List<string> Roles { get; set; } = null!;
    }
}
