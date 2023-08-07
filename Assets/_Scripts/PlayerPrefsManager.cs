using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{ 
    const string MasterVolumeKey = "master_volume";
    const string DifficultyKey = "difficulty";
    const string LevelKey = "level_unlocked";

    public static void SetMasterVolumeKey(float volume)
    {
        if (volume > 0 && volume < 1)
        {
            PlayerPrefs.SetFloat(MasterVolumeKey, volume);    
        }
        else
        {
            Debug.LogError("Master Volume out of range");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MasterVolumeKey);
    }
    public static void LevelUnlocked(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LevelKey + level.ToString(), 1 );
        }
        else
        {
            Debug.LogError("trying to unlock level not in build order");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        var levelvalue = PlayerPrefs.GetInt(LevelKey + level.ToString());
        bool isLevelUnlocked = (levelvalue == 1);
        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query error not build");
            return false;
        }
    }
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 0 && difficulty < 1)
        {
            PlayerPrefs.SetFloat(DifficultyKey , difficulty);
        }
        else
        {
            Debug.LogError("difficulty out of range");
        }
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DifficultyKey);
    }
}
