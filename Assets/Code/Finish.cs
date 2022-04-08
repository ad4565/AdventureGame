using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void menu(){
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
