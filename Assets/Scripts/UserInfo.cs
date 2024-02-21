using System;
using System.IO;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public static UserInfo Instance;

    [HideInInspector]
    public string userName;
    [HideInInspector]
    public int highScore;

    // Awake is called once when object is created.
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    [Serializable]
    class SaveGameData
    {
        public string userName;
        public int highScore;
    }

    public void SaveGame()
    {
        SaveGameData data = new ();
        data.userName = userName;
        data.highScore = highScore;
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveGameData data = JsonUtility.FromJson<SaveGameData>(json);
            userName = data.userName;
        }
    }
}
