namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class UserDiet
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Guid DietId { get; set; }

        public virtual Diet Diet { get; set; }
    }
}
