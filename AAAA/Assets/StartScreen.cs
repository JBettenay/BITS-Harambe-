using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class StartScreen : MonoBehaviour {

   
    
    public static Image background;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("RETURN KEY PRESSED");
            UnloadStartScreen();
        }

    }
    public static void UnloadStartScreen()
    {
     //   StartScreenBG.image.color
                
    }
}
