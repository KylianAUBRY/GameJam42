using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;
    
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        SetParam();
    }

    void SetParam()
    {
        if (dir.x < 0) //gauche
            anim.SetInteger("dir", 1);
        else if (dir.x > 0) //droite
            anim.SetInteger("dir", 2);
        else if (dir.y < 0) // bas
            anim.SetInteger("dir", 3);
        else if (dir.y > 0) //haut
            anim.SetInteger("dir", 4);
        else if (dir.x == 0 && dir.y == 0)
            anim.SetInteger("dir", 0);
    }
}
