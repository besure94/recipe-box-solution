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

    // [Required(ErrorMessage = "You must enter a rating to proceed.")]
    // [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int Rating { get; set; }
    public List<RecipeTag> JoinEntities { get; }
  }
}