using BCrypt.Net;

namespace Helper
{
    public static class PasswordHelper
    {
        public static String HashPassword(String password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool verifyPassword(String password, String hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
