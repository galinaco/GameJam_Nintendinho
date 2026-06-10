using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    GameObject optionsMenu;
    void Start()
    {
        optionsMenu = GameObject.Find("Options");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    void QuitGame()
    {
        Application.Quit();
    }
    void Options()
    {
        optionsMenu.SetActive(true);
    }
}
