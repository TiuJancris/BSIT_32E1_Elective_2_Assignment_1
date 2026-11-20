using System.ComponentModel.DataAnnotations;

namespace AssignmentApp.Models;

public class Course
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Course title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Course title must be between 3 and 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Course code is required.")]
    public string Code { get; set; } = string.Empty;

    [Range(1, 6, ErrorMessage = "Units must be between 1 and 6.")]
    public int Units { get; set; } = 3;
}
