using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class Move_Boss : MonoBehaviour
{
    //variaveis
    Rigidbody2D rb; // Referência ao componente Rigidbody2D do boss
    float velocidade = 2f; // Velocidade de movimento do boss

    [SerializeField] Transform[] pontos; // Array de pontos de caminho para o boss seguir
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < pontos.Length; i++)
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, pontos[i].position, 2f * Time.fixedDeltaTime));
            if(transform.position == pontos[i].position)
            {
                i++;
            }

        }



            
        
    }
    IEnumerator MoveBoss()
    {
        while (true)
        {
            // Lógica de movimento do boss aqui
            yield return new WaitForSeconds(1f); // Aguarda 1 segundo antes de repetir o movimento
        }
    }
}
