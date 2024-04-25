using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestResult;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        DataManager.Instance.LoadInfo();
        if (DataManager.Instance != null)
        {
            bestResult.text = $"Best Score: {DataManager.Instance.highNameScore} : {DataManager.Instance.highScoreValue}";
        }
    }
    public void ResumeMenu()
    {
        DataManager.Instance.SaveInfo();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        DataManager.Instance.SaveInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
