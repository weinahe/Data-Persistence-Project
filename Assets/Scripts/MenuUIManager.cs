using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text highScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataManager.Instance.LoadHighScore();
        inputField.text = DataManager.Instance.data.nameNow;
        ShowBestScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        inputField.text = DataManager.Instance.data.nameNow;
        ShowBestScore();
    }
    public void Exit()
    {
        DataManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveUserName()
    {
        DataManager.Instance.data.nameNow = inputField.text;
    }

    void ShowBestScore()
    {
        highScoreText.text = "Best Score:" + DataManager.Instance.data.highName + " " + DataManager.Instance.data.highScore;
    }
}
