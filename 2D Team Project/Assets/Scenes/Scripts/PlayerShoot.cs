using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public float shootSpeed = 10;
    public float bulletlifetime = 2f;
    public float shootDelay = 0.5f;
    float timer = 0;
    AudioSource audiosource;
    public AudioClip ShootSound;
    // Start is called before the first frame update
    void Start()
    {
      audiosource = Camera.main.GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
        //track how much time has passed
        //delta = change/ difference
        // Time.deltaTime is the change/difference of time between frame updates
        //60 frames/second, 1/60= 0.1666s every frame
        //if we press the "shoot button" (left click) and enough time has passed
        timer += Time.deltaTime;
        //if we press the shoot "button" (left click)
        if(Input.GetButton("Fire1") && timer > shootDelay)
        {
            if (audiosource != null && ShootSound != null)
            {
                audiosource.PlayOneShot(ShootSound);
            }
            //reset out timer
            timer = 0;
            //get the mouse's position in the game
            Vector3 mousePos= new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            mousePos.z = -Camera.main.transform.position.z;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spwan a bullet
            GameObject  bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet in the direction of the mouse
            //destination (mousePosition) - starting position (transform.position)
            Vector3 mouseDir=mousePos -transform.position;
            mouseDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * shootSpeed;
            Destroy(bullet, bulletlifetime);



        }
        
    }
}
