using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelnokey : MonoBehaviour
{
    public string levelToLoad="Level 1";
    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player") ){// 
            SceneManager.LoadScene(levelToLoad);
        }
    }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("Player") ){// 
    //         SceneManager.LoadScene(levelToLoad);
    // }

}
