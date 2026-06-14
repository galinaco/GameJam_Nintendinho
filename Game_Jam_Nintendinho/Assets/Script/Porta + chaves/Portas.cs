using UnityEngine;

public class Portas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Variaveis posição portas")]

    [SerializeField] Transform Saida;

    [Header("Variaveis camera")]
    /*[SerializeField]*/ GameObject objcamera;
    /*[SerializeField]*/ Transform posicaocamera;

    [Header("Onde a Porta tá?")]
    //[SerializeField] int posporta;
    [SerializeField] bool direita;
    [SerializeField] bool esquerda;
    [SerializeField] bool cima;
    [SerializeField] bool baixo;

    void Start()
    {
      objcamera = GameObject.FindGameObjectWithTag("MainCamera");
      posicaocamera = objcamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jogador"))
        {
            
            if(direita == true)
            {
                collision.gameObject.transform.position = new Vector2(Saida.position.x +0.8f,Saida.position.y);
                posicaocamera.position = new Vector3(objcamera.transform.position.x + 12.6f, objcamera.transform.position.y,objcamera.transform.position.z);
            }
            else if(esquerda == true)
            {
                collision.gameObject.transform.position = new Vector2(Saida.position.x -0.8f,Saida.position.y);
                posicaocamera.position = new Vector3(objcamera.transform.position.x - 12.6f, objcamera.transform.position.y,objcamera.transform.position.z);
            }
            else if(cima == true)
            {
                collision.gameObject.transform.position = new Vector2(Saida.position.x,Saida.position.y +0.8f);
                posicaocamera.position = new Vector3(objcamera.transform.position.x, objcamera.transform.position.y + 10.71f,objcamera.transform.position.z);
            }
            else if(baixo == true)
            {
                collision.gameObject.transform.position = new Vector2(Saida.position.x,Saida.position.y -0.8f);
                posicaocamera.position = new Vector3(objcamera.transform.position.x, objcamera.transform.position.y - 10.71f, objcamera.transform.position.z);
            }
            objcamera.transform.position = posicaocamera.position;

        }
    }
}
