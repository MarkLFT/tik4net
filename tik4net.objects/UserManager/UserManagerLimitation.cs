namespace tik4net.Objects.UserManager
{
    [TikEntity("/user-manager/limitation", IncludeDetails = true)]
    public class UserManagerLimitation
    {
        /// <summary>
        /// .id: primary key of row
        /// </summary>
        [TikProperty(".id", IsReadOnly = true, IsMandatory = true)]
        public string Id { get; private set; }

        [TikProperty("comment")]
        public string Comment { get; set; }

        [TikProperty("download-limit")]
        public int DownloadLimit { get; set; }

        [TikProperty("name", IsMandatory = true)]
        public string Name { get; set; }

        [TikProperty("rate-limit-burst-rx")]
        public string RateLimitBurstRx { get; set; }

        [TikProperty("rate-limit-burst-threshold-rx")]
        public string RateLimitBurstThresholdRx { get; set; }

        [TikProperty("rate-limit-burst-threshold-tx")]
        public string RateLimitBurstThresholdTx { get; set; }

        [TikProperty("rate-limit-burst-time-rx")]
        public string RateLimitBurstTimeRx { get; set; }

        [TikProperty("rate-limit-burst-time-tx")]
        public string RateLimitBurstTimeTx { get; set; }

        [TikProperty("rate-limit-burst-tx")]
        public string RateLimitBurstTx { get; set; }

        [TikProperty("rate-limit-min-rx")]
        public string RateLimitMinRx { get; set; }

        [TikProperty("rate-limit-min-tx")]
        public string RateLimitMinTx { get; set; }

        [TikProperty("rate-limit-priority")]
        public string RateLimitPriority { get; set; }

        [TikProperty("rate-limit-rx")]
        public string RateLimitRx { get; set; }

        [TikProperty("rate-limit-tx")]
        public string RateLimitTx { get; set; }

        [TikProperty("reset-counters-interval", DefaultValue = "disabled")]
        public string/* hourly|daily|weekly|monthly|disabled*/ ResetCounterInterval { get; set; }

        [TikProperty("reset-counters-start-time")]
        public string ResetCountersStartTime { get; set; }

        [TikProperty("transfer-limit")]
        public int TransferLimit { get; set; }

        [TikProperty("upload-limit")]
        public int UploadLimit { get; set; }

        [TikProperty("uptime-limit", DefaultValue = "00:00:00")]
        public string UptimeLimit { get; set; }


    }
}
