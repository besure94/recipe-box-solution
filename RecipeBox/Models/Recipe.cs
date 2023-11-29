using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }

    [Required(ErrorMessage = "The recipe must have a name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The recipe must have ingredients.")]
    public string Ingredients { get; set; }

    [Required(ErrorMessage = "The recipe must have instructions.")]
    public string Instructions { get; set; }
    public List<Tag> Tags { get; set; }
  }
}