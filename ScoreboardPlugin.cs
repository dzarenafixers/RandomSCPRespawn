using NWAPIPermissionSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using PluginAPI.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using LabApi.Loader.Features.Plugins;
using PlayerRoles;

public class RandomSCPRespawn : PluginConfig
{
    public string Name => "Random SCP Respawn";
    public string Author => "moncef50g&dzarenafixers";
    public string Version => "1.1.0";

    private static Random _random = new Random();
    private static Config _config;

    private string configPath = Path.Combine("configs", "RandomSCPRespawn.json");

    [field: PluginConfig]
    public Config Config { get; set; }

    public void OnEnabled()
    {
        LoadConfig();
        Log.Info("تم تحميل إعدادات البلجن بنجاح!");
    }

    [PluginEvent(ServerEventType.PlayerDeath)]
    public void OnPlayerDeath(PlayerDeathEvent ev)
    {
        if (_random.NextDouble() <= _config.RespawnChance)
        {
            if (_config.ScpRoles.Count == 0)
            {
                Log.Warning("⚠ قائمة SCPs في الإعدادات فارغة!");
                return;
            }

            // اختيار SCP عشوائي من القائمة
            RoleTypeId randomScp = _config.ScpRoles[_random.Next(_config.ScpRoles.Count)];

            // إعادة إحياء اللاعب كـ SCP
            ev.Player.SetRole(randomScp, RoleChangeReason.Respawn);
            Log.Info($"تم إعادة إحياء {ev.Player.Nickname} كـ {randomScp} بعد الموت!");
        }
    }

    public void LoadConfig()
    {
        if (!Directory.Exists("configs"))
            Directory.CreateDirectory("configs");

        if (!File.Exists(configPath))
        {
            _config = new Config(); // إنشاء إعدادات افتراضية
            File.WriteAllText(configPath, JsonSerializer.Serialize(_config, new JsonSerializerOptions { WriteIndented = true }));
            Log.Info("تم إنشاء ملف الإعدادات الافتراضي.");
        }
        else
        {
            _config = JsonSerializer.Deserialize<Config>(File.ReadAllText(configPath));
            Log.Info("تم تحميل ملف الإعدادات بنجاح.");
        }
    }
}
