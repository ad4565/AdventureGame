using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotCode : MonoBehaviour
{
    NavMeshAgent _navAgent;
    GameObject player;
    void Start()
    {
       _navAgent=GetComponent<NavMeshAgent>(); 
       player=GameObject.FindGameObjectWithTag("Player");
       StartCoroutine(FindPlayer());
    }
    IEnumerator FindPlayer(){
        while(true){
            yield return new WaitForSeconds(1.5f);
            _navAgent.destination=player.transform.position;
        }

    }
    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    
    
}

