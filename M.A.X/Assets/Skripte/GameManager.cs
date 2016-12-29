using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public static int currentLevel;

    public static int ubitiSovrazniki;

    public static int denar;

    Igralec igralec;

    Sovraznik[] sovrazniki;
    float cas;

    void Start()
    {
        
        ubitiSovrazniki = 0;

        denar = 0;

        igralec = FindObjectOfType<Igralec>();
        igralec.ObSmrti += RestartGame;

        sovrazniki = FindObjectsOfType<Sovraznik>();
        foreach(Sovraznik s in sovrazniki)
        {
            s.ObSmrti += PovecajStUbitihSovraznikov;
           
        }
    }
    void Update()
    {
        GameControl.control.cas += Time.unscaledDeltaTime * 1f;
    }

    public static void RestartGame()
    {
        Debug.Log("SMRT");
        SceneManager.LoadScene(GameControl.control.currentLevel);
        //SceneManager.LoadScene(currentLevel);
    }

    void PovecajStUbitihSovraznikov()
    {

        GameControl.control.ubitiSovrazniki += 1;
    }

    public static void DodajDenar(int value)
    {
       
        denar += value;
        GameControl.control.denar += value;
        Debug.Log("Denar " + denar);
    }

}
