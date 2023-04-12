using UnityEngine;
public static class SaveManager
{
    public static void SaveCurrentLevel(int levelValue)
    {
        PlayerPrefs.SetInt("CurrentLevel", levelValue);
    }

    public static int LoadCurrentLevel()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            return PlayerPrefs.GetInt("CurrentLevel");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            return 0;
        }
    }

    public static void SaveLevels(int levelValue)
    {
        PlayerPrefs.SetInt("Levels", levelValue);
    }

    public static int LoadLevels()
    {
        if (PlayerPrefs.HasKey("Levels"))
        {
            return PlayerPrefs.GetInt("Levels");
        }
        else
        {
            PlayerPrefs.SetInt("Levels", 0);
            return 0;
        }
    }

    public static void SaveBestiary(int BestiaryValue)
    {
        PlayerPrefs.SetInt("Bestiary", BestiaryValue);
    }

    public static int LoadBestiary()
    {
        if (PlayerPrefs.HasKey("Bestiary"))
        {
            return PlayerPrefs.GetInt("Bestiary");
        }
        else
        {
            PlayerPrefs.SetInt("Bestiary", 0);
            return 0;
        }
    }
}
