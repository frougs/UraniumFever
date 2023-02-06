using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimator : MonoBehaviour
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

    private void Awake() {
        playerController = GameObject.FindObjectOfType<playerController>();
    }
    void Start()
    {
        eAnimator = GetComponent<Animator>();
        e_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        player = GameObject.Find("Player").transform;
        e_rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));

        playerposX = player.position.x;
        playerposY = player.position.y;
        

        int playerxRound = Mathf.CeilToInt(playerposX);
        int playeryRound = Mathf.CeilToInt(playerposY);

        if(playerposY == 0 && playerposX <= -1){
            //Left
            Debug.Log("moving left");
            eAnimator.SetFloat("Move X", 1);
            eAnimator.SetFloat("Move Y", 0);
            //eAnimator.SetInteger("direction", 2);
        }
        if(playerposY <= 0 && playerposX == 1){
          //Right
          Debug.Log("Moving Right");
            eAnimator.SetFloat("Move X", -1);
            eAnimator.SetFloat("Move Y", 0);
            //eAnimator.SetInteger("direction", 1);
        }
        if(playerposY >= 1 && playerposX == 0){
          //Up
          Debug.Log("Up");
            eAnimator.SetFloat("Move X", 0);
            eAnimator.SetFloat("Move Y", 1);
           // eAnimator.SetInteger("direction", 3);
        }
        if(playerposY <= -1 && playerposX == 0){
            //Down
            Debug.Log("down");
            eAnimator.SetFloat("Move X", 0);
            eAnimator.SetFloat("Move Y", -1);
           // eAnimator.SetInteger("direction", 0);
         }
        //if(playerposY == 1 && playerposX == -1){
            //UpLeft
           // eAnimator.SetFloat("Move X", -1);
           // eAnimator.SetFloat("Move Y", 1);
       // }
       // if(playerposY == 1 && playerposX == 1){
            //UpRight
          //  eAnimator.SetFloat("Move X", 1);
           // eAnimator.SetFloat("Move Y", 1);
       // }
        //if(playerposY == -1 && playerposX == -1){
            //DownLeft
           //eAnimator.SetFloat("Move X",-1);
           // eAnimator.SetFloat("Move Y", -1);
       // }
        //if(playerposY == -1 && playerposX == -1){
            //DownRight
            //eAnimator.SetFloat("Move X", 1);
           // eAnimator.SetFloat("Move Y", -1);

        //}
    }

    public void healthController(int damage){
        health -= damage;
    }


}
