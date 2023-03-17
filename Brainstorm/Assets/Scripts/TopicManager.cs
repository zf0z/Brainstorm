using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopicManager : MonoBehaviour
{
    private DatabaseManager databaseManager;

    public Text topicNameText;
    public Button backButton;
    public Button flashcardFrenzyButton;
    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        int topicId = PlayerPrefs.GetInt("TopicId");

        var topic = databaseManager.ExecuteQueryWithReturn<Topic>("SELECT * FROM Topics WHERE Id = " + topicId).First();

        topicNameText.text = topic.TopicName;

        backButton.onClick.AddListener(Back);
        flashcardFrenzyButton.onClick.AddListener(StartFlashcardFrenzy);
    }

    private void Back()
    {
        SceneManager.LoadScene("Subject");
    }

    private void StartFlashcardFrenzy()
    {
        SceneManager.LoadScene("FlashcardFrenzy");
    }
}
