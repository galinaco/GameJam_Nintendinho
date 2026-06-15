using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta_pro_Boss : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jogador"))
        {
           SceneManager.LoadScene("Vitoria");
        }
    }
}
