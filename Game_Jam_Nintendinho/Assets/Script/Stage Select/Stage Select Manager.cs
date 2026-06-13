using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
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
    public void FirstDungeon()
    {
        SceneManager.LoadScene("Cenateste");
    }
    public void SecondDungeon()
    {
        SceneManager.LoadScene("Cenateste2");
    }
    public void BossFight()
    {
        SceneManager.LoadScene("BossFight");
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
