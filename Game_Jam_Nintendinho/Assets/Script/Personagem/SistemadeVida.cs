using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SistemadeVida : MonoBehaviour
{
    //variaveis
    [Header("Vida do Personagem")]
    [SerializeField] public float vida {get; private set;} = 5f;

    //audio References
    [Header("Audio References")]
    [SerializeField] private PlayerAudioManager playerAudioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        //finds the playeraudio manager
       playerAudioManager = FindFirstObjectByType<PlayerAudioManager>(); 
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

            
            DanoRecebido(1f);
        }
    }
}
