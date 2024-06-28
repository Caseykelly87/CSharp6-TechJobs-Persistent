using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent;

public class AddJobViewModel
{
    [Required(ErrorMessage = "Job name required")]
    public string Name { get; set; }

    public int EmployerId { get; set; }

    public List<SelectListItem>? Employers { get; set; }

    public AddJobViewModel(List<Employer> employers)
    {
        Employers = new List<SelectListItem>();

        foreach (var e in employers)
        {
            Employers.Add(
                new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                }
            );
        }
    }

    public AddJobViewModel()
    {
    }
}

