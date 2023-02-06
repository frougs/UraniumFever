using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public int damage = 1;
    

    private void Start() {

    }
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }
    

    
    void Update()
    {
        


    }

    public void Shoot(int facing, float speed){

              
            if(facing == 4){
                rigidbody2d.AddForce(Vector3.down * speed *Time.deltaTime);
                
            }

            if(facing == 3){
                rigidbody2d.AddForce(Vector3.up * speed *Time.deltaTime);
                
            }

           if(facing == 1){
                rigidbody2d.AddForce(Vector3.right * speed * Time.deltaTime);
                
            }

           if(facing == 2){
                rigidbody2d.AddForce(Vector3.left * speed * Time.deltaTime);
                
            }


        
    }


    private void OnTriggerEnter2D(Collider2D other) {

            if(other.gameObject.tag == "Enemy"){
                GameObject collideObject = other.gameObject;
                enemyController enemy = collideObject.GetComponent<enemyController>();
                enemy.healthController(damage);
                Destroy(gameObject);
            }

            if(other.gameObject.tag == "Spawner"){
                GameObject collideObject = other.gameObject;
                enemySpawner spawner = collideObject.GetComponent<enemySpawner>();
                spawner.healthController(damage);
                Destroy(gameObject);
            }

            if(other.gameObject.tag == "Environment"){
                Destroy(gameObject);
            }
    }



    
 
    
}
