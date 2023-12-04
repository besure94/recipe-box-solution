using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using RecipeBox.ViewModels;


namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    public RecipesController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Recipe> model = _db.Recipes.OrderByDescending(r => r.Rating).ToList();
      return View(model);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      if (!ModelState.IsValid)
      {
        return View(recipe);
      }
      else
      {
        _db.Recipes.Add(recipe);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Recipe thisRecipe = _db.Recipes
      .Include(recipe => recipe.JoinEntities)
      .ThenInclude(recipe => recipe.Tag)
      .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [Authorize]
    public ActionResult AddTag(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Category");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddTag(Recipe recipe, int tagId)
    {
      #nullable enable
      RecipeTag? joinEntity = _db.RecipeTags.FirstOrDefault(join => join.RecipeTagId == tagId && join.RecipeId == recipe.RecipeId);
      #nullable disable
      if (joinEntity == null && tagId != 0)
      {
        _db.RecipeTags.Add(new RecipeTag() { TagId = tagId, RecipeId = recipe.RecipeId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = recipe.RecipeId });
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      if (!ModelState.IsValid)
      {
        return View(recipe);
      }
      else
      {
        _db.Recipes.Update(recipe);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      RecipeTag joinEntry = _db.RecipeTags.FirstOrDefault(entry => entry.RecipeTagId == joinId);
      _db.RecipeTags.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult RateRecipe(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult RateRecipe(Recipe recipe)
    {
      if (!ModelState.IsValid)
      {
        return View(recipe);
      }
      else
      {
        _db.Recipes.Update(recipe);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    [Authorize]
    public ActionResult Search()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(SearchViewModel model)
    {
      if (ModelState.IsValid)
      {
        return RedirectToAction("SearchResults", new { searchedIngredient = model.SearchedIngredient });
      }
      else
      {
        return View();
      }
    }

    public ActionResult SearchResults(string searchedIngredient)
    {
      List<Recipe> searchResults = _db.Recipes.Where(r => r.Ingredients.ToLower().Contains(searchedIngredient.ToLower())).ToList();
      return View(searchResults);
    }

  }
}