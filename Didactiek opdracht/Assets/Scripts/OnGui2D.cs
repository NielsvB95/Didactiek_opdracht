using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGui2D : MonoBehaviour {

    public static int score;
	// Use this for initialization
	void Start () {
        score = 0;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), "Score: " + score);    
    }

}
