using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class Move_Boss : MonoBehaviour
{
    Transform[] pontos; // Array de pontos de caminho para o boss seguir
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
