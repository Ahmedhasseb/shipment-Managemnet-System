namespace Applcation.Feature.AuthApplacation.Login.LoginDTO
{
    public class LoginResponseDTO
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public string Token { get; set; }
    }
}
