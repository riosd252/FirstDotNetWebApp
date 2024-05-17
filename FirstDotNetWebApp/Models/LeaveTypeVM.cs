using System.ComponentModel.DataAnnotations;

namespace FirstDotNetWebApp.Models;

public class LeaveTypeVM
{
    public int Id { get; set; }
    [Display(Name = "Leave Type Name")]
    [Required]
    public string Name { get; set; }
    [Display(Name = "Default Number of Days")]
    [Required]
    [Range(1, 20, ErrorMessage = "Only values from 1 to 20 are allowed.")]
    public int DefaultDays { get; set; }
}