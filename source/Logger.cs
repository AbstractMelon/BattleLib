using BepInEx.Logging;

namespace BattleLib
{
    public static class Logger
    {
        private static ManualLogSource logSource;

        public static void Initialize(ManualLogSource source)
        {
            logSource = source;
        }

        public static void LogInfo(string message)
        {
            logSource.LogInfo(message);
        }

        public static void LogWarning(string message)
        {
            logSource.LogWarning(message);
        }

        public static void LogError(string message)
        {
            logSource.LogError(message);
        }
    }
}
