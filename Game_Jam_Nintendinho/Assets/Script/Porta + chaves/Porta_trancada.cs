using Unity.VisualScripting;
using UnityEngine;

public class Porta_trancada : MonoBehaviour
{
    GameObject GameManager;
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jogador"))
        {
            if (GameManager.GetComponent<Jogador_ContaChaves>().chavespossuidas > 0)
            {
                GameManager.GetComponent<Jogador_ContaChaves>().chavespossuidas--;
                Destroy(gameObject);
            }
        }
    }
}
