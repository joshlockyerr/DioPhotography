using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.IO;

public class SportModel : PageModel
{
    public List<string> Images { get; set; } = new List<string>();

    private readonly IWebHostEnvironment _env;

    public SportModel(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void OnGet()
    {
        string imagePath = Path.Combine(_env.WebRootPath, "images", "sport");

        if (Directory.Exists(imagePath))
        {
            Images = Directory.GetFiles(imagePath)
                              .Select(Path.GetFileName) // Extract only file name
                              .Where(file => !string.IsNullOrEmpty(file)) // Remove null or empty values
                              .ToList()!;
        }
    }
}
