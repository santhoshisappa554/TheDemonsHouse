using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string Master_Volume_Key = "master_volume";
    const string Difficult_key = "difficulty";
    const string Level_Key = "level_difficulty_unlocked";

    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
        {
            PlayerPrefs.SetFloat(Master_Volume_Key, volume);
        }
        else
        {
            Debug.LogError("Volume Out of Range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(Master_Volume_Key);
    }


    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCount)
        {
            PlayerPrefs.SetInt(Level_Key + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("This level is not in the build order");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        int levelvalue = PlayerPrefs.GetInt(Level_Key + level.ToString());
        bool isLevelUnlocked = (levelvalue == 1);

        if (level <= SceneManager.sceneCount)
        {
            //return bool

            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("This level is not in the build order");
            return false;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 0f && difficulty <= 1f)
        {
            PlayerPrefs.SetFloat(Difficult_key, difficulty);

        }
        else
        {
            Debug.LogError("Difficuty is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(Difficult_key);
    }


}
