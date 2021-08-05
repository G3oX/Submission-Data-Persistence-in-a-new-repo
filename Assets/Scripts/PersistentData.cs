using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance { get; private set; }
    private string PlayerName;
    private float highScore;
    private string bestPlayerName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public string getPlayerName()
    {
        return PlayerName;
    }

    public void addPlayerName(string name)
    {
        PlayerName = name;
    }

    [System.Serializable]
    public class SaveData
    {
        public float highScore;
        public string bestPlayerName;
    }

    public SaveData loadSaveData()
    {
        SaveData data = new SaveData();
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        highScore = data.highScore;
        bestPlayerName = data.bestPlayerName;
        return data;
    }

    public void saveData(float score, string name)
    {
        SaveData data = new SaveData();
        data.highScore = score;
        data.bestPlayerName = name;
        //Save only if it is the best score
        if(score > highScore)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

}
