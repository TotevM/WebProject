namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class DietFood
    {
        public Guid DietId { get; set; }
        public Diet Diet { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
