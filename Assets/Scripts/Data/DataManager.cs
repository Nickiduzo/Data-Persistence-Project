using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string currentName;

    public string highNameScore;
    public int highScoreValue;

    public static DataManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }
    public void SaveInfo()
    {
        SaveData saveData = new SaveData()
        {
            name = currentName,
            highName = highNameScore,
            highScore = highScoreValue
        };

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

            currentName = loadedData.name;

            highNameScore = loadedData.highName;
            highScoreValue = loadedData.highScore;
        }
    }

    public void UpdateHighScore(int score, string playerName)
    {
        if (score > highScoreValue)
        {
            highScoreValue = score;
            highNameScore = playerName;
            SaveInfo();
        }
    }
}
