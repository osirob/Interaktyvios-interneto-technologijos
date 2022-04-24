namespace Triperis.Models
{
    public class AppUserRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool CanCreateListings { get; set; }
        //TODO: add roles
    }
}
