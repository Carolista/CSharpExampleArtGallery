using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

// TODO 10 - Add filtering attributes to prevent all but index from being public
[Route("/categories")]
public class CategoriesController : Controller
{
    private readonly ArtworkDbContext context;

    public CategoriesController(ArtworkDbContext dbContext)
    {
        context = dbContext;
    }

    // Endpoint: GET http://localhost:5xxx/categories
    [HttpGet("")]
    public IActionResult RenderCategoriesPage()
    {
        List<Category> categories = context.Categories.OrderBy(c => c.Title).ToList();
        return View("Index", categories);
    }

    // Endpoint: GET http://localhost:5xxx/categories/add
    [HttpGet("add")]
    public IActionResult RenderAddCategoryForm()
    {
        AddCategoryViewModel addCategoryViewModel = new();
        return View("Add", addCategoryViewModel);
    }

    // Endpoint: POST http://localhost:5xxx/categories/add
    [HttpPost("add")]
    public IActionResult ProcessAddCategoryForm(AddCategoryViewModel addCategoryViewModel)
    {
        if (ModelState.IsValid)
        {
            Category category = new() { Title = addCategoryViewModel.Title };
            context.Categories.Add(category);
            context.SaveChanges();
            return Redirect("/categories");
        }
        return View("Add", addCategoryViewModel);
    }

    // Endpoint: GET http://localhost:5xxx/categories/delete
    [HttpGet("delete")]
    public IActionResult RenderDeleteCategoriesForm()
    {
        List<Category> categories = context.Categories.OrderBy(c => c.Title).ToList();
        return View("Delete", categories);
    }

    // Endpoint: POST http://localhost:5xxx/categories/delete
    [HttpPost("delete")]
    public IActionResult ProcessDeleteCategoriesForm(int[] categoryIds)
    {
        IQueryable<Category> allCategories = context.Categories.Include(c => c.Artworks);
        List<int> errorIds = [];

        foreach (int id in categoryIds)
        {
            Category? theCategory = allCategories.Single(c => c.Id == id);
            if (theCategory != null)
            {
                if (theCategory.Artworks.Count == 0)
                {
                    context.Categories.Remove(theCategory);
                }
                else
                {
                    errorIds.Add(id);
                }
            }
        }
        context.SaveChanges();
        if (errorIds.Count > 0)
        {
            ViewBag.ErrorIds = errorIds;
            string errorText =
                errorIds.Count == 1 ? "1 category was" : (errorIds.Count + " categories were");
            ViewData["ErrorMessage"] =
                "WARNING: "
                + errorText
                + " unable to be deleted due to existing related artwork records, as indicated below.";
        }
        return View("Index", allCategories.ToList());
    }
}
