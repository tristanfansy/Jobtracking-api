using System.ComponentModel.DataAnnotations;

public class CreateDto()
{
    [Required]
    [StringLength(100)]
    public string name {get;set;} ="";
    [Required]
    public int age{get;set;}
    [Required]
    [StringLength(100)]
    public string position{get;set;} ="";
    
}