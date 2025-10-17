namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/profile-limitation")]
    public class UserManagerProfileLimitation
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("comment", DefaultValue = "")]
        public string Comment { get; set; }

        [TikProperty("from-time", DefaultValue = "00:00:00")]
        public string FromTime { get; set; }

        [TikProperty("limitation ", DefaultValue = "")]
        public string Limitation { get; set; }

        [TikProperty("profile ", DefaultValue = "")]
        public string Profile { get; set; }

        [TikProperty("till-time", DefaultValue = "23:59:59")]
        public decimal TillTime { get; set; }

        [TikProperty("weekdays", DefaultValue = "Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday")]
        public string/*day of week*/ Weekdays { get; set; }
    }
}
