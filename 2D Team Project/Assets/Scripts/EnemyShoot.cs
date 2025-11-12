using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject prefab;
    public float shootSpeed = 10;
    public float bulletlifetime = 2f;
    public float shootDelay = 0.5f;
    float timer = 0;
    GameObject player;
    AudioSource audiosource;
    public AudioClip EnemyShootSound;
    //the distance the player needs to be for us to shoot at them
    public float shootTriggerDistance = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //when the player is in range AND if we've waited out shootDelay
        Vector3 shootDir = player.transform.position - transform.position;
        if (shootDir.magnitude < shootTriggerDistance && timer > shootDelay)
        {
            if (audiosource != null && EnemyShootSound != null)
            {
             audiosource.PlayOneShot(EnemyShootSound);
            }
            //shoot towards the player
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
           //normalize the shoot direction
            shootDir.Normalize();
            //push the bullet towards the player
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * shootSpeed;
            Destroy(bullet, bulletlifetime);
        }
    }
}
