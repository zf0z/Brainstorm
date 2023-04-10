using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubjectManager : MonoBehaviour
{
    private DatabaseManager databaseManager;

    public Button buttonPrefab;
    public Transform buttonParent;
    public Text subjectNameText;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        var id = PlayerPrefs.GetInt("SubjectId").ToString();

        var subject = databaseManager.ExecuteQueryWithReturn<Subject>(Queries.GetSubject, new string[] { id }).First();

        subjectNameText.text = subject.SubjectName;

        backButton.onClick.AddListener(Back);

        var topics = databaseManager.ExecuteQueryWithReturn<Topic>(Queries.GetAllTopicsForSubject, new string[] { id });

        foreach (var topic in topics)
        {
            var button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<Text>().text = topic.TopicName;
            button.onClick.AddListener(() => LoadTopicPage(topic.Id));
        }
    }

    private void Back()
    {
        SceneManager.LoadScene("Homepage");
    }

    private void LoadTopicPage(long topicId)
    {
        PlayerPrefs.SetInt("TopicId", (int)topicId);
        SceneManager.LoadScene("Topic");
    }
}
