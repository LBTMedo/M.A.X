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

    public static void RestartGame()
    {
        SceneManager.LoadScene(currentLevel);
    }

    void PovecajStUbitihSovraznikov()
    {
        ubitiSovrazniki++;
    }

    public static void DodajDenar(int value)
    {
        denar += value;
        Debug.Log("Denar: " + denar.ToString());
    }

}
