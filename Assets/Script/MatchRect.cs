using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRect : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainMenuCamera").GetComponent<Camera>(); ;
        int ratio = Screen.width / Screen.height;
        int width = Screen.height * ratio;
        Debug.Log(ratio + " " + width);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
