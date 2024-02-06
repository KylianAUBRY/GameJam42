using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJodiMovment : MonoBehaviour
{
	public float speed = 5f;
	public Rigidbody2D rb;
	Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
		rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
	}
}
