using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopicFlashcardBehaviour : MonoBehaviour
{
    public long FlashcardId { get; set; }
    public long CurrentState { get; set; }

    public long ChangeState()
    {
        if(CurrentState == 1)
        {
            Exclude();
        }
        else
        {
            Include();
        }

        return CurrentState;
    }

    public void Include()
    {
        CurrentState = 1;
        gameObject.GetComponent<Image>().color = Color.white;
    }

    public void Exclude()
    {
        CurrentState = 0;
        gameObject.GetComponent<Image>().color = Color.grey;
    }

    public bool IsIncluded()
    {
        if(CurrentState == 1)
        {
            return true;
        }

        return false;
    }
}
