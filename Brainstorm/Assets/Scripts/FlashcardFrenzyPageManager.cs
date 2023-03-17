using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashcardFrenzyPageManager : MonoBehaviour
{
    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene("Topic");
    }
}
