using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
{
  public class TagsController : Controller
  {
    private readonly RecipeBoxContext _db;
    public TagsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Tags.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Tag tag)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
        return View(tag);
      }
      else
      {
        _db.Tags.Add(tag);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

  }
}