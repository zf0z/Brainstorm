using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultipleChoiceGameManager : MonoBehaviour
{

    private DatabaseManager databaseManager;

    public Button backButton;
    public Button startButton;
    public GameObject instructions;
    public Text questionText;
    public GameObject gameOverPanel;
    public GameObject questionAndAnswersPanel;
    public Text scoreText;
    public Text timeLeftText;

    public List<Button> answerButtons;

    private int currentQuestionIndex = 0;
    private List<Flashcard> flashcards;
    private List<string> avaliableAnswers;

    private int totalQuestionsAnswered;
    private int totalCorrectAnswers;
    private float timeLeft = 60;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        backButton.onClick.AddListener(Back);
        startButton.onClick.AddListener(StartGame);

        var topicId = PlayerPrefs.GetInt("TopicId");

        flashcards = databaseManager.ExecuteQueryWithReturn<Flashcard>("SELECT * FROM Flashcards WHERE TopicId = " + topicId + " ORDER BY RANDOM()");

    }

    private void ShowQuestionAndAnswers()
    {
        var question = GetQuestion();
        if(question == null)
        {
            GameOver();
            return;
        }

        var correctAnswerId = Random.Range(0, 4);

        avaliableAnswers = flashcards.Select(x => x.Answer).ToList();
        avaliableAnswers.Remove(question.Answer);

        questionText.text = question.Question;

        for (int i = 0; i < 4; i++)
        {
            var button = answerButtons[i];
            button.onClick.RemoveAllListeners();

            if (i == correctAnswerId)
            {

                button.gameObject.GetComponentInChildren<Text>().text = question.Answer;
                button.onClick.AddListener(() => MarkAsCorrect(button));
            }
            else
            {
                button.gameObject.GetComponentInChildren<Text>().text = GetRandomAnswer();
                button.onClick.AddListener(() => MarkAsIncorrect(button));
            }
        }
    }

    private Flashcard GetQuestion()
    {
        if(currentQuestionIndex >= flashcards.Count)
        {
            return null;
        }

        return flashcards[currentQuestionIndex++];
    }

    private string GetRandomAnswer()
    {
        var randomAnswer = avaliableAnswers[Random.Range(0, avaliableAnswers.Count)];

        avaliableAnswers.Remove(randomAnswer);

        return randomAnswer;
    }

    IEnumerator ChangeAnswerColor(Button button, Color color)
    {
        totalQuestionsAnswered++;

        button.GetComponent<Image>().color = color;

        yield return new WaitForSeconds(0.5f);

        button.GetComponent<Image>().color = Color.white;

        ShowQuestionAndAnswers();
    }

    private void MarkAsCorrect(Button button)
    {
        totalCorrectAnswers++;
        StartCoroutine(ChangeAnswerColor(button, Color.green));
    }

    private void MarkAsIncorrect(Button button)
    {
        StartCoroutine(ChangeAnswerColor(button, Color.red));
    }

    private IEnumerator CountdownTimer()
    {
        while(timeLeft > 0f && !gameOver)
        {
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
            timeLeftText.text = timeLeft.ToString();
        }

        if(timeLeft <= 0f)
        {
            GameOver();
        }
    }

    private void Back()
    {
        SceneManager.LoadScene("Topic");
    }

    private void StartGame()
    {
        instructions.SetActive(false);
        questionAndAnswersPanel.SetActive(true);

        StartCoroutine(CountdownTimer());
        ShowQuestionAndAnswers();
    }

    private void GameOver()
    {
        gameOver = true;
        scoreText.text = totalCorrectAnswers + " / " + totalQuestionsAnswered;
        gameOverPanel.SetActive(true);
        gameOverPanel.transform.SetAsLastSibling();

        foreach(var button in answerButtons)
        {
            button.interactable = false;
        }
    }

}
