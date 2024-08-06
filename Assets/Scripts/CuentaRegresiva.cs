using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaRegresiva : MonoBehaviour
{
    public int initTime = 6;
    private int currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = initTime;
        gameObject.GetComponent<Text>().text = "Volviendo al menú en " + currentTime + " segundos";

        InvokeRepeating("ReducirSegundo", 1, 1);
    }

    private void ReducirSegundo()
    {
        currentTime--;
        gameObject.GetComponent<Text>().text = "Volviendo al menú en " + currentTime + " segundos";

        if (currentTime == 0)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
