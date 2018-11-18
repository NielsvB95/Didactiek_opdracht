using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionStarter : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject questionManager = GameObject.FindGameObjectWithTag("QuestionManager");
    }
}
