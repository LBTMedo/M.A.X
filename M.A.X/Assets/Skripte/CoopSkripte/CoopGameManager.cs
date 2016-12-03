using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CoopGameManager : MonoBehaviour {

    public static int currentLevel;

    public static int ubitiSovrazniki;

    public static int denar;

    Igralec[] igralca;

    Sovraznik[] sovrazniki;

    void Start()
    {
        Debug.Log(Application.loadedLevel.ToString());
        ubitiSovrazniki = 0;

        denar = 0;

        igralca = FindObjectsOfType<Igralec>();
        foreach(Igralec i in igralca)
        {
            i.ObSmrti += RestartGame;
        }

        sovrazniki = FindObjectsOfType<Sovraznik>();
        foreach (Sovraznik s in sovrazniki)
        {
            s.ObSmrti += PovecajStUbitihSovraznikov;

        }
    }

    public static void RestartGame()
    {
        GameControl.control.currentLevel = currentLevel;
        SceneManager.LoadScene(currentLevel);
    }

    void PovecajStUbitihSovraznikov()
    {
        ubitiSovrazniki++;
        GameControl.control.ubitiSovrazniki = ubitiSovrazniki;
    }

    public static void DodajDenar(int value)
    {
        denar += value;
        GameControl.control.denar = denar;
        Debug.Log("Denar: " + denar.ToString());
    }

}
