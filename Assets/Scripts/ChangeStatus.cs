using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStatus : MonoBehaviour
{


    private string initStatus = "None";
    private string currentStatus;

    void Start()
    {
        currentStatus = initStatus;
        gameObject.GetComponent<Text>().text = "Status: " + currentStatus;
    }

    public void UpdateCurrentStatus(string newStatus)
    {
        currentStatus = newStatus;
    }
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Status: " + currentStatus;
    }
}
