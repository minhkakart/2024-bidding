namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class User
{
    /*public int Id { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    */
    public int user_id { get; set; }
    public int group_id { get; set; }
    public string? username { get; set; }

	[JsonIgnore]
    public string? PasswordHash { get; set; }
}