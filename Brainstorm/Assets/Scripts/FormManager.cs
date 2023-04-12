using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class FormManager : MonoBehaviour
{
    protected DatabaseManager databaseManager;

    protected GameObject form;
    protected Text errorMessage;
    protected Button cancelButton;
    protected Button submitButton;
    protected List<InputField> inputFields = new List<InputField>();

    public virtual void Initialize()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        form = GameObject.Find("Form");
        cancelButton = GameObject.Find("CancelButton").GetComponent<Button>();
        submitButton = GameObject.Find("CreateButton").GetComponent<Button>();
        errorMessage = GameObject.Find("Error").GetComponent<Text>();

        cancelButton.onClick.AddListener(CloseForm);
        submitButton.onClick.AddListener(SubmitForm);

        form.SetActive(false);
        errorMessage.gameObject.SetActive(false);
    }

    public void OpenForm()
    {
        form.SetActive(true);
    }

    public void CloseForm()
    {
        form.SetActive(false);
        errorMessage.gameObject.SetActive(false);
        ClearInputFields();
    }

    public void SubmitForm()
    {
        if (AllFieldsPopulated())
        {
            SanitizeInputs();
            AddToDatabase();
            CloseForm();
            RefreshPage();
        }
        else
        {
            ShowErrorMessage();
        }
    }

    private void ShowErrorMessage()
    {
        errorMessage.text = ErrorMessageGenerator.GenerateErrorMessage(inputFields);
        errorMessage.gameObject.SetActive(true);
    }
    
    private void ClearInputFields()
    {
        foreach(var inputField in inputFields)
        {
            inputField.text = string.Empty;
        }
    }

    private bool AllFieldsPopulated()
    {
        return inputFields.Where(x => x.text == string.Empty).Count() == 0;
    }

    private void SanitizeInputs()
    {
        foreach(var inputField in inputFields)
        {
            inputField.text = inputField.text.Replace("\'", "''");
        }
    }

    public abstract void AddToDatabase();

    public abstract void RefreshPage();
}
