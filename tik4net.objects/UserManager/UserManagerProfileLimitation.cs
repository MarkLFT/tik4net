namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/profile-limitation", IncludeDetails = true)]
    public class UserManagerProfileLimitation
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("comment")]
        public string Comment { get; set; }

        [TikProperty("from-time", DefaultValue = "00:00:00")]
        public string FromTime { get; set; }

        [TikProperty("limitation")]
        public string Limitation { get; set; }

        [TikProperty("profile")]
        public string Profile { get; set; }

        [TikProperty("till-time", DefaultValue = "23:59:59")]
        public string TillTime { get; set; }

        [TikProperty("weekdays", DefaultValue = "sunday,monday,tuesday,wednesday,thursday,friday,saturday")]
        public string/*day of week*/ Weekdays { get; set; }
    }
}
