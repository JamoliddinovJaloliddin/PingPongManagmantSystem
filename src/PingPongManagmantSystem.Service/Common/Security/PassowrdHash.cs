namespace PingPongManagmantSystem.Service.Common.Security
{
    public static class PassowrdHash
    {
        public static (string Salt, string Hash) Hash(string passowrd)
        {
            try
            {
                string salt = Guid.NewGuid().ToString();
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(passowrd + salt);
                return (Salt: salt, Hash: passwordHash);
            }
            catch
            {
                return (Salt: "", Hash: "");
            }
        }

        public static bool Verify(string password, string hash, string salt)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password + salt, hash);
            }
            catch
            {
                return false;
            }
        }
    }
}
