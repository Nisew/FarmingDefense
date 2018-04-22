using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesScript : MonoBehaviour
{
    bool paused;
    public GameObject button;
    float counter = 1;
    int escena;
    bool changing;

    void Start()
    {
        if(button != null)
        {
            button.SetActive(false);
        }
    }

    public void ToScene(int esena)
    {
        escena = esena;
        changing = true;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if(button != null)
        {
            if(Resources.instance.lives == 0)
            {
                button.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
        }
        if(changing)
        {
            counter -= Time.deltaTime;

            if(counter <= 0)
            {
                counter = 1;
                changing = false;
                SceneManager.LoadScene(escena);
                Time.timeScale = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                if(button != null)
                {
                    paused = true;
                    Time.timeScale = 0;
                    button.SetActive(true);
                }
            }
            else if (paused && button != null && Resources.instance.lives != 0)
            {
                if (button != null)
                {
                    paused = false;
                    Time.timeScale = 1;
                    button.SetActive(false);
                }
            }
        }
    }
}
