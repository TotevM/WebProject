﻿namespace FitnessApp.ViewModels
{
    public class UserRoleViewModel
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsTrainer { get; set; }
    }
}
