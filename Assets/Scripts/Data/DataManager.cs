using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public string currentName;
    public int currentPoints;

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
    private void SaveInfo()
    {
        SaveData saveData = new SaveData();
        saveData.Name = currentName;
        saveData.score = currentPoints;

        string json = JsonUtility.ToJson(saveData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    private void LoadInfo()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            currentName = saveData.Name;
            currentPoints = saveData.score;
        }
    }

    public void SaveName(TMP_InputField inputName)
    {
        currentName = inputName;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SaveInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
