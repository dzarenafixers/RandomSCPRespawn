using System.Collections.Generic;
using PlayerRoles;
using PluginAPI.Enums;

public class Config
{
    public float RespawnChance { get; set; } = 0.3f; // نسبة التحول إلى SCP (30%)
    
    public List<RoleTypeId> ScpRoles { get; set; } = new List<RoleTypeId>
    {
        RoleTypeId.Scp049,
        RoleTypeId.Scp096,
        RoleTypeId.Scp173,
        RoleTypeId.Scp939
    };
}