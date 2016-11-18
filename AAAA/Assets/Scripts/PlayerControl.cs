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
    
    public int restartDelay = 5;
    private GameObject Gameover2;
    private float cooldownTimer = 0.0f;
    public float damageCooldown = 1.0f;
    public int damage2 = 10;
    public Transform SpawnPoint;
    public bool respawn = false;
    public static bool playerAlive = false;
    public GameObject go;
    public Image image2;
    public GameObject go2;
    public Text text2;
   


    public static Rigidbody2D rb2D;

    void Awake()
    {
        if (playerLives < 3)
        {
           
            ResetPlayer();

        }

    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        go = GameObject.Find("StartScreenImage");
        image2 = go.GetComponent<Image>();
        go = GameObject.Find("StartScreenText");
        text2 = go.GetComponent<Text>();
    }



    void Update()
    {

        if (playerAlive == false && Input.GetKey(KeyCode.Return))
        {
            playerAlive = true;
            UnloadStartScreen();
            rb2D.position = SpawnPoint.position;
            playerHealth = 100;
            playerLives = 3;

        }





        

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

        cooldownTimer -= Time.deltaTime;

        if ((playerHealth <= 0) &&  (playerLives > 0))
            {
            respawn = true;
            Debug.Log("PLAYER RESPAWN TIME");

        }
        else
        {
            respawn = false;
        }
        if (respawn)
        {

            rb2D.position = SpawnPoint.position;
            

        }
        
    }

    void OnCollisionStay2D(Collision2D coll) // C#, type first, name in second
    {
 

        if ((coll.gameObject.tag == "Ground"  && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) || coll.gameObject.tag == "Spikes" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))))
        
        {
            Debug.Log("GROUND");
            //Jump Script
            rb2D.AddForce(Vector3.up * jumpHeight * Time.deltaTime);

        }

        if ((coll.gameObject.tag == "Spikes") && (cooldownTimer <= 0))


        {
            // StartCoroutine(damage(10));

            damage(damage2);
            cooldownTimer = damageCooldown;

            
            Debug.Log("TestCollision", gameObject);
            
            Debug.Log(playerHealth);
            
            

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

             rb2D.transform.position = SpawnPoint.position;
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
        //  DestroyObject(rb2D);
        playerAlive = false;
        LoadStartScreen();

    }

    public void damage(int damage3)

    {

      //  Debug.Log("HEALTH: "+ playerHealth);
        playerHealth -= damage3;
     //   Debug.Log("DAMAGE: " + damage3);
        if (playerHealth <= 0)
        {
            ResetPlayer();
            Debug.Log("KILL PLAYER");
        }

    }

    public  void UnloadStartScreen()
    {
        image2.color = new Color32(34, 114, 141, 0);
        text2.color = new Color32(34, 114, 141, 0);

    }

    public void LoadStartScreen()
    {
        image2.color = new Color32(34, 114, 141, 255);
        text2.color = new Color32(34, 114, 141, 255);


    }



}
