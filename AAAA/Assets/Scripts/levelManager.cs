using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {

    public static int playerLives;
    
    public GameObject spawnPoint;

    private PlayerControl Player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public static void RespawnPlayer()
    {
        if (playerLives <= 0)
        {
            // Reload game from start menu


        }
     //   else
     //   {
     //       Destroy(Player);
     //       Instantiate(Player, spawnPoint.transform.position, Quaternion.identity);
     //
       // }
    }



}

