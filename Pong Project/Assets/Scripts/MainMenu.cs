using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void openOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void closeOption()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }


}
