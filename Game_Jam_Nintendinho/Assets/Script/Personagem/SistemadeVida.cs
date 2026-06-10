using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SistemadeVida : MonoBehaviour
{
    //variaveis
    [Header("Vida do Personagem")]
    [SerializeField] float vida = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DanoRecebido(float dano)
    {

        vida -= dano;
        if (vida <= 0)
        {
            Morrer();
        }
    }
    void Morrer()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Quem recebeu a colisão: " + gameObject.name);
       // Debug.Log("Colidiu com: " + collision.name);
        if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Inimigo"))
        {

            DanoRecebido(1f);
        }
    }
}
