using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    //private Animator eAnimator;

    private Animator pAnimator;
    public float speed = 5;

    Rigidbody2D rigidbody2d;
    public static float health = 2000;

    public GameObject healthUIObject;
    public TextMeshProUGUI healthText;

    public GameObject invFull;
    public GameObject attackPrefab;

    public Transform playerObject;

    public float attackCD = 1f;

    static public int score = 0;

    public GameObject scoreTextObject;
    public TextMeshProUGUI scoreText;

    public int shotSpeed = 10;

    public int facing = 0;
    public Rigidbody2D attackRigid;

    static private int keyItem = 0;
    static private int potionItem = 0;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;

    public GameObject potion1;
    public GameObject potion2;
    public GameObject potion3;
    public GameObject potion4;

    public bool potionFull = false;
    public bool keyFull = false;

    public bool potionUsed = false;
    public AudioSource playerWalkSource;
    public AudioSource audioSource;
    public AudioClip playerDeath;
    public AudioClip playerAttack;
    public AudioClip playerHurt;
    public AudioClip potionUse;

    public AudioClip enemyDeath;

    public AudioSource miscSounds;

    public AudioClip enemyAttack;
    public AudioClip doorOpen;

    public AudioClip itemPickup;
    public AudioClip invFullSound;

    private float soundDelay = 1.0f;

    //private enemyController enemyController;

    

    
   
   

    


 
//Debug Objects -TO BE DELETED-
//private float moving;
    
//End Debug Objects


    private void Awake() {
        //enemyController = GameObject.FindObjectOfType<enemyController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {   
        //eAnimator = enemyController.GetComponent<Animator>();
        pAnimator = GetComponent<Animator>();
     rigidbody2d = GetComponent<Rigidbody2D>();
     
    }
    // Update is called once per frame
    void Update()
    {

        soundDelay -= Time.deltaTime;
        //enemyController enemy = enemyController.GetComponent<enemyController>();

        
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("gameover")){
            playerController.health = 2000;
            potionItem = 0;
            keyItem = 0;
            score = 0;
        }

        
        if(playerController.health <= 0){
            audioSource.clip = playerDeath;
            audioSource.Play();
 
            SceneManager.LoadScene(3);
        }
//Deterimes which direction the player is facing
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //int roundedHoz = Mathf.CeilToInt(horizontalInput);
        //int roundedVert = Mathf.CeilToInt(verticalInput);


        if (horizontalInput > 0)
        {
            //pAnimator.speed = 1;
            //pAnimator.SetFloat("Move X", 1);
            //pAnimator.SetFloat("Move Y", 0);
           facing = 1;
          // enemy.AnimationController("Left");

        }
        else if (horizontalInput < 0)
        {
            //pAnimator.speed = 1;
           // pAnimator.SetFloat("Move X", -1);
            //pAnimator.SetFloat("Move Y", 0);
          facing = 2;
          //enemy.AnimationController("Right");
        }
        else if (verticalInput > 0)
        {
            //pAnimator.speed = 1;
            //pAnimator.SetFloat("Move X", 0);
            //pAnimator.SetFloat("Move Y", 1);

           facing = 3;
           //enemy.AnimationController("Up");
        }
        else if (verticalInput < 0)
        {
           // pAnimator.speed = 1;
            //pAnimator.SetFloat("Move X", 0);
           // pAnimator.SetFloat("Move Y", -1);
           facing = 4;
          // enemy.AnimationController("Down");
        }
        //if (roundedHoz == -1 && roundedVert == 1){
        //UpLeft
           // pAnimator.SetFloat("Move X", -1);
           // pAnimator.SetFloat("Move Y", 1);
           // enemy.AnimationController("UpLeft");
       // }
        //if (roundedHoz == 1 && roundedVert == 1){
        //UpRight
           // pAnimator.SetFloat("Move X", 1);
            //pAnimator.SetFloat("Move Y", 1);
            //enemy.AnimationController("UpRight");
       // }
        //if (roundedHoz == 1 && roundedVert == -1){
        //DownLeft
           // pAnimator.SetFloat("Move X", -1);
           // pAnimator.SetFloat("Move Y", -1);
            //enemy.AnimationController("DownLeft");
        //}
        //if (roundedHoz == -1 && roundedVert == -1){
        //DownRight
           // pAnimator.SetFloat("Move X", 1);
            //pAnimator.SetFloat("Move Y", -1);
           // enemy.AnimationController("DownRight");
        //}

//Controls the players animations
        if(horizontalInput >= 0.5f){
            //look right
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", 1);
            pAnimator.SetFloat("Move Y", 0);
        }
        if(horizontalInput <= -0.5f){
            //look left
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", -1);
            pAnimator.SetFloat("Move Y", 0);
        }
        if(verticalInput >= 0.5f){
            //look up
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", 0);
            pAnimator.SetFloat("Move Y", 1);
        }
        if(verticalInput <= -0.5f){
            //look down
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", 0);
            pAnimator.SetFloat("Move Y", -1);
        }

        if(horizontalInput <= -0.5f && verticalInput >= 0.5f){
            //look up left
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", -1);
            pAnimator.SetFloat("Move Y", 1);
        }

        if(horizontalInput <= -0.5f && verticalInput <= -0.5f){
            //look down left
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", -1);
            pAnimator.SetFloat("Move Y", -1);
        }

        if(horizontalInput >= 0.5f && verticalInput >= 0.5f){
            //look up right
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", 1);
            pAnimator.SetFloat("Move Y", 1);
        }

        if(horizontalInput >= 0.5f && verticalInput <= -0.5f){
            //look down right
            pAnimator.speed = 1;
            pAnimator.SetFloat("Move X", 1);
            pAnimator.SetFloat("Move Y", -1);
        }

