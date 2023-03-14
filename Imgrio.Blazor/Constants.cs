namespace Imgrio.Blazor
{
    public static class Constants
    {
        public const string AppName = "imgrio";
        public static readonly string AppUrl = !Program.App.Environment.IsDevelopment()
                                                    ? "https://imgrio.azurewebsites.net"
                                                    : "https://localhost:7223";

        public const string PathToIndex = "/";
        public const string PathToSharex = "/sharex";
        public const string PathToImprint = "/imprint";
        public const string PathToPrivacyPolicy = "/privacy-policy";
        public const string PathToCopyright = "https://baeni.de";
        public const string PathToAuthRegister = "/a/register";
        public const string PathToAuthLogin = "/a/login";
        public const string PathToAuthLogout = "/a/logout";
        public const string PathToFileUpload = "/f/upload";
        public const string PathToFileView = "/f/";
        public const string PathToUserAccount = "/u/account";
        public const string PathToUserFiles = "/u/files";

        public const int MaxFileSizeInBytes = 10000000;
    }
}
