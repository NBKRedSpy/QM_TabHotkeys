using HarmonyLib;
using System.IO;
using System.Reflection;
using TabHotkeys_Bootstrap;
using UnityEngine;

namespace TabHotkeys
{
    public class Plugin : BootstrapMod
    {
        public static ConfigDirectories ConfigDirectories = new ConfigDirectories();

        public static string ModAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;
        public static string ConfigPath => Path.Combine(Application.persistentDataPath, ModAssemblyName, "config.json");
        public static ModConfig Config { get; private set; }

        public static Logger Logger = new Logger();


        public Plugin(HookEvents hookEvents, bool isBeta) : base(hookEvents, isBeta)
        {
            Directory.CreateDirectory(ConfigDirectories.ModPersistenceFolder);

            Config = ModConfig.LoadConfig(ConfigDirectories.ConfigPath);

            ItemTabsViewUpdateHook._keys = Config.Hotkeys;

            new Harmony("NBKRedSpy_" + ModAssemblyName).PatchAll();
        }
    }
}
