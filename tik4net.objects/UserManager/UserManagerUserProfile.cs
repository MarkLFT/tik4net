namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/user-profile", IncludeDetails = true)]
    public class UserManagerUserProfile
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("profile", IsMandatory = true)]
        public string Profile { get; set; }

        [TikProperty("user", IsMandatory = true)]
        public string User { get; set; }

        [TikProperty("state", IsReadOnly = true)]
        public string State { get; private set; }

        [TikProperty("end-time", IsReadOnly = true)]
        public string EndTime { get; private set; }

    }
}
