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
        denar = 0;
        ubitiSovrazniki = 0;
        currentLevel = 1;
        MUSIC = 0.5f;
        MASTER = 0.5f;
        SFX = 0.5f;
        Debug.Log(Application.persistentDataPath.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.SFX = SFX;
        data.MUSIC = MUSIC;
        data.MASTER = MASTER;
        data.currentLevel = currentLevel;
        data.ubitiSovrazniki = ubitiSovrazniki;
        data.denar = denar ;
        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            MUSIC = data.MUSIC;
            SFX = data.SFX;
            MASTER = data.MASTER;
            currentLevel = data.currentLevel;
            Debug.Log(currentLevel);
             
            ubitiSovrazniki = data.ubitiSovrazniki;
            denar = data.denar;
   
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
}