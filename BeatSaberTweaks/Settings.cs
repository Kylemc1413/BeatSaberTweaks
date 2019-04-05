using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BeatSaberTweaks
{
    [Serializable]
    public class Settings
    {
        static Settings instance = null;

        private static float defaultNoteHitVolume = 0.5f;
        private static float defaultNoteMissVolume = 0.9f;

        // Settings version
        [SerializeField]
        string settingsVersion = "0.0.0";
        public static string SettingsVersion { get => instance.settingsVersion; set { instance.settingsVersion = value; Plugin.saveRequested = true; } }

        // Note Volume controls
        [SerializeField]
        float noteHitVolume = defaultNoteHitVolume;
        public static float NoteHitVolume { get => instance.noteHitVolume; set { instance.noteHitVolume = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float noteMissVolume = defaultNoteMissVolume;
        public static float NoteMissVolume { get => instance.noteMissVolume; set { instance.noteMissVolume = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float musicVolume = 1.0f;
        public static float MusicVolume { get => instance.musicVolume; set { instance.musicVolume = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float previewVolume = 1.0f;
        public static float PreviewVolume { get => instance.previewVolume; set { instance.previewVolume = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float menuBGVolume = 1.0f;
        public static float MenuBGVolume { get => instance.menuBGVolume; set { instance.menuBGVolume = value; Plugin.saveRequested = true; } }

        // In Game Clock
        [SerializeField]
        bool showclock = false;
        public static bool ShowClock { get => instance.showclock; set { instance.showclock = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool hideClockIngame = false;
        public static bool HideClockIngame { get => instance.hideClockIngame; set { instance.hideClockIngame = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool use24hrClock = false;
        public static bool Use24hrClock { get => instance.use24hrClock; set { instance.use24hrClock = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float clockFontSize = 4.0f;
        public static float ClockFontSize { get => instance.clockFontSize; set { instance.clockFontSize = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 clockPosition = new Vector3(0, 2.4f, 2.4f);
        public static Vector3 ClockPosition { get => instance.clockPosition; set { instance.clockPosition = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 clockRotation = new Vector3(0, 0, 0);
        public static Quaternion ClockRotation { get => Quaternion.Euler(instance.clockRotation); set { instance.clockPosition = value.eulerAngles; Plugin.saveRequested = true; } }

        [SerializeField]
        String clockAlignment = "center";
        public static String ClockAlignment { get => instance.clockAlignment; set { instance.clockAlignment = value; Plugin.saveRequested = true; } }


        // Time Spent Clock
        [SerializeField]
        bool showTimeSpentClock = false;
        public static bool ShowTimeSpentClock { get => instance.showTimeSpentClock; set { instance.showTimeSpentClock = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool hideTimeSpentClockIngame = true;
        public static bool HideTimeSpentClockIngame { get => instance.hideTimeSpentClockIngame; set { instance.hideTimeSpentClockIngame = value; Plugin.saveRequested = true; } }

        [SerializeField]
        String timeSpentClockMessageTemplate = "You've spent %TIME% in this session.";
        public static String TimeSpentClockMessageTemplate { get => instance.timeSpentClockMessageTemplate; set { instance.timeSpentClockMessageTemplate = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float timeSpentClockFontSize = 4.0f;
        public static float TimeSpentClockFontSize { get => instance.timeSpentClockFontSize; set { instance.timeSpentClockFontSize = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 timeSpentClockPosition = new Vector3(0, 0.35f, 2.4f);
        public static Vector3 TimeSpentClockPosition { get => instance.timeSpentClockPosition; set { instance.timeSpentClockPosition = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 timeSpentClockRotation = new Vector3(0, 0, 0);
        public static Quaternion TimeSpentClockRotation { get => Quaternion.Euler(instance.timeSpentClockRotation); set { instance.timeSpentClockRotation = value.eulerAngles; Plugin.saveRequested = true; } }

        [SerializeField]
        String timeSpentClockAlignment = "center";
        public static String TimeSpentClockAlignment { get => instance.timeSpentClockAlignment; set { instance.timeSpentClockAlignment = value; Plugin.saveRequested = true; } }

        // Ingame Time Spent Clock
        [SerializeField]
        bool showIngameTimeSpentClock = false;
        public static bool ShowIngameTimeSpentClock { get => instance.showIngameTimeSpentClock; set { instance.showIngameTimeSpentClock = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool hideIngameTimeSpentClockIngame = true;
        public static bool HideIngameTimeSpentClockIngame { get => instance.hideIngameTimeSpentClockIngame; set { instance.hideIngameTimeSpentClockIngame = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float ingameTimeSpentClockFontSize = 4.0f;
        public static float IngameTimeSpentClockFontSize { get => instance.ingameTimeSpentClockFontSize; set { instance.ingameTimeSpentClockFontSize = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 ingameTimeSpentClockPosition = new Vector3(0, 0.25f, 2.4f);
        public static Vector3 IngameTimeSpentClockPosition { get => instance.ingameTimeSpentClockPosition; set { instance.ingameTimeSpentClockPosition = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 ingameTimeSpentClockRotation = new Vector3(0, 0, 0);
        public static Quaternion IngameTimeSpentClockRotation { get => Quaternion.Euler(instance.ingameTimeSpentClockRotation); set { instance.ingameTimeSpentClockRotation = value.eulerAngles; Plugin.saveRequested = true; } }

        [SerializeField]
        String ingameTimeSpentClockMessageTemplate = "You've played %TIME% this session.";
        public static String IngameTimeSpentClockMessageTemplate { get => instance.ingameTimeSpentClockMessageTemplate; set { instance.ingameTimeSpentClockMessageTemplate = value; Plugin.saveRequested = true; } }

        [SerializeField]
        String ingameTimeSpentClockAlignment = "center";
        public static String IngameTimeSpentClockAlignment { get => instance.ingameTimeSpentClockAlignment; set { instance.ingameTimeSpentClockAlignment = value; Plugin.saveRequested = true; } }

        // Move Energy Bar
        [SerializeField]
        bool moveEnergyBar = false;
        public static bool MoveEnergyBar { get => instance.moveEnergyBar; set { instance.moveEnergyBar = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float energyBarHeight = 3.0f;
        public static float EnergyBarHeight { get => instance.energyBarHeight; set { instance.energyBarHeight = value; Plugin.saveRequested = true; } }

        // Move Score
        [SerializeField]
        bool moveScore = false;
        public static bool MoveScore { get => instance.moveScore; set { instance.moveScore = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float scoreSize = 2.0f;
        public static float ScoreSize { get => instance.scoreSize; set { instance.scoreSize = value; Plugin.saveRequested = true; } }

        [SerializeField]
        Vector3 scorePosition = new Vector3(3.25f, 3.25f, 7.0f);
        public static Vector3 ScorePosition { get => instance.scorePosition; set { instance.scorePosition = value; Plugin.saveRequested = true; } }

        // Party Tweaks
        [SerializeField]
        bool noArrows = false;
        public static bool NoArrows { get => instance.noArrows; set { instance.noArrows = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool oneColour = false;
        public static bool OneColour { get => instance.oneColour; set { instance.oneColour = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool removeBombs = false;
        public static bool RemoveBombs { get => instance.removeBombs; set { instance.removeBombs = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool overrideJumpSpeed = false;
        public static bool OverrideJumpSpeed { get => instance.overrideJumpSpeed; set { instance.overrideJumpSpeed = value; Plugin.saveRequested = true; } }

        [SerializeField]
        float noteJumpSpeed = 10.0f;
        public static float NoteJumpSpeed { get => instance.noteJumpSpeed; set { instance.noteJumpSpeed = value; Plugin.saveRequested = true; } }

        // Menu Tweaks
        [SerializeField]
        bool fireworksEnable = true;
        public static bool FireworksEnable { get => instance.fireworksEnable; set { instance.fireworksEnable = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool clickShockwaveEnable = true;
        public static bool ClickShockwaveEnable { get => instance.clickShockwaveEnable; set { instance.clickShockwaveEnable = value; Plugin.saveRequested = true; } }

        [SerializeField]
        bool showFailsCounter = true;
        public static bool ShowFailsCounterEnable { get => instance.showFailsCounter; set { instance.showFailsCounter = value; Plugin.saveRequested = true; } }

        [SerializeField]
        string failsCounterReplacementText = "HIDDEN";
        public static string FailsCounterReplacementText { get => instance.failsCounterReplacementText; set { instance.failsCounterReplacementText = value; Plugin.saveRequested = true; } }

        public Settings()
        {

        }

        public static string SettingsPath()
        {
            return Path.Combine(Environment.CurrentDirectory, "UserData/Tweaks.cfg");
        }

        public static void Load()
        {
            instance = new Settings();

            string oldFilePath = Path.Combine(Environment.CurrentDirectory, "Tweaks.cfg");
            string filePath = SettingsPath();

            // If the file exists in the old location, but not in the new one, move it to the new location
            if (File.Exists(oldFilePath) && !File.Exists(filePath))
            {
                File.Move(oldFilePath, filePath);
            }

            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                JsonUtility.FromJsonOverwrite(dataAsJson, instance);

                if (instance.settingsVersion.Equals("0.0.0"))
                {
                    Plugin.Log("Settings didn't contain version number! Converting old settings to new format!", Plugin.LogLevel.Error);
                    instance.noteHitVolume *= 0.5f;
                    instance.noteMissVolume *= 0.9f;
                    Plugin.Log("Settings conversion finished!", Plugin.LogLevel.Error);
                }
                else if (instance.settingsVersion.Equals("4.2.2") || instance.settingsVersion.Equals("4.2.3"))
                {
                    Plugin.Log("Old config found! Setting SFX volume to default values, if they are at dangerous levels", Plugin.LogLevel.Error);
                    if (instance.noteHitVolume > defaultNoteHitVolume) instance.noteHitVolume = defaultNoteHitVolume;
                    if (instance.noteMissVolume > defaultNoteMissVolume) instance.noteMissVolume = defaultNoteMissVolume;
                }
            }
        }

        public static void Save()
        {
            instance.settingsVersion = Plugin.versionNumber;
            string dataAsJson = JsonUtility.ToJson(instance, true);
            File.WriteAllText(SettingsPath(), dataAsJson);
        }
    }
}
