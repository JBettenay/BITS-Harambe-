using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public int moveSpeed;
    public int jumpHeight;
    public string txtToPrint;
    public static int playerHealth = 100;
    public static int playerLives = 3;
    public static Transform respawnPosition;
    public int restartDelay = 5;
    private GameObject Gameover2;

    Rigidbody2D rb2D;

    void Awake()
    {
        if(playerLives < 3)
        {

            ResetPlayer();
            
        }
    
        }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        respawnPosition.position = rb2D.transform.position;
    }



    void Update()
    {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = moveDir;

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }

    void OnCollisionStay2D(Collision2D coll) // C#, type first, name in second
    {
        if (coll.gameObject.tag == "Ground" && (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.Space)))
        {
            Debug.Log("GROUND");
            //Jump Script
            rb2D.AddForce(Vector3.up * jumpHeight * Time.deltaTime);
            
        }





    }
 public void ResetPlayer()

    {
        if (playerLives == 1)
        {
            GameOver();
        }
        else
        {

            // rb2D.transform.position = respawnPosition.position;
            playerLives--;
            playerHealth = 100;
            Debug.Log("RESET PLAYER ELSE");
        }

    }

  public void GameOver()


        
    {
        
       // 
    //END GAME SOMEHOW

      //Gameover2 = GameObject.Find("LifeValue");
       
        Debug.Log("GAME OVER");
        DestroyObject(rb2D);
        
    }

    public void DamagePlayer(int damage)

    {

        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            ResetPlayer();
            Debug.Log("KILL PLAYER");
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spikes")


        {

            Debug.Log("TestCollision", gameObject);
            DamagePlayer(10);
            Debug.Log(playerHealth);


        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Spikes")
        {

            Debug.Log("Test Collider");
            
        }
    }
}
