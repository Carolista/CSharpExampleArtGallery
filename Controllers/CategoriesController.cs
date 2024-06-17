using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

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
            Category category = new()
            {
                Title = addCategoryViewModel.Title
            };
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
        foreach (int id in categoryIds)
        {
            Category? theCategory = context.Categories.Find(id);
            if (theCategory != null)
            {
                context.Categories.Remove(theCategory);
            }
        }
        context.SaveChanges();
        return Redirect("/categories");
    }

}
