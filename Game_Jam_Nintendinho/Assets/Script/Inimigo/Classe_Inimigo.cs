using System.Collections;
using UnityEngine;

public class Classe_Inimigo : MonoBehaviour
{
    //variavel pra ativar o script do inimigo
    [Header("Onde a camera tem que tá pra esse inimigo ativar")]
    [SerializeField] Vector3 poscamera;
    [SerializeField] MonoBehaviour scriptmovimento;

    
    //status base
    [Header("Status Base")]
    [SerializeField] float vida = 5f;
    [SerializeField] float dano = 1f;
    [SerializeField] public float velocidade = 1f;

    //componentes
    [HideInInspector] public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x == poscamera.x &&
            GameObject.FindGameObjectWithTag("MainCamera").transform.position.y == poscamera.y)
        {
            scriptmovimento.enabled = true;
        }
        else
        {
            scriptmovimento.enabled = false;
        }
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
