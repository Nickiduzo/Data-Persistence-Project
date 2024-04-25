using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;

    public void StartGame()
    {
        DataManager.Instance.currentName = nameInput.text;
        DataManager.Instance.SaveInfo();
        SceneManager.LoadScene(1);
    }
}
