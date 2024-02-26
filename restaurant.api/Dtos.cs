using System.ComponentModel.DataAnnotations;

namespace restaurant.api.Dtos;

public record DishDto(
    int Id,
    string Name,
    string Type,
    decimal Price,
    string ImageUri
);

public record CreateDishDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string Type,
    [Required] [Range(1, 10000)] decimal Price,
    [Required] [StringLength(200)] string ImageUri
);

public record UpdateDishDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string Type,
    [Required] [Range(1, 10000)] decimal Price,
    [Required] [StringLength(200)] string ImageUri
);