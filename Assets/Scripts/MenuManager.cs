using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instant;
    public string name;
    public string MaxName;
    public int MaxScore;

    private void Awake()
    {
        if (instant == null)
        {
            instant = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    class SaveData
    {
        public string MaxName;
        public int MaxScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.MaxName = MaxName;
        data.MaxScore =MaxScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MaxName = data.MaxName;
            MaxScore = data.MaxScore;
        }
    }
}
