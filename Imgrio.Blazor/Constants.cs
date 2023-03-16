namespace Imgrio.Blazor
{
    public static class Constants
    {
        public const string AppName = "imgrio";
        public const string AppDescription = $"{AppName} ist eine Plattform zum Teilen von Inhalten. Aktuell ist der vollumfängliche Zugriff nur für ausgewählte Personen möglich.";
        public const string AppContact = "baeni.saa@gmail.com";
        public static readonly string AppUrl = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != Environments.Development
                                                    ? "https://imgrio.azurewebsites.net"
                                                    : "https://localhost:7223";

        public const string PathToIndex = "/";
        public const string PathToSharex = "/sharex";
        public const string PathToView = "/v/";

        public const string PathToImprint = "/imprint";
        public const string PathToPrivacyPolicy = "/privacy-policy";
        public const string PathToCopyright = "https://baeni.de";

        public const string PathToAuthRegister = "/auth/register";
        public const string PathToAuthLogin = "/auth/login";
        public const string PathToAuthLogout = "/auth/logout";

        public const string PathToDashboardUpload = "/dashboard/upload";
        public const string PathToDashboardAccount = "/dashboard/account";
        public const string PathToDashboardFiles = "/dashboard/files";

        public const int MaxFileSizeInBytes = 10000000;
    }
}
