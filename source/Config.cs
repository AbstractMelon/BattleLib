using BepInEx.Configuration;

namespace BattleLib
{
    public static class ConfigManager
    {
        public static ConfigEntry<bool> ExampleConfig { get; private set; }

        public static void Initialize(ConfigFile config)
        {
            ExampleConfig = config.Bind("General", "ExampleConfig", true, "This is an example config setting.");
        }
    }
}