//Puts A delay between attacks
        attackCD -= Time.deltaTime;

//Lower Health by 1 per second
        int roundedHealth = Mathf.CeilToInt(playerController.health);
        playerController.health -= Time.deltaTime;
        healthText.text = "Health: " + roundedHealth.ToString();
//Press Escape to quit
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

//Spawns prefab of attack
        if(attackCD <= 0){
            if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)){

                audioSource.clip = playerAttack;
                audioSource.Play();

                Shoot();
                
                attackCD = 1f;
            }
        }

        if(Input.GetKeyDown(KeyCode.X)){
            potionUsed = true;

            if(potionItem >= 1){
                potionItem  --;
                audioSource.clip = potionUse;
                audioSource.Play();
                if(potionUsed == true){
                    foreach(GameObject go in GameObject.FindGameObjectsWithTag("Enemy")){
                        Destroy(go);

                    potionUsed = false;
                    }
                }
            }
        }
//Updates the player score
        scoreText.text = "Score: " + score;
        

//Controls the visable inventory

            if(keyItem == 0){
                key1.SetActive(false);
                key2.SetActive(false);
                key3.SetActive(false);
                key4.SetActive(false);
            }
            if(keyItem == 1){
                key1.SetActive(true);
                key2.SetActive(false);
                key3.SetActive(false);
                key4.SetActive(false);
            }

            if(keyItem == 2){
                key1.SetActive(true);
                key2.SetActive(true);
                key3.SetActive(false);
                key4.SetActive(false);
            }

            if(keyItem == 3){
                key1.SetActive(true);
                key2.SetActive(true);
                key3.SetActive(true);
                key4.SetActive(false);
            }

            if(keyItem == 4){
                key1.SetActive(true);
                key2.SetActive(true);
                key3.SetActive(true);
                key4.SetActive(true);
            }

        

            if(potionItem == 0){
                potion1.SetActive(false);
                potion2.SetActive(false);
                potion3.SetActive(false);
                potion4.SetActive(false);
            }

            if(potionItem == 1){
                potion1.SetActive(true);
                potion2.SetActive(false);
                potion3.SetActive(false);
                potion4.SetActive(false);
            }

            if(potionItem == 2){
                potion1.SetActive(true);
                potion2.SetActive(true);
                potion3.SetActive(false);
                potion4.SetActive(false);
            }

            if(potionItem == 3){
                potion1.SetActive(true);
                potion2.SetActive(true);
                potion3.SetActive(true);
                potion4.SetActive(false);
            }

            if(potionItem == 4){
                potion1.SetActive(true);
                potion2.SetActive(true);
                potion3.SetActive(true);
                potion4.SetActive(true);
            }

            if(potionItem >= 4){
                potionFull = true;
            }

            if(keyItem >= 4){
                keyFull = true;
            }

            if(keyItem < 4){
                keyFull = false;
            }

            if(potionItem < 4){
                potionFull = false;
            }







    }
//Player Movement
    void FixedUpdate() {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        
       if(horizontal == 0 && vertical == 0){
            
            playerWalkSource.mute = true;
            pAnimator.speed = 0;
            
        }
        
        
        else{
            
            playerWalkSource.mute = false;
            
        }

    }
//Enemy and Object Collision
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            playerController.health = playerController.health - 10;
            miscSounds.clip = enemyAttack;
            miscSounds.Play();
            Destroy(other.gameObject);
        }

        if(other.gameObject.name == "wall"){
            if(keyItem > 0 ){
                miscSounds.clip = doorOpen;
                miscSounds.Play();
                Destroy(other.gameObject);
                keyItem -= 1;
            }
        }

//!!!REMOVE AFTER TESTING!!!
        if(other.gameObject.name == "instadeath"){
            SceneManager.LoadScene(3);
        }
    }
//Spawns attack prefab and passes it player facing direction and attack movement speed
    void Shoot(){
       
        GameObject attackObject = Instantiate(attackPrefab, new Vector3(playerObject.position.x, playerObject.position.y, playerObject.position.z), Quaternion.identity, playerObject);
        projectileScript projectile = attackObject.GetComponent<projectileScript>();
        projectile.Shoot(facing, 10); 
    }

//Recieves score value from other gameobjects and adds it to score
    public void Score(int scoreValue){
        score += scoreValue;
        
    }

    public void playerInventory(string item){
        if(item == "Key"){
            if(keyItem < 4){
            keyItem += 1;
            miscSounds.clip = itemPickup;
            miscSounds.Play();
            }
        }
        if(item == "Potion"){
            if(potionItem < 4){
            potionItem += 1;
            miscSounds.clip = itemPickup;
            miscSounds.Play();
            }
        }

    }

    public void Sounds(string type){
        if(type == "Enemy"){
            miscSounds.clip = enemyDeath;
            miscSounds.Play();

        }

        if(type == "Full" && soundDelay <= 0){

                miscSounds.clip = invFullSound;
                miscSounds.Play();
                soundDelay = 1.0f;
                
            
        }

        if(type == "Item"){
            miscSounds.clip = itemPickup;
            miscSounds.Play();
        }
    }




}




