using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultipleChoiceGameManager : MonoBehaviour
{
    public Button backButton;
    public Button startButton;
    public GameObject instructions;
    public Text questionText;
    public GameObject gameOverPanel;
    public GameObject questionAndAnswersPanel;
    public Text scoreText;
    public Text timeLeftText;
    public Text highScore;
    public Text stats;
    public GameObject scoreAlert;
    public Text addedScore;
    public List<Button> answerButtons;

    private DatabaseManager databaseManager;
    private int currentQuestionIndex = 0;
    private List<Flashcard> avaliableFlashcards;
    private List<string> avaliableAnswers;
    private List<string> allAnswers;
    private int totalQuestionsAnswered;
    private int totalCorrectAnswers;
    private float timeLeft = 60;
    private bool gameOver;
    private bool answeredQuestion;
    private int score;
    private int bonusScore;

    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        backButton.onClick.AddListener(Back);
        startButton.onClick.AddListener(StartGame);

        var topicId = PlayerPrefs.GetInt("TopicId");

        var allFlashcards = databaseManager.ExecuteQueryWithReturn<Flashcard>(Queries.GetAllFlashcardsForTopicJumbled, new string[] { topicId.ToString() });

        allAnswers = allFlashcards.Select(x => x.Answer).ToList();

        avaliableFlashcards = allFlashcards.Where(x => x.Included == 1).ToList();
    }

    private void ShowQuestionAndAnswers()
    {
        var question = GetQuestion();
        if(question == null)
        {
            GameOver();
            return;
        }
        answeredQuestion = false;
        StartCoroutine(BonusScoreStopwatch());

        var correctAnswerId = Random.Range(0, 4);

        avaliableAnswers = new List<string>(allAnswers);

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
        if(currentQuestionIndex >= avaliableFlashcards.Count)
        {
            return null;
        }

        return avaliableFlashcards[currentQuestionIndex++];
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
        var pointsToAdd = 5000 + bonusScore;
        MarkAnswer(button, Color.green, pointsToAdd);
    }

    private void MarkAsIncorrect(Button button)
    {
        MarkAnswer(button, Color.red);
    }

    private void MarkAnswer(Button button, Color color, int pointsToAdd = 0)
    {
        answeredQuestion = true;
        StartCoroutine(ChangeAnswerColor(button, color));

        if (pointsToAdd > 0)
        {
            totalCorrectAnswers++;
            score += pointsToAdd;
            addedScore.text = "+" + pointsToAdd.ToString();
            StartCoroutine(AlertManager.ShowAlertForSeconds(scoreAlert, 1f));
        }
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

    private IEnumerator BonusScoreStopwatch()
    {
        bonusScore = 10000;
        while (!answeredQuestion && bonusScore > 0)
        {
            yield return new WaitForSeconds(0.1f);
            bonusScore -= Random.Range(200, 400);
        }

        if(bonusScore < 0)
        {
            bonusScore = 0;
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
        var topicId = PlayerPrefs.GetInt("TopicId");
        var currentHighScore = databaseManager.ExecuteQueryWithReturn<Topic>(Queries.GetTopic, new string[] { topicId.ToString() }).ToList().First().HighScore;

        UpdateHighScore((int)currentHighScore);

        scoreText.text = score.ToString();
        
        stats.text = totalCorrectAnswers + "/" + totalQuestionsAnswered;
        
        gameOverPanel.SetActive(true);
        gameOverPanel.transform.SetAsLastSibling();

        foreach(var button in answerButtons)
        {
            button.interactable = false;
        }
    }

    private void UpdateHighScore(int currentHighScore)
    {
        highScore.text = string.Empty;

        if (score > currentHighScore)
        {
            SetHighScore(score);
            highScore.text = "NEW: " + score.ToString();
        }
        else
        {
            highScore.text = currentHighScore.ToString();
        }
    }

    private void SetHighScore(int score)
    {
        var topicId = PlayerPrefs.GetInt("TopicId");
        databaseManager.ExecuteQueryWithNoReturn(Queries.UpdateHighscore, new string[] { score.ToString(), topicId.ToString() });
    }


}
