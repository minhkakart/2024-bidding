namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UserCreateRequest
{
    /*[Required]
    public string? Title { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    [EnumDataType(typeof(Role))]
    public string? Role { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [MinLength(6)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }*/

    [Required]
    public int? group_id { get; set; }

    [Required]
    public string? username { get; set; }

	[Required]
	[MinLength(6)]
	public string? password { get; set; }

	[Required]
	[Compare("password")]
	public string? ConfirmPassword { get; set; }

}