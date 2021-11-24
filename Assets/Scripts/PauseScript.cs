using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool paused = false;
    public Canvas pauseCanv;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu();
        }
    }
    public void pauseMenu()
    {
        if (!paused)
        {

            pauseCanv.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
            pauseCanv.gameObject.SetActive(false);
        }

        paused = !paused;
    }
}
