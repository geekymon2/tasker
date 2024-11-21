namespace GeekyMon2.Tasker.Common
{
    using System.Reflection;

    public class VersionHelper
    {
        public static string GetBuildVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var informationalVersion = assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

            return informationalVersion ?? "Version not set";
        }
    }
}
