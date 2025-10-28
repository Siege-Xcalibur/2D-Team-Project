using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class colletables : MonoBehaviour
{
    //store the number of collected items in a variable
    public int cash= 0;
    public TMP_Text text;
    //whenever the player collide with an object, see if it is a collectable
    //if it is a collectable, add to the count
    //destroy the collected item so we can't spam collect
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "cash")
        {
            cash++;
            text.text = "Cash: " + cash;
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
