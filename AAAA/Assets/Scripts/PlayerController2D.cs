using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour {

    public int moveSpeed;
    public int jumpHeight;
    public int extraJumps;
    public int currentPLayerHealth;
    public int maxPlayerHealth;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;


    bool isGrounded;
    Rigidbody2D rb2D;
    int originalExtraJumps;


	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        originalExtraJumps = extraJumps;
        currentPLayerHealth = maxPlayerHealth;
	}
	
	
	void Update () {
	
        Vector2  moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = moveDir;

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
            else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1,1);
        }


        if(Input.GetKeyDown(KeyCode.Space) && extraJumps != 0)
        {
            rb2D.AddForce(new Vector2(0, jumpHeight));
            extraJumps--;
        }

        if(isGrounded)
        {
            extraJumps = originalExtraJumps;
        }
        

        if(currentPLayerHealth <= 0)
        {
            Die();
        }

	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
