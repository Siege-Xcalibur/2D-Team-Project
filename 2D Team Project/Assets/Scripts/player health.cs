using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerhealth : MonoBehaviour
{
    AudioSource audioSource;
    //what sound do we want to play
    public AudioClip DamageSound;
    //store the players health
    public float health = 10;
    float maxHealth;
    //we need a reference to our healthbar game object
    public Image healthBar;
    //if we collide with  something tagged as Enemy, take damage
    //if health gets too low, we die (reload the level)
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.gameObject.tag=="Enemy")
        {
            if (audioSource != null && DamageSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(DamageSound);
            }
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health gets too low, we die (reload the level)
            if(health<=0)
            {
                //reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (audioSource != null && DamageSound != null)
            {
                //play the jump sound
                audioSource.PlayOneShot(DamageSound);
            }
            Destroy(collision.gameObject);
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health gets too low, we die (reload the level)
            if (health <= 0)
            {
                //reload the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 
