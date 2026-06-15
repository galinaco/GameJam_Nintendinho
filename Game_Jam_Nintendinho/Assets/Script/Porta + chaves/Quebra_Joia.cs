using UnityEngine;

public class Quebra_Joia : MonoBehaviour
{
    [SerializeField] GameObject JoiaInteira;
    [SerializeField] GameObject JoiaQuebrada;
    [SerializeField] Move_Personagem movimentojogador;
    [SerializeField] Move_Personagem_Invertido movimentoinvertido;
    [SerializeField] public bool Joiaquebrada = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Joiaquebrada)
       {
            movimentojogador.enabled = false;
            movimentoinvertido.enabled = true;
       }
    }

    private void OnTriggernEnter2D(Collision2D collision)
    {
          
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Espada"))
        {
            Joiaquebrada = true;
            JoiaInteira.SetActive(false);
            JoiaQuebrada.SetActive(true);
        }
    }
}
