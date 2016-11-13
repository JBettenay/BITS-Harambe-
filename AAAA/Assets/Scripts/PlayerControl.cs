using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public int moveSpeed; 
	public int jumpHeight; 

	Rigidbody2D rb2D;


	void Start () {
		rb2D = GetComponent<Rigidbody2D>();

	}
	

	void Update () {
		Vector2 moveDir = new Vector2(Input.GetAxisRaw ("Horizontal") * moveSpeed, rb2D.velocity.y);
		rb2D.velocity = moveDir;
	
		if (Input.GetAxisRaw ("Horizontal") == 1) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (Input.GetAxisRaw ("Horizontal") == -1) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}	
	}

    void OnCollisionStay2D(Collision2D coll) // C#, type first, name in second
    {
        if (coll.gameObject.tag == "Ground" && (Input.GetKey(KeyCode.W)))
        {
            //Jump Script
            rb2D.AddForce(Vector3.up * jumpHeight * Time.deltaTime);

        }





    }


}
