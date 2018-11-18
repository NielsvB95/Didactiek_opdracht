using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unanswerdQuestions;

    private Question currentQuestion;

    public GameObject questionMenu;

    public static bool gameIsPaused = false;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;
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
        int randomQuestionIndex = Random.Range(0, unanswerdQuestions.Count);
        currentQuestion = unanswerdQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
    }

    IEnumerator TransissiontoNextQuestion()
    {
        unanswerdQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        Time.timeScale = 1;
    }

    public void UserSelectTrue()
    {
        if (currentQuestion.istrue)
        {
            OnGui2D.score -= 20;
        }
        else
        {
            OnGui2D.score += 20;
        }

        StartCoroutine(TransissiontoNextQuestion());
    }
    public void UserSelectFalse()
    {
        if (!currentQuestion.istrue)
        {
            OnGui2D.score -= 20;
        }
        else
        {
            OnGui2D.score += 20;
        }
        StartCoroutine(TransissiontoNextQuestion());
    }
    public void Resume()
    {
        questionMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        questionMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
