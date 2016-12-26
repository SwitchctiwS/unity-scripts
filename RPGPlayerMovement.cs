using UnityEngine;
using System.Collections;

public class RPGPlayerMovement : MonoBehaviour {
    public float speed = 1;

    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.MovePosition(rb2d.position + (movement * Time.fixedDeltaTime) * speed);
	}
}