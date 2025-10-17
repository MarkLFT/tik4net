namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/user/group")]
    public class UserManagerUserGroup
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("attributes", DefaultValue = "")]
        public string/* array of attributes */ Attributes { get; set; }

        [TikProperty("comment", DefaultValue = "")]
        public string Comment { get; set; }

        [TikProperty("name", DefaultValue = "")]
        public string Name { get; set; }

        [TikProperty("inner-auths", DefaultValue = "")]
        public string/* list of auths*/ InnerAuths { get; set; }

        [TikProperty("outer-auths", DefaultValue = "")]
        public string/* list of auths*/ Password { get; set; }
    }
}
