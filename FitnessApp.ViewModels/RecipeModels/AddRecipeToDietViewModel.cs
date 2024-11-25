using Microsoft.AspNetCore.Mvc.Rendering;

public class AddRecipeToDietViewModel
{
	public string RecipeId { get; set; }
	public IEnumerable<SelectListItem>? Diets { get; set; }
	public string SelectedDietId { get; set; }
}
