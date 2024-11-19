﻿namespace FitnessApp.Infrastructure.Extensions
{
	using System.Security.Claims;

	public static class ClaimsPrincipalExtensions
	{
		public static string? GetUserId(this ClaimsPrincipal? userClaimsPrincipal)
		{
			return userClaimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;
		}
	}
}