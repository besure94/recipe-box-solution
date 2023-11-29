using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace RecipeBox.Models
{
  public class Tag
  {

    [Range(1, int.MaxValue, ErrorMessage = "You must add your tag to a recipe. Have you created a recipe yet?")]
    public int RecipeId { get; set; }
    public int TagId { get; set; }
    public string Name { get; set; }
    public Recipe Recipe { get; set; }
  }
}