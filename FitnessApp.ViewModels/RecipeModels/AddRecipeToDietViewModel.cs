using Microsoft.AspNetCore.Mvc.Rendering;

public class AddRecipeToDietViewModel
{
	public Guid RecipeId { get; set; }
	public IEnumerable<SelectListItem>? Diets { get; set; }
	public Guid SelectedDietId { get; set; }
}
