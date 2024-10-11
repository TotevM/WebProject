namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class Diet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DietFood> DietsFoods { get; set; } = new HashSet<DietFood>();

    }
}
