using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerCode : MonoBehaviour
{   

    public class Scoring: MonoBehaviour
    {
        public static int score = 0;
    }
    int bulletForce= 1000;
    public Transform spawnPoint;
    public GameObject player;
    Vector3 position;
    NavMeshAgent _navAgent;
    Camera mainCam;
    public GameObject bulletPrefab;
    int health = 50;
    
    float xPos;
    float yPOs;

    public Animator _animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _navAgent =GetComponent<NavMeshAgent>();
        mainCam=Camera.main;
        _animator = GetComponent<Animator>();
        xPos = transform.position.x;
    }
    private void Update(){

        if(health < 1)
        {
            _animator.SetBool("IsDead", true);
            SceneManager.LoadScene("Death");
        }
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out hit,200)){
                _navAgent.destination=hit.point;
            }
        }
        if(Input.GetMouseButtonDown(1)){
            _animator.SetTrigger("Attacking");
            position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            GameObject newBullet=Instantiate(bulletPrefab,position,transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletForce);
        }
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 150, 50), "Health: " + health);
        GUI.Label(new Rect(0, 20, 150, 50), "Bones Collected: " + Scoring.score);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Troll"))
        {
            _animator.SetTrigger("GotHit");
            health--;
        }
    }


    private void OnTriggerEnter(Collider other){
        if  (other.gameObject.CompareTag("key")){   
            PublicVars.keyNum++;
            Destroy(other.gameObject);
        }
        //print("hit");
        if (other.gameObject.CompareTag("lid") ){
            Destroy(other.gameObject);
            Scoring.score += 1;
        }
        if (other.gameObject.CompareTag("pad") ){
            Destroy(other.gameObject);
        }
    }

    private void FixedUpdate() {
        _animator.SetBool("Moving", _navAgent.hasPath);
    }
}
