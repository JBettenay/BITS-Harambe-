using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AAAHealthManager : MonoBehaviour {

    public int maxPlayerHealth;

    public static int playerHealth;

    Text text;


	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();

        playerHealth = maxPlayerHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (playerHealth <= 0)
       {
            levelManager.RespawnPlayer();
        }

        text.text = " " + playerHealth;
	}

    public static void HurtPlayer(int damageToGive)
  
  {
        playerHealth -= damageToGive;
    }
  

    public void FullHealth ()

    {
        playerHealth = maxPlayerHealth;
    }

}
