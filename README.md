# 🧪 Random SCP Respawn

## 📌 **Description**
`Random SCP Respawn` is a plugin for **SCP: Secret Laboratory** that allows players to **respawn as a random SCP upon death** instead of being eliminated.  
The respawn chance and list of available SCPs can be **customized** in the configuration file.

## 🔧 **Features**
✔ Players have a **chance** to respawn as an SCP instead of dying.  
✔ Fully **customizable respawn rate** via the config file.  
✔ Choose **which SCPs** players can transform into.  
✔ **Reload settings** without restarting the server.  

## 📂 **Installation**
1. Download **`RandomSCPRespawn.dll`** and place it in your `plugins/` folder.  
2. Start the server once to generate the config file at `configs/RandomSCPRespawn.json`.  
3. Open `RandomSCPRespawn.json` and modify the settings as needed.  
4. **No server restart required!** Simply reload the plugin to apply new settings.  

## ⚙ **Configuration**
📄 **File:** `configs/RandomSCPRespawn.json`  
```json
{
  "RespawnChance": 0.3,
  "ScpRoles": [
    "Scp049",
    "Scp096",
    "Scp173",
    "Scp939"
  ]
}
