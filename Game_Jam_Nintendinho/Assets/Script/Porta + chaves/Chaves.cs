using UnityEngine;

public class Chaves : MonoBehaviour
{
    GameObject GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jogador"))
        {
            GameManager.GetComponent<Jogador_ContaChaves>().chavespossuidas++;
            Destroy(gameObject);
        }
    }
}
