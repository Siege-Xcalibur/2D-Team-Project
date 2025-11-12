using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerAnimControls : MonoBehaviour
{
    Animator animator;
    SpriteRenderer SPR;
    // Start is called before the first frame update
    void Start()
    {
       animator= GetComponent<Animator>(); 
        SPR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = GetComponent<Rigidbody2D>().velocity.y;
        animator.SetFloat("x",moveX);
        animator.SetFloat("y",moveY);
       if(moveX < 0)
        {
            //we're moving to the left
            //flip our sprite
            SPR.flipX = true;
        }
       else if(moveX > 0)
        {
            SPR.flipX = false;
        }
    }
}
