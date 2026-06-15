using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SistemadeVida : MonoBehaviour
{
    //variaveis
    [Header("Vida do Personagem")]
    [SerializeField] public float vida {get; private set;} = 5f;

    //knockback
    Move_Personagem MP;
    Rigidbody2D rg2d;
    [SerializeField] float forcanockback;
    //audio References
    [Header("Audio References")]
    [SerializeField] private PlayerAudioManager playerAudioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        //finds the playeraudio manager
       rg2d = GetComponent<Rigidbody2D>();
        playerAudioManager = FindFirstObjectByType<PlayerAudioManager>(); 
       MP = GetComponent<Move_Personagem>();
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
            //calls death audio function
            playerAudioManager.Death();


            Morrer();
        }
    }
    void Morrer()
    {
        SceneManager.LoadScene("Game over");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Quem recebeu a colis�o: " + gameObject.name);
       // Debug.Log("Colidiu com: " + collision.name);
        if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Inimigo"))
        {
            //calls hurt audio function
            playerAudioManager.Hurt();

            //calcula a direcao do knockback
            
            Vector2 direcaoKnockback = (transform.position - collision.gameObject.transform.position ).normalized;
            StartCoroutine(AplicarKnockback(direcaoKnockback));
            //


            //MP.rg.AddForce(new Vector2 (-(collision.gameObject.transform.position.x - transform.position.x), -(collision.gameObject.transform.position.y - transform.position.y)).normalized * forcanockback);

            DanoRecebido(1f);
        }


    }

    

    IEnumerator AplicarKnockback(Vector2 direcao)
    {
        float duracao = 0.15f;
        float timer = 0f;
        
        while (timer < duracao)
        {
            MP.enabled = false; // Desativa o controle do jogador durante o knockback
            rg2d.AddForce(direcao * forcanockback, ForceMode2D.Impulse);
            timer += Time.deltaTime;
            yield return null;
        }

        // Cancela o movimento completamente ao terminar
        rg2d.linearVelocity = Vector2.zero;
        MP.enabled = true; // Reativa o controle do jogador após o knockback
    }
}
