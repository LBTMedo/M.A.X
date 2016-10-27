using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public static int currentLevel;

    Igralec igralec; 

    void Start()
    {
        igralec = FindObjectOfType<Igralec>();
        igralec.ObSmrti += RestartGame;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(currentLevel);
    }

}
