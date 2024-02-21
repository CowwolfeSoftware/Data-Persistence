using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Text bestScore;

    void Start()
    {
        UpdateBestScore();
    }

    public void UpdateBestScore()
    {
        if(UserInfo.Instance != null)
            bestScore.text = string.Format("Best Score : {0} : {1}", UserInfo.Instance.userName, UserInfo.Instance.highScore);
    }

    
}
