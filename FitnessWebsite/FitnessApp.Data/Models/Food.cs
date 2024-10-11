namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
        public virtual ICollection<DietFood> DietsFoods { get; set; } = new HashSet<DietFood>();

    }
}
