using System.Collections;
using UnityEngine;

public class Classe_Inimigo : MonoBehaviour
{
    //status base
    [Header("Status Base")]
    [SerializeField] float vida = 5f;
    [SerializeField] float dano = 1f;
    [SerializeField] float velocidade = 1f;
    
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
        StartCoroutine(feedbackmudacor());
        if (vida <= 0)
        {
            Morrer();
        }
    }
    IEnumerator feedbackmudacor()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void Morrer()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Espada"))
        {
           DanoRecebido(1f);
        }
    }
}
