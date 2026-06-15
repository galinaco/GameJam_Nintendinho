using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes_Funcoes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FuncaoSair()
    {
        Application.Quit();

    }

    public void Restart()
    {
        SceneManager.LoadScene("Masmorra 1");
    }

    public void IrMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
