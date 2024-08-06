using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int initTime = 120;
    public int timeAddOnPowerUp = 3;
    private int currentTime;
    void Start()
    {
        currentTime = initTime;
        gameObject.GetComponent<Text>().text = "Tiempo: " + initTime + " seg.";

        InvokeRepeating("ReducirSegundo", 1, 1);
    }

    private void ReducirSegundo()
    {
        currentTime--;
        gameObject.GetComponent<Text>().text = "Tiempo: " + currentTime + " seg.";

        if (currentTime == 0)
        {
            Debug.Log("Perdiste");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AgregarTiempo()
    {
        currentTime += timeAddOnPowerUp;
        gameObject.GetComponent<Text>().text = "Tiempo: " + currentTime + " seg.";
    }

    void Update()
    {
        
    }
}
