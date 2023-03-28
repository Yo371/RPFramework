namespace RPFramework.Models.ui
{
    public static class UserFactory
    {
        public static User GetAdminUser()
        {
            return new User()
            {
                UserName = "superadmin",
                Password = "1q2w3e"
            };
        }
    }
}
