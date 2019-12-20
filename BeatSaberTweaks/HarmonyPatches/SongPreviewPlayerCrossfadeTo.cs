using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeatSaberTweaks.HarmonyPatches
{
    [HarmonyPatch(typeof(SongPreviewPlayer))]
    [HarmonyPatch("CrossfadeTo")]
    [HarmonyPatch(new Type[] { typeof(AudioClip), typeof(float), typeof(float), typeof(float) })]
    class SongPreviewPlayerCrossfadeTo
    {
        static bool Prefix(SongPreviewPlayer __instance, AudioClip audioClip, float startTime, float duration, float volumeScale = 1f)
        {
            // Check if this is the default audio clip, and if it is, use the Menu BG Music Volume, otherwise use the preview volume.
            var defaultClip = ReflectionUtil.GetPrivateField<AudioClip>(__instance, "_defaultAudioClip");
            var resultsViewController = Resources.FindObjectsOfTypeAll<ResultsViewController>().FirstOrDefault();
            AudioClip levelClearedClip = null;
            if (resultsViewController != null)
            {
                levelClearedClip = ReflectionUtil.GetPrivateField<AudioClip>(resultsViewController, "_levelClearedAudioClip");
            }
            if (audioClip == defaultClip)
            {
                __instance.volume = Settings.MenuBGVolume;
                Plugin.Log("Setting SongPreviewPlayer volume to MenuBGVolume : " + __instance.volume, Plugin.LogLevel.DebugOnly);
            }
            else if (audioClip == levelClearedClip)
            {
                __instance.volume = Settings.SongFinishFanfareVolume;
            }
            else
            {
                // Don't crossfade if the preview volume is set to 0
                if (Settings.PreviewVolume == 0) return false;

                __instance.volume = Settings.PreviewVolume;
                Plugin.Log("Setting SongPreviewPlayer volume to PreviewVolume : " + __instance.volume, Plugin.LogLevel.DebugOnly);
            }

            // Return true to run the original method as well
            return true;
        }
    }
}
