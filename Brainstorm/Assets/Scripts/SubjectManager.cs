using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubjectManager : MonoBehaviour
{
    public Button ButtonPrefab;
    public Transform buttonParent;
    private DatabaseManager databaseManager;

    public Text subjectNameText;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        int id = PlayerPrefs.GetInt("SubjectId");

        var subject = databaseManager.ExecuteQueryWithReturn<Subject>("SELECT SubjectName FROM Subjects WHERE Id = " + id).First();

        subjectNameText.text = subject.SubjectName;

        backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene("Homepage");
    }
}
