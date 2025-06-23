namespace LibraryOperation.Application.Dtos.User;

public class CreateProfileDto
{
    public string Name { set; get; }
    public string Email { set; get; }
    public string Phone { set; get; }
    public string Password { set; get; }
    public string Role { set; get; }
}