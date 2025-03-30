using System.Data.Common;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SaveData data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = new SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static DataManager Instance;
   
    private void Awake()
    {
        // singleton
        // destroy the duplicated gameObject or this would cause problem
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // stores “this” in the class member Instance — the current instance of MainManager
        // can call MainManager.Instance from any other script and get a link to that specific instance of it. 
        // You don’t need to have a reference to it, like you do when you assign GameObjects to script properties in the Inspector.
        Instance = this;

        //the MainManager GameObject attached to this script not to be destroyed when the scene changes.
        DontDestroyOnLoad(gameObject);
        
        // load high score
    }

    [System.Serializable]
    public class SaveData
    {
        public string highName;
        public int highScore;
        public string nameNow;
        public int scoreNow;
    }

    public void SaveHighScore()
    {
             
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
    }

    public void UpdateScore()
    {
        if(data.scoreNow > data.highScore) {
            data.highScore = data.scoreNow;
            data.highName = data.nameNow;
        }
    }
}
