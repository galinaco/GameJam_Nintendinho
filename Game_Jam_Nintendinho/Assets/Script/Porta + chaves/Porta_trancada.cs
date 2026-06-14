using Unity.VisualScripting;
using UnityEngine;

public class Porta_trancada : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jogador"))
        {
            if (collision.gameObject.GetComponent<Jogador_ContaChaves>().chavespossuidas > 0)
            {
                collision.gameObject.GetComponent<Jogador_ContaChaves>().chavespossuidas--;
                Destroy(gameObject);
            }
        }
    }
}
