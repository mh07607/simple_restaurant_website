using System.ComponentModel.DataAnnotations;

namespace restaurant.api.Entities;

public class Dish
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20)]
    public required string Type { get; set; }
    
    [Required]
    [Range(1, 10000)]
    public decimal Price { get; set; }
    
    [Url]
    [StringLength(200)]
    public required string ImageUri { get; set; }
}