using System.Collections;
using UnityEngine;

public class Classe_Inimigo : MonoBehaviour
{
    //variavel pra ativar o script do inimigo
    [Header("Onde a camera tem que t� pra esse inimigo ativar")]
    [SerializeField] Vector3 poscamera;
    [SerializeField] MonoBehaviour scriptmovimento;
    [SerializeField] SpriteRenderer sprite;
    Collider2D colider;
    Vector2 PosicaoInicial;

    // enemy audio manager    [Header("Audio Manager do inimigo")]
    [SerializeField] ArmorAudioManager audioManager;

    
    //status base
    [Header("Status Base")]
    [SerializeField] float vida = 5f;
    [SerializeField] float dano = 1f;
    [SerializeField] public float velocidade = 1f;
    [SerializeField] float vidaref = 3f;

    //componentes
    [HideInInspector] public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        colider = GetComponent<Collider2D>();
        //get reference do audio manager
        audioManager = GetComponent<ArmorAudioManager>();

        PosicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("MainCamera").transform.position, poscamera);

        if (dist < 0.1f)
        {
            scriptmovimento.enabled = true;
        }
        else
        {
            transform.position = PosicaoInicial;
            sprite.enabled = true;
            colider.enabled = true;
            vida = 5f;
            scriptmovimento.enabled = false;
        }
    }

    void DanoRecebido(float dano)
    {
        vida -= dano;
        audioManager.PlayHitSound();
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
        sprite.enabled = false;
        foreach (Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }

       
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Espada"))
        {
           DanoRecebido(1f);
        }
    }
}
