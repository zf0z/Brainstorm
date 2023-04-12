using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomTopicManager : FormManager
{
    private InputField topicNameInput;

    public override void Initialize()
    {
        topicNameInput = GameObject.Find("TopicNameInput").GetComponent<InputField>();
        inputFields.Add(topicNameInput);

        base.Initialize();
    }

    public override void AddToDatabase()
    {
        var subjectId = PlayerPrefs.GetInt("SubjectId").ToString();
        databaseManager.ExecuteQueryWithNoReturn(Queries.CreateTopic, new string[] { topicNameInput.text, subjectId });
    }

    public override void RefreshPage()
    {
        var topicId = databaseManager.ExecuteQueryWithReturn<Topic>(Queries.GetLatestAddedTopic).First().Id;
        PlayerPrefs.SetInt("TopicId", (int)topicId);
        SceneManager.LoadScene("Topic");
    }
}
