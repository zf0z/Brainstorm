using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopicManager : MonoBehaviour
{
    private DatabaseManager databaseManager;

    public Text topicNameText;
    public Button backButton;
    public Button flashcardFrenzyButton;
    public Button dunkTheTeacherButton;
    public GameObject topicFlashcard;
    public Transform flashcardParent;
    public Button includeAllButton;
    public Button excludeAllButton;
    public Button addFlashcardButton;
    public FormManager formManager;

    public GameObject flashcardCountWarning;

    private List<GameObject> flashcardTemplates;

    // Start is called before the first frame update
    void Start()
    {
        databaseManager = FindObjectOfType<DatabaseManager>();

        int topicId = PlayerPrefs.GetInt("TopicId");

        var topic = databaseManager.ExecuteQueryWithReturn<Topic>(Queries.GetTopic, new string[] { topicId.ToString() }).First();

        topicNameText.text = topic.TopicName;

        backButton.onClick.AddListener(Back);
        flashcardFrenzyButton.onClick.AddListener(StartFlashcardFrenzy);
        dunkTheTeacherButton.onClick.AddListener(StartDunkTheTeacher);

        var flashCards = databaseManager.ExecuteQueryWithReturn<Flashcard>(Queries.GetFlashcardsForTopic, new string[] { topicId.ToString() });

        flashcardTemplates = new List<GameObject>();

        foreach (var flashcard in flashCards)
        {
            var card = Instantiate(topicFlashcard, flashcardParent);
            card.transform.Find("Question").GetComponent<Text>().text = flashcard.Question;
            card.transform.Find("Answer").GetComponent<Text>().text = flashcard.Answer;

            card.GetComponent<TopicFlashcardBehaviour>().FlashcardId = flashcard.Id;
            card.GetComponent<TopicFlashcardBehaviour>().CurrentState = flashcard.Included;

            if (flashcard.Included == 0)
            {
                card.GetComponent<Image>().color = Color.gray;
            }
            else
            {
                card.GetComponent<Image>().color = Color.white;
            }

            // add event for when flashcard is clicked
            var eventTrigger = card.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((eventData) => { ChangeFlashcardState(card); });
            eventTrigger.triggers.Add(entry);

            flashcardTemplates.Add(card);
        }

        includeAllButton.onClick.AddListener(delegate { IncludeAllFlashcards(flashcardTemplates); });
        excludeAllButton.onClick.AddListener(delegate { ExcludeAllFlashcards(flashcardTemplates); });

        formManager.Initialize();
        addFlashcardButton.onClick.AddListener(formManager.OpenForm);
    }

    public void ChangeFlashcardState(GameObject card)
    {
        var cardBehaviourScript = card.GetComponent<TopicFlashcardBehaviour>();

        var updatedState = cardBehaviourScript.ChangeState();
        var flashCardId = cardBehaviourScript.FlashcardId;

        databaseManager.ExecuteQueryWithNoReturn(Queries.UpdateFlashcardStates, new string[] { updatedState.ToString(), flashCardId.ToString() });
    }

    private void IncludeAllFlashcards(List<GameObject> flashcards)
    {
        var ids = new List<long>();

        foreach(var flashcard in flashcards)
        {
            var cardBehaviourScript = flashcard.GetComponent<TopicFlashcardBehaviour>();

            if(!cardBehaviourScript.IsIncluded())
            {
                cardBehaviourScript.Include();

                ids.Add(cardBehaviourScript.FlashcardId);
            }
            
        }

        var idsForQuery = string.Join(",", ids.ToArray());

        databaseManager.ExecuteQueryWithNoReturn(Queries.UpdateFlashcardStates, new string[] { 1.ToString(), idsForQuery });
    }
    
    private void ExcludeAllFlashcards(List<GameObject> flashcards)
    {
        var ids = new List<long>();

        foreach (var flashcard in flashcards)
        {

            var cardBehaviourScript = flashcard.GetComponent<TopicFlashcardBehaviour>();

            if(cardBehaviourScript.IsIncluded())
            {
                cardBehaviourScript.Exclude();
                ids.Add(cardBehaviourScript.FlashcardId);
            }
        }

        var idsForQuery = string.Join(",", ids.ToArray());

        databaseManager.ExecuteQueryWithNoReturn(Queries.UpdateFlashcardStates, new string[] { 0.ToString(), idsForQuery });
    }
    
    private int GetFlashcardCount()
    {
        var count = flashcardTemplates.Where(x => x.GetComponent<TopicFlashcardBehaviour>().IsIncluded()).Count();

        return count;
    }

    private IEnumerator ShowFlashcardWarning()
    {
        flashcardCountWarning.SetActive(true);
        yield return new WaitForSeconds(2);
        flashcardCountWarning.SetActive(false);
    }

    private void Back()
    {
        SceneManager.LoadScene("Subject");
    }

    private void StartFlashcardFrenzy()
    {
        if(GetFlashcardCount() > 0)
        {
            SceneManager.LoadScene("FlashcardFrenzy");
        }
        else
        {
            StartCoroutine(ShowFlashcardWarning());
        }
        
    }

    private void StartDunkTheTeacher()
    {
        if(GetFlashcardCount() > 0)
        {
            SceneManager.LoadScene("MultipleChoiceGame");
        }
        else
        {
            StartCoroutine(ShowFlashcardWarning());
        }
    }
}
