using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public Button Jugar;
    public Button Instrucciones;
    public Button Creditos;

    void Start()
    {
        Jugar.onClick.AddListener(CambiarEscenaJugar);
        Instrucciones.onClick.AddListener(CambiarEscenaInstrucciones);
        Creditos.onClick.AddListener(CambiarEscenaCreditos);
    }

    void CambiarEscenaJugar()
    {
        SceneManager.LoadScene("Juego");
    }
    void CambiarEscenaInstrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }
    void CambiarEscenaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    void Update()
    {
        
    }
}
