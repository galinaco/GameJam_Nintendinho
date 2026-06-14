using UnityEngine;

public class Chaves : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jogador"))
        {
            collision.gameObject.GetComponent<Jogador_ContaChaves>().chavespossuidas++;
            Destroy(gameObject);
        }
    }
}
