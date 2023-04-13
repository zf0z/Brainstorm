using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AlertManager : MonoBehaviour
{
    public static IEnumerator ShowAlertForSeconds(GameObject alertObject, float seconds, string message = null)
    {
        if(message != null)
        {
            alertObject.GetComponentInChildren<Text>().text = message;
        }

        alertObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        alertObject.SetActive(false);

    }
}
