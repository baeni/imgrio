namespace Imgrio.Blazor
{
    public static class Constants
    {
        public const string AppName = "imgrio";
        public const string AppDescription = $"{AppName} ist eine Plattform zum Teilen von Inhalten. Aktuell ist der volle Zugriff auf ausgewählte Personen beschränkt.";
        public static readonly string AppUrl = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != Environments.Development
                                                    ? "https://imgrio.azurewebsites.net"
                                                    : "https://localhost:7223";

        public const string SymbolAppLogo = "/assets/symbols/logo.svg";
        public const string SymbolFiles = "/assets/symbols/files.svg";
        public const string SymbolUpload = "/assets/symbols/upload.svg";
        public const string SymbolAccount = "/assets/symbols/account.svg";
        public const string SymbolLogout = "/assets/symbols/logout.svg";

        public const string PathToIndex = "/";
        public const string PathToSharex = "/sharex";
        public const string PathToView = "/f/";

        public const string PathToImprint = "/imprint";
        public const string PathToPrivacyPolicy = "/privacy-policy";
        public const string PathToCopyright = "https://baeni.de";

        public const string PathToAuthRegister = "/account/register";
        public const string PathToAuthLogin = "/account/login";
        public const string PathToAuthLogout = "/account/logout";

        public const string PathToDashboardUpload = "/dashboard/upload";
        public const string PathToDashboardAccount = "/dashboard/account";
        public const string PathToDashboardFiles = "/dashboard/files";

        public const int MaxFileSizeInBytes = 10000000;
    }
}
