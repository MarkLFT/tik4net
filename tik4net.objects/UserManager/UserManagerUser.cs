namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/user")]
    public class UserManagerUser
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("attributes")]
        public string/* array of attributes */ Attributes { get; set; }

        [TikProperty("caller-id")]
        public string CallerId { get; set; }

        [TikProperty("disabled")]
        public bool Disabled { get; set; }

        [TikProperty("comment")]
        public string Comment { get; set; }

        [TikProperty("group", DefaultValue = "default")]
        public string Group { get; set; }

        [TikProperty("name", IsMandatory = true)]
        public string Name { get; set; }

        [TikProperty("otp-secret")]
        public string OTPSecret { get; set; }

        [TikProperty("password")]
        public string Password { get; set; }

        [TikProperty("shared-users ", DefaultValue = "1")]
        public string/*integer | unlimited*/ SharedUsers { get; set; }

    }
}
