using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text highScoreText;
    
    void Start()
    {
        if(inputField != null)
        {
            inputField.onEndEdit.AddListener(OnEndEdit);
        }

        SetUser(UserInfo.Instance.userName);
        SetHighScore(UserInfo.Instance.highScore);
    }

    private void SetUser(string user)
    {
        inputField.text = user;
    }

    private void SetHighScore(int score)
    {
        highScoreText.text = "High Score: " + score.ToString();
    }

    private void OnEndEdit(string name)
    {
        UserInfo.Instance.userName = name;
        inputField.text = name;

        Debug.Log("User: " + name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        UserInfo.Instance.SaveGame();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    
}
