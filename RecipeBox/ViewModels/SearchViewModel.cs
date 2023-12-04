using System.ComponentModel.DataAnnotations;

namespace RecipeBox.ViewModels
{
  public class SearchViewModel
  {
    [Required(ErrorMessage = "You must enter an ingredient.")]
    public string SearchedIngredient { get; set; }

  }
}