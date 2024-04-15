using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPhoto : MonoBehaviour
{
    [SerializeField] private string beforeResult, afterResult;
    [SerializeField] private GameObject beforePanel, afterPanel;

    public void BeforeCalculationPhoto(bool isClean)
    {
        if (isClean) beforeResult = "Bersih";
        else beforeResult = "Kotor";
        beforePanel.SetActive(false);
        afterPanel.SetActive(true);
    }

    public void AfterCalculationPhoto(bool isClean)
    {
        if (isClean) afterResult = "Bersih";
        else afterResult = "Kotor";
        beforePanel.SetActive(false);
        afterPanel.SetActive(false);
    }

    public void ComparePhoto()
    {
        if (beforeResult == afterResult)
        {
            Debug.Log("DAPAT Poin!");
        }
        else
        {
            beforePanel.SetActive(true);
            afterPanel.SetActive(false);
        }
    }
}
