using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemySpawner : MonoBehaviour
{

    public float spawnCD = 4;
    private int spawnCount;

    private int lastSpawn;
//Debug Objects -TO BE DELETED-

//End Debug Objects
    public int spawnCDR;

    private int spawnCountR;


    private GameObject spawnedEnemy;
    
    public Transform parentObject;


    public GameObject enemyPrefab;

    private int active;

    private int spawnDelayR;

    private int health = 2;

    private playerController playerController;

    private int scoreValue = 10;



    // Start is called before the first frame update

    void Awake(){
        playerController = GameObject.FindObjectOfType<playerController>();
    }
    void Start()
    {
      spawnCD = 4; 
    }

    // Update is called once per frame
    void Update()
    {
//Detects if player is in spawning radius before spawning enemy
        active = GameObject.Find("activeRadius").GetComponent<spawnerActivation>().active;

        if(active == 1){
            if(spawnCDR <= 0){
                spawnCD = Random.Range(1, 10);
                spawnCount = Random.Range(1, 4);
                lastSpawn = spawnCountR;

                    for(int i = 0; i < spawnCount; i++ ){
                        Instantiate(enemyPrefab, new Vector3(parentObject.position.x + Random.Range(-2f, 2), parentObject.position.y + Random.Range(-2f, 2), parentObject.position.z+ Random.Range(-2f, 2)), Quaternion.identity);
                    }
            }
        }
        spawnCD -= Time.deltaTime;
        spawnCDR = Mathf.CeilToInt(spawnCD);
        spawnCountR = Mathf.CeilToInt(spawnCount);

      

        if(health <= 0){
            Destroy(gameObject);

            playerController player = playerController.GetComponent<playerController>();
            player.Score(scoreValue);

        }


    }

    public void healthController(int damage){
        health -= damage;

    }


    


}
