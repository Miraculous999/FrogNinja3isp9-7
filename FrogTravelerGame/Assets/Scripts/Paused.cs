using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    [SerializeField] GameObject Pause;

    void Start()
    {
        Pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void PauseOff()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
