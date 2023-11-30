using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace RecipeBox.Models
{
  public class Tag
  {
    public int TagId { get; set; }

    [Required(ErrorMessage = "The tag must have a category.")]
    public string Category { get; set; }
    public List<RecipeTag> JoinEntities { get; }
  }
}