using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomTopicManager : MonoBehaviour
{
    private DatabaseManager databaseManager;

    public GameObject createTopicForm;
    public Button openCreateFormButton;
    public Button cancelCreationButton;
    public Button createTopicButton;
    public InputField topicNameInput;
    public Text errorMessage;
    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        openCreateFormButton.onClick.AddListener(OpenCreateTopicForm);
        cancelCreationButton.onClick.AddListener(CloseCreateTopicForm);
        createTopicButton.onClick.AddListener(AddTopicToDatabase);
    }

    private void AddTopicToDatabase()
    {
        if(topicNameInput.text == string.Empty)
        {
            errorMessage.gameObject.SetActive(true);
            errorMessage.text = "TOPIC NAME MUST BE POPULATED!";
        }
        else
        {
            topicNameInput.text = topicNameInput.text.Replace("\'", "''");
            var subjectId = PlayerPrefs.GetInt("SubjectId").ToString();
            databaseManager.ExecuteQueryWithNoReturn(Queries.CreateTopic, new string[] { topicNameInput.text, subjectId });
            CloseCreateTopicForm();

            var topicId = databaseManager.ExecuteQueryWithReturn<Topic>(Queries.GetLatestAddedTopic).First().Id;
            PlayerPrefs.SetInt("TopicId", (int)topicId);
            SceneManager.LoadScene("Topic");
        }
    }

    private void OpenCreateTopicForm()
    {
        createTopicForm.SetActive(true);
    }

    private void CloseCreateTopicForm()
    {
        createTopicForm.SetActive(false);
        errorMessage.gameObject.SetActive(false);
        topicNameInput.text = null;
    }
}
