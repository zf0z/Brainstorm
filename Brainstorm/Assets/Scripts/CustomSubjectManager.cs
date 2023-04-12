using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomSubjectManager : FormManager
{
    private InputField subjectName;
    public override void Initialize()
    {
        subjectName = GameObject.Find("SubjectNameInput").GetComponent<InputField>();
        inputFields.Add(subjectName);

        base.Initialize();
    }

    public override void AddToDatabase()
    {
        databaseManager.ExecuteQueryWithNoReturn(Queries.CreateSubject, new string[] { subjectName.text });
    }

    public override void RefreshPage()
    {
        SceneManager.LoadScene("Homepage");
    }
}
