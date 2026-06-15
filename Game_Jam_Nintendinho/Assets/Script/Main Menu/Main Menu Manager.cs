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
    public void PlayGame()
    {
        SceneManager.LoadScene("Masmorra 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void BackOptions()
    {
        optionsMenu.SetActive(false);
    }
}
