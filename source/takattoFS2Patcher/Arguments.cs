namespace takattoFS2
{
    public static class Arguments
    {
        public static string GameId { get; internal set; } = "https://fs2.nexon.com/web/main.do";
        public static string JoycityGameId { get; internal set; } = "https://fs2.joycity.com/web/main.do";
        public static string StartLocale { get; internal set; } = "KR";
        public static string LoginUrl { get; internal set; } = "https://nxlogin.nexon.com/common/login.aspx";
        public static string JoycityLoginUrl { get; internal set; } = "https://www.joycity.com/user/integrateLogin";

        public static string NewsUrl => $"{PatcherSettings.GetValue(PatcherSettings.DISPLAY_WEBSITE)}/fs2/index_news";
        public static string LoginRedirectUrl => $"{LoginUrl}?redirect=http%3a%2f%2ffs2.nexon.com%2fweb%2fmain.do"; //{LoginUrl}?redirect={GameId}
        public static string JoycityLoginRedirectUrl => $"{JoycityLoginUrl}?redirect=http%3A%2F%2Ffs2.joycity.com%2Fweb%2Fmain.do&SITE_CD=FS2"; //{JoycityLoginUrl}?redirect={JoycityGameId}
    }
}
