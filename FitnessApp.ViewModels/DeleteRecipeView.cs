﻿namespace FitnessApp.ViewModels;


public class DeleteRecipeView
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string? ImageUrl { get; set; } = null!;
}