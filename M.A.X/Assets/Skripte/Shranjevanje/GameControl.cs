using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{

    public static GameControl control;
    public float SFX;
    public float MASTER;
    public float MUSIC;
    public int currentLevel;
    public int ubitiSovrazniki;
    public int denar;
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
        FileStream file = File.Create(Application.persistentDataPath + "/" + savegameIme + ".dat");

        PlayerData data = new PlayerData();
        data.SFX = GameControl.control.SFX;
        data.MUSIC = GameControl.control.MUSIC;
        data.MASTER = GameControl.control.MASTER;
        data.currentLevel = GameControl.control.currentLevel;
        data.ubitiSovrazniki = GameControl.control.ubitiSovrazniki;
        data.denar = GameControl.control.denar;
        data.savegameIme = GameControl.control.savegameIme;
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
            GameControl.control.MUSIC = data.MUSIC;
            GameControl.control.SFX = data.SFX;
            GameControl.control.MASTER = data.MASTER;
            GameControl.control.currentLevel = data.currentLevel;
            GameControl.control.ubitiSovrazniki = data.ubitiSovrazniki;
            GameControl.control.denar = data.denar;
            GameControl.control.savegameIme = data.savegameIme;
            SceneManager.LoadScene(GameControl.control.currentLevel);

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