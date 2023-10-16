using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject completeUI;
    public GameObject loadUI;

    // Update is called once per frame
    void Update()
    {
       if(Time.timeScale == 0 && !pauseUI.activeSelf)
       {
            Time.timeScale = 1;
            pauseUI.SetActive(pauseUI.activeSelf);
        }
       else if(Time.timeScale == 1 && pauseUI.activeSelf)
       {
            Time.timeScale = 0;
            pauseUI.SetActive(!pauseUI.activeSelf);
       }

        if (completeUI.activeSelf && !loadUI.activeSelf)
        {
            Time.timeScale = 0;
        }

    }
}
