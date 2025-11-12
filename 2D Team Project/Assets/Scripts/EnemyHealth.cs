using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //store enemy health
    public int health = 5;
    public int dropChance = 100;
    public GameObject prefab;
    public bool isDead = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float deathTimer = 0;
    void Update()
    {
        //destroy myself if i get too low in health
        if (health <= 0)
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("isDead", true);
            }
            //if we should die, we first want to play the death animation for a second
            deathTimer += Time.deltaTime;
            //note the length of your death animation may vary. default value here is 1 second.
            //NOTE: we moved the destroy code from below to here. if you don't remove it down below,
            //your death  animation will not play
            if (deathTimer > 2)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     { 
        //when I am hit by a player bullet
        if(collision.gameObject.tag =="PlayerBullet")
        {
            //destroy the bullet
            Destroy(collision.gameObject);
            //reduce my hp
            health--;
                //create a random variable to determine if we should drop an item or not
                //maximum of Random.Range is exclusive, so we have to add +1
                int r = Random.Range(1, 101); //give a random variable between 1 and 100
                if (dropChance > r)
                {
                    //drop an item
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
            }
                   
        }
    }
     }    
