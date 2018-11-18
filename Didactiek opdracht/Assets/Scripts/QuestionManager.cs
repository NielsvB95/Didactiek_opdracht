using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unanswerdQuestions; //list of unanswserd questions

    private Question currentQuestion;  //the question which is displayed

    public GameObject questionMenu; //the question menu

    public static bool gameIsPaused = false; //if the game is paused or not

    [SerializeField]
    private Text factText; //fact/question value

    [SerializeField]
    private float timeBetweenQuestionandGame = 1f; // wait for a second if the player answerd the question
    void Start()
    {
        if (unanswerdQuestions == null || unanswerdQuestions.Count == 0)
        {
            unanswerdQuestions = questions.ToList<Question>(); 
        }
        SetCurrentQuestion();
    }
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unanswerdQuestions.Count); // pick a random question from the question list
        currentQuestion = unanswerdQuestions[randomQuestionIndex]; //set the current question in the unanswerd questions

        factText.text = currentQuestion.fact; // set the text of the question
    }

    IEnumerator TransissiontoNextQuestion()
    {
        unanswerdQuestions.Remove(currentQuestion); //remove the currentquestion from the unanswerquestions

        yield return new WaitForSeconds(timeBetweenQuestionandGame); //time between the question menu and the game

        Time.timeScale = 1; // wait for 1 second
    }

    public void UserSelectTrue() //if the user selects true
    {
        if (currentQuestion.istrue)
        {
            OnGui2D.score -= 20; // set score -20 if the answer is correct (lower score is better)
        }
        else
        {
            OnGui2D.score += 20; // set score +20 if the answer is correct (higher score is worse)
        }

        StartCoroutine(TransissiontoNextQuestion()); //start time between question and game
    }
    public void UserSelectFalse() //if the user selects false
    {
        if (!currentQuestion.istrue)
        {
            OnGui2D.score -= 20; // set score -20 if the answer is correct (lower score is better)
        }
        else
        {
            OnGui2D.score += 20;  // set score +20 if the answer is correct (higher score is worse)
        }
        StartCoroutine(TransissiontoNextQuestion()); //start time between question and game
    }
    public void Resume() //resume game after a question is answered
    {
        questionMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause() //resume game after a question is started
    {
        questionMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
