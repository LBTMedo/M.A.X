using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{

    public static GameControl control;
    public float SFX = 0.5f;
    public float MASTER = 0.5f;
    public float MUSIC = 0.5f;
    public int currentLevel = 1;
    public int ubitiSovrazniki = 0;
    public int denar = 0;
    public string savegameIme;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {            
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/"+savegameIme+".dat");

        PlayerData data = new PlayerData();
        data.SFX = SFX;
        data.MUSIC = MUSIC;
        data.MASTER = MASTER;
        data.currentLevel = currentLevel;
        data.ubitiSovrazniki = ubitiSovrazniki;
        data.denar = denar ;
        data.savegameIme = savegameIme;
        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + savegameIme + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + savegameIme + ".dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            MUSIC = data.MUSIC;
            SFX = data.SFX;
            MASTER = data.MASTER;
            currentLevel = data.currentLevel;
             
            ubitiSovrazniki = data.ubitiSovrazniki;
            denar = data.denar;
            savegameIme = data.savegameIme;
            SceneManager.LoadScene(currentLevel);

        }
        else
        {

        }
    }
}
[Serializable]
class PlayerData
{

    public float SFX;
    public float MASTER;
    public float MUSIC;
    public int currentLevel;
    public int ubitiSovrazniki;
    public int denar;
    public string savegameIme;
}