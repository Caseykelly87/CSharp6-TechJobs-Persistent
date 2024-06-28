using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent;

public class AddEmployerViewModel
{
    [Required(ErrorMessage = "Employer name required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Employer location required")]
    public string Location { get; set; }

}
