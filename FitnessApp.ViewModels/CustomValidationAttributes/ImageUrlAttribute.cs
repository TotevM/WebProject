using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class ImageUrlAttribute : ValidationAttribute, IClientModelValidator
{
    private static readonly string[] ValidImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg" };

    public ImageUrlAttribute(string errorMessage = "Please provide a valid image URL or leave it blank")
        : base(errorMessage)
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return ValidationResult.Success;
        }

        string url = value.ToString()!;

        // Check if URL is valid
        if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) ||
            !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            return new ValidationResult(ErrorMessage);
        }

        // Check if URL has a valid image extension
        if (!IsImageUrl(url))
        {
            return new ValidationResult(ErrorMessage);
        }

        // Verify if URL exists and returns an image
        try
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);

            using var request = new HttpRequestMessage(HttpMethod.Head, uriResult);
            var response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                return new ValidationResult(ErrorMessage);
            }

            var contentType = response.Content.Headers.ContentType?.MediaType;
            if (string.IsNullOrEmpty(contentType) || !contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        catch (Exception)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }

    private bool IsImageUrl(string url)
    {
        string extension = Path.GetExtension(url).ToLower();
        return Array.Exists(ValidImageExtensions, ext => ext == extension);
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.Attributes["data-val"] = "true";
        context.Attributes["data-val-imageurl"] = ErrorMessage ?? "Please provide a valid image URL or leave it blank";
    }
}