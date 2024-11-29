namespace FitnessApp.ViewModels
{
    public class ManageAdminsViewModel
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public List<string> CurrentRoles { get; set; } =null!;
    }
}
