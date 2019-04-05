using IPA;
using IPA.Config;
using IPA.Utilities;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace BeatSaberTweaks
{
    public class Plugin : IBeatSaberPlugin
    {
        internal static Ref<PluginConfig> config;
        internal static IConfigProvider configProvider;

        public void Init(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider)
        {
            Logger.log = logger;
            configProvider = cfgProvider;

            config = cfgProvider.MakeLink<PluginConfig>((p, v) =>
            {
                if (v.Value == null || v.Value.RegenerateConfig)
                    p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                config = v;
            });
        }

        public static string versionNumber = "4.4.1";
        private bool _init = false;
        private static SoloFreePlayFlowCoordinator _soloFlowCoordinator;
        private static PartyFreePlayFlowCoordinator _partyFlowCoordinator;

        private static PracticeViewController _practiceViewController;
        private static StandardLevelDetailViewController _soloDetailView;
        private static bool debug = false;
        public static bool party { get; private set; } = false;
        public static bool saveRequested = false;

        public enum LogLevel
        {
            DebugOnly = 0,
            Info = 1,
            Error = 2
        }


        public void OnApplicationStart()
        {
            Logger.log.Debug("OnApplicationStart");
            if (_init) return;
            _init = true;

            Settings.Load();
            TweakManager.OnLoad();
        }

        public void OnApplicationQuit()
        {
            Logger.log.Debug("OnApplicationQuit");
        }

        public void OnFixedUpdate()
        {

        }

        public void OnUpdate()
        {

        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == "MenuCore")
            {


                if (_soloFlowCoordinator == null)
                {
                    _soloFlowCoordinator = Resources.FindObjectsOfTypeAll<SoloFreePlayFlowCoordinator>().FirstOrDefault();
                    if (_soloFlowCoordinator == null) return;
                    _soloDetailView = _soloFlowCoordinator.GetPrivateField<StandardLevelDetailViewController>("_levelDetailViewController");
                    _practiceViewController = _soloFlowCoordinator.GetPrivateField<PracticeViewController>("_practiceViewController");
                    if (_soloDetailView != null)
                        _soloDetailView.didPressPlayButtonEvent += _soloDetailView_didPressPlayButtonEvent;
                    else
                        Log("Detail View Null", Plugin.LogLevel.Info);
                    if (_practiceViewController != null)
                        _practiceViewController.didPressPlayButtonEvent += _practiceViewController_didPressPlayButtonEvent;
                    else
                        Log("Practice View Null", Plugin.LogLevel.Info);

                }

                if (_partyFlowCoordinator == null)
                {
                    _partyFlowCoordinator = Resources.FindObjectsOfTypeAll<PartyFreePlayFlowCoordinator>().FirstOrDefault();
                }

                if (saveRequested)
                {
                    Settings.Save();
                    saveRequested = false;
                }
            }
        }

        private void _practiceViewController_didPressPlayButtonEvent()
        {
            Log("Play Button Press ", Plugin.LogLevel.Info);
            party = _partyFlowCoordinator.isActivated;
            Log(party.ToString(), Plugin.LogLevel.Info);
        }

        private void _soloDetailView_didPressPlayButtonEvent(StandardLevelDetailViewController obj)
        {
            Log("Play Button Press ", Plugin.LogLevel.Info);
            party = _partyFlowCoordinator.isActivated;
            Log(party.ToString(), Plugin.LogLevel.Info);
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {

        }

        public void OnSceneUnloaded(Scene scene)
        {

        }

        public static void Log(string input, Plugin.LogLevel logLvl)
        {
            if (logLvl >= LogLevel.Info || debug) Console.WriteLine("[BeatSaberTweaks]: " + input);
        }
    }
}
