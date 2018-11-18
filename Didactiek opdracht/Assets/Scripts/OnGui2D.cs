using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGui2D : MonoBehaviour {

    public static int score;
	// Use this for initialization
	void Start () {
        score = 0; // set score to 0
	}

    void OnGUI()
    {
        //keep track of score (not readable now in the top left corner)
        GUI.Label(new Rect(0, 0, 100, 20), "Score: " + score);    
    }

}
