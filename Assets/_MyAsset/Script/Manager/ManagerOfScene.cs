using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Application.Quit(); 
    }

    public void SceneStart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

    public void SceneGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    public void SceneEnd()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(2);
    }


}
