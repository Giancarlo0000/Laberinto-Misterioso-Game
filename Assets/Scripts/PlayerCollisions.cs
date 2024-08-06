using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    private Vector3 initPosition;

    public TimeCounter timeCounter;
    public GameObject lantern;
    public ChangeStatus changeStatus;

    void Start()
    {
        Debug.Log("accediento al regular speed del otro componente: " 
            + gameObject.GetComponent<WASDMovement>().regularSpeed);

        initPosition = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUpA")
        {
            gameObject.GetComponent<WASDMovement>().ChangeSpeedToFast();
            GameObject.Destroy(collision.gameObject);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            changeStatus.UpdateCurrentStatus("PowerUp Speed");
            Invoke("ResetStatus", 2);
        }

        if (collision.tag == "PowerUpB")
        {
            gameObject.transform.position = initPosition;
            collision.gameObject.GetComponent<AudioSource>().Play();
            changeStatus.UpdateCurrentStatus("PowerUp Reset");
            Invoke("ResetStatus", 3);
        }


        if (collision.tag == "PowerUpC")
        {
            gameObject.GetComponent<WASDMovement>().ChangeSpeedToSlow();
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            changeStatus.UpdateCurrentStatus("PowerDown Slowness");
            Invoke("ResetStatus", 4);
        }

        if (collision.tag == "PowerUpD")
        {
            lantern.GetComponent<Light>().range = 20f;
            lantern.transform.localPosition = new Vector3(0f,0f,-1f);
            GameObject.Destroy(collision.gameObject);
            changeStatus.UpdateCurrentStatus("Upgrade Lantern");
            Invoke("ResetStatus", 3);
        }

        if (collision.tag == "PowerUpE")
        {
            gameObject.GetComponent<WASDMovement>().ChangeCameraSize();
            changeStatus.UpdateCurrentStatus("PowerUp Vision");
            Invoke("ResetStatus", 4);
        }

        if (collision.tag == "PowerUpF")
        {
            gameObject.GetComponent<WASDMovement>().ChangeCollision();
            changeStatus.UpdateCurrentStatus("PowerUp Ghost");
            Invoke("ResetStatus", 7);
        }

        if (collision.tag == "PowerUpTime")
        {
            timeCounter.AgregarTiempo();
            GameObject.Destroy(collision.gameObject);
            changeStatus.UpdateCurrentStatus("PowerUp Time");
            Invoke("ResetStatus", 5);
        }

        if (collision.tag == "Goal")
        {
            timeCounter.AgregarTiempo();
            GameObject.Destroy(collision.gameObject);
            changeStatus.UpdateCurrentStatus("Win");
            Invoke("ChangeSceneMainMenu", 2);
        }
    }
    void ResetStatus()
    {
        changeStatus.UpdateCurrentStatus("None");
    }

    void ChangeSceneMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
