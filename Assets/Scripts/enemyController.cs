using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private Transform player;
    public float speed = 10;

    private int health = 1;

    Rigidbody2D e_rigidbody2D;

    public int scoreValue = 10;

    private playerController playerController;

    private Animator eAnimator;

    private float playerposX;
    private float playerposY;


    // Start is called before the first frame update
    void Start()
    {
        e_rigidbody2D = GetComponent<Rigidbody2D>();
        eAnimator = GetComponent<Animator>();
        
    }

    private void Awake() {
        playerController = GameObject.FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        e_rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));

        playerposX = player.position.x;
        playerposY = player.position.y;

        float enemyposY = transform.position.y;
        float enemyposX = transform.position.x;

        float testposY = playerposY - enemyposY;
        float testposX = playerposX - enemyposX;


        int playerxRound = Mathf.CeilToInt(testposX);
        int playeryRound = Mathf.CeilToInt(testposY);

        if(testposX >= 1){
            //right
            eAnimator.SetFloat("Move X", 2);
            eAnimator.SetFloat("Move Y", 0);
        }
        if(testposX <= -1){
            //left
            eAnimator.SetFloat("Move X", -2);
            eAnimator.SetFloat("Move Y", 0);
        }
        if(testposY >= 1){
            //up
            eAnimator.SetFloat("Move X", 0);
            eAnimator.SetFloat("Move Y", 1);
        }
        if(testposY <= -1){
            //down
            eAnimator.SetFloat("Move X", 0);
            eAnimator.SetFloat("Move Y", -1);
        }

        if(testposY <= -1 && testposX <= -1){
            //downleft
            eAnimator.SetFloat("Move X", -1);
            eAnimator.SetFloat("Move Y", -1);
        }
        if(testposY <= -1 && testposX >= 1){
            //downright
            eAnimator.SetFloat("Move X", 1);
            eAnimator.SetFloat("Move Y", -1);
        }
        if(testposY >= 1 && testposX <= -1){
            //upleft
            eAnimator.SetFloat("Move X", -1);
            eAnimator.SetFloat("Move Y", 1);

        }
        if(testposY >= 1 && testposX >= 1){
            //upright
            eAnimator.SetFloat("Move X", 1);
            eAnimator.SetFloat("Move Y", 1);
        }


        
      
        if(health <= 0){
            
   
            Destroy(gameObject);
            
            playerController player = playerController.GetComponent<playerController>();
            player.Score(scoreValue);
            player.Sounds("Enemy");



        }


         

    }

    public void healthController(int damage){
        health -= damage;
    }

    private void FixedUpdate() {
        //if(playerposY == 0 && playerposX == -1){
            //Left
            //eAnimator.SetFloat("Move X", 1);
            //eAnimator.SetFloat("Move Y", 0);
            //eAnimator.SetInteger("direction", 2);
        //}
        //if(playerposY == 0 && playerposX == 1){
          //Right
            //eAnimator.SetFloat("Move X", -1);
           // eAnimator.SetFloat("Move Y", 0);
            //eAnimator.SetInteger("direction", 1);
       // }
        //if(playerposY == 1 && playerposX == 0){
          //Up
            //eAnimator.SetFloat("Move X", 0);
            //eAnimator.SetFloat("Move Y", 1);
            //eAnimator.SetInteger("direction", 3);
       // }
        //if(playerposY == -1 && playerposX == 0){
            //Down
            //eAnimator.SetFloat("Move X", 0);
            //eAnimator.SetFloat("Move Y", -1);
            //eAnimator.SetInteger("direction", 0);
        // }
       // if(playerposY == 1 && playerposX == -1){
            //UpLeft
          //  eAnimator.SetFloat("Move X", -1);
          //  eAnimator.SetFloat("Move Y", 1);
       // }
        //if(playerposY == 1 && playerposX == 1){
            //UpRight
           // eAnimator.SetFloat("Move X", 1);
           // eAnimator.SetFloat("Move Y", 1);
       // }
       // if(playerposY == -1 && playerposX == -1){
            //DownLeft
            //eAnimator.SetFloat("Move X",-1);
           // eAnimator.SetFloat("Move Y", -1);
       // }
        //if(playerposY == -1 && playerposX == -1){
            //DownRight
           // eAnimator.SetFloat("Move X", 1);
           // eAnimator.SetFloat("Move Y", -1);

        //}
    }
    
       



}
