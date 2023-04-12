using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessageGenerator
{
    public static string GenerateErrorMessage(List<InputField> inputFields)
    {
        var errorMessage = string.Empty;

        var missingFields = inputFields.Where(x => x.text == string.Empty).Select(x => x.name.Replace("Input", "").ToUpper());

        if(missingFields.Count() > 0)
        {
            errorMessage = string.Join(" AND ", missingFields.ToArray()) + " MUST BE POPULATED";
        }

        return errorMessage;
    }
}
