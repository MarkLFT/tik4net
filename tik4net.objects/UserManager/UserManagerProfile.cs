namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/profile", IncludeDetails = true)]
    public class UserManagerProfile
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("comment")]
        public string Comment { get; set; }

        [TikProperty("name", IsMandatory = true)]
        public string Name { get; set; }

        [TikProperty("name-for-users")]
        public string NameForUsers { get; set; }

        [TikProperty("override-shared-users", DefaultValue = "off", IsMandatory = true)]
        public string/*decimal | off | unlimited*/ OverrideSharedUsers { get; set; }

        [TikProperty("price", DefaultValue = "0", IsMandatory = true)]
        public string Price { get; set; }

        [TikProperty("starts-when", DefaultValue = "assigned", IsMandatory = true)]
        public string/*assigned | first-auth*/ StartsWhen { get; set; }

        [TikProperty("validity")] //, DefaultValue = "unlimited", IsMandatory = true)]
        public string/*time | unlimited*/ Validity { get; set; }

        public UserManagerProfile()
        {
            OverrideSharedUsers = "off";
            Price = "0";
            StartsWhen = "assigned";
            Validity = "unlimited";
        }
    }
}
