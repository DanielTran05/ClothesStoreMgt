namespace ClothesStore.DTO.UserDto
{
    public class UserLoginRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public UserLoginRequest() { }

        public UserLoginRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}