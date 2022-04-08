using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public void SelectLevel(){
        SceneManager.LoadScene("SelectLevel");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
