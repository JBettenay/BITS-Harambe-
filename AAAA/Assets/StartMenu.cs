using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
    public Image image;
    public GameObject text;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static void startMenuOpen()
    {
    //    image.GetComponent<Image>().color = new Color32(34, 114, 141, 255);
  //      text.GetComponent<Image>().color = new Color32(0, 255, 107, 255);

        Debug.Log("Start Menu Open");
    }
    public static void startMenuClose()
    {
    //    image.GetComponent<Image>().color = new Color32(34, 114, 141, 0);
   //     text.GetComponent<Image>().color = new Color32(0, 255, 107, 0);
       
        Debug.Log("Start Menu Close");
    }
}
