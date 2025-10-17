namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/profile")]
    public class UserManagerProfile
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("comment", DefaultValue = "")]
        public string Comment { get; set; }

        [TikProperty("name", DefaultValue = "")]
        public string Name { get; set; }

        [TikProperty("name-for-users", DefaultValue = "")]
        public string NameForUsers { get; set; }

        [TikProperty("override-shared-users", DefaultValue = "off")]
        public string/*decimal | off | unlimited*/ OverrideSharedUsers { get; set; }

        [TikProperty("price", DefaultValue = "0")]
        public decimal Price { get; set; }

        [TikProperty("starts-when", DefaultValue = "assigned")]
        public string/*assigned | first-auth*/ StartsWhen { get; set; }

        [TikProperty("validity", DefaultValue = "unlimited")]
        public string/*time | unlimited*/ Validity { get; set; }
    }
}
