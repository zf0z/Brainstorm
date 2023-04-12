using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomFlashcardManager : FormManager
{
    private InputField answerInput;
    private InputField questionInput;

    public override void Initialize()
    {
        answerInput = GameObject.Find("AnswerInput").GetComponent<InputField>();
        questionInput = GameObject.Find("QuestionInput").GetComponent<InputField>();

        inputFields.Add(answerInput);
        inputFields.Add(questionInput);

        base.Initialize();
    }

    public override void AddToDatabase()
    {
        var topicId = PlayerPrefs.GetInt("TopicId").ToString();
        databaseManager.ExecuteQueryWithNoReturn(Queries.CreateFlashcard, new string[] { questionInput.text, answerInput.text, topicId });
    }

    public override void RefreshPage()
    {
        SceneManager.LoadScene("Topic");
    }
}
