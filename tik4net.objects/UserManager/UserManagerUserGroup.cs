namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/user/group", IncludeDetails = true)]
    public class UserManagerUserGroup
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("attributes")]
        public string/* array of attributes */ Attributes { get; set; }

        [TikProperty("comment")]
        public string Comment { get; set; }

        [TikProperty("name", IsMandatory = true)]
        public string Name { get; set; }

        [TikProperty("inner-auths")]
        public string/* list of auths*/ InnerAuths { get; set; }

        [TikProperty("outer-auths")]
        public string/* list of auths*/ OuterAuths { get; set; }
    }
}
