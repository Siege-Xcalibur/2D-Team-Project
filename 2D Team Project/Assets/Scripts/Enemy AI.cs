using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //refrence to the player object
    GameObject Player;
    //the speed at which the enemy will move
    public float chasespeed = 5.0f;
    //how close the player needs to be for the enemy to start chasing
    public float chaseTriggerDistance = 10f;
    // Start is called before the first frame update
    //do we want the enemy to return home when player gets away?
    public bool returnhome = true;
    //my home position = my starting position
    Vector3 home;
    bool isHome = true;
    //should we patrol or not?
    public bool patrol = true;
    //what direction do we want to patrol in?
    public Vector3 patrolDirection = Vector3.zero;
    public float patrolDistance = 3f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        //home is my starting position when the game is played
        home=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //figure out where the player is, how far away
        //how far away is the player from me, the enemy
        //destination (player position) - Starting position (enemy position)
        //gives the vector from the enemy to the player
        Vector3 chaseDir = Player.transform.position - transform.position;
       //if the player is "close" chase the player
       //if the player gets within chaseTriggerDistance units away, chase the plyaer
       if(chaseDir.magnitude < chasespeed)
        {
            //chase the player
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDir * chasespeed;
            isHome= false; 
        }
        //if the home variable is true, try to get home
        else if(returnhome && !isHome)
        {
            //return home
            Vector3 homeDir = home - transform.position;
            //if  i am far enough away from home, try to go home
            if (homeDir.magnitude > 0.2f)
            {
                homeDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDir * chasespeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
        //do we want to patrol?
        else if  (patrol)
        {
            // have the enemy patrol in a given direction
            //if they get too far away from their starting position, flip their direction
            Vector3 displacement = transform.position - home;
            if(displacement.magnitude > patrolDistance)
            {
                //flip around, we've patrolled too far
                patrolDirection = -displacement;
            }
            //push the enemy in the direction of patrol
            patrolDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = patrolDirection * chasespeed;
        }
       //otherwise, stop moving
       else
        {
            //stop moving, we're close enough
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            isHome = true;
        }
    }
}
