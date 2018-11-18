using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionStarter : MonoBehaviour {

    public QuestionManager questionManager;
    // Use this for initialization
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject questionManager = GameObject.FindGameObjectWithTag("QuestionManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("question");
            questionManager.Pause();
        }
    }
}
