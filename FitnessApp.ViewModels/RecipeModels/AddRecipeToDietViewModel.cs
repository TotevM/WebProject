using Microsoft.AspNetCore.Mvc.Rendering;

public class AddRecipeToDietViewModel
{
	public Guid RecipeId { get; set; }
	public IEnumerable<SelectListItem>? Diets { get; set; } // Dropdown list of existing diets
	public Guid SelectedDietId { get; set; } // To store the selected diet
}
