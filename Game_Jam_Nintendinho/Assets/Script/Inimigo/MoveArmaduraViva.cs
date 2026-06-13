using UnityEngine;

public class MoveArmaduraViva : MonoBehaviour
{
    //variaveis
    Vector2 direcao;

    //estados
    enum State { Idle, AndandoHorizontal, AndandoVertical}
    State estadoatual = State.Idle;
    Classe_Inimigo inimigo; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inimigo = GetComponent<Classe_Inimigo>();


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(estadoatual);
        if (transform.position.x == GameObject.FindGameObjectWithTag("jogador").transform.position.x)
        {
            Debug.Log("x igual");
        }
        //troca de estados
        
    }

    void FixedUpdate()
    {
        switch (estadoatual)
        {
            case State.Idle: Idle(); break;
            case State.AndandoHorizontal: AndandoHorizontal(); break;
            case State.AndandoVertical: AndandoVertical(); break;

        }
    }

    void Idle ()
    {
        //comportamento de estado

        //transição de estado
        if (transform.position.x != GameObject.FindGameObjectWithTag("jogador").transform.position.x)
        {
            estadoatual = State.AndandoHorizontal;
        }
        else if (transform.position.y != GameObject.FindGameObjectWithTag("jogador").transform.position.y)
        {
            estadoatual = State.AndandoVertical;
        }
    }

    void AndandoHorizontal()
    {
        //comportamento de estado
        direcao = new Vector2((GameObject.FindGameObjectWithTag("jogador").transform.position.x - transform.position.x),0).normalized;
        inimigo.rb.MovePosition(inimigo.rb.position + direcao * inimigo.velocidade * Time.fixedDeltaTime);
        


        //transição de estado
        if (Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("jogador").transform.position.x) < 0.1f)
        {
            if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("jogador").transform.position.y)< 0.1f)
                estadoatual = State.AndandoVertical;
            else 
            {
                estadoatual = State.Idle;
            }
        }
                
        
    }

    void AndandoVertical()
    {
        //comportamento de estado
        direcao = new Vector2(0, (GameObject.FindGameObjectWithTag("jogador").transform.position.y - transform.position.y)).normalized;
        inimigo.rb.MovePosition(inimigo.rb.position + direcao * inimigo.velocidade * Time.fixedDeltaTime);

        //transição de estado
        if (transform.position.y == GameObject.FindGameObjectWithTag("jogador").transform.position.y
            && transform.position.x != GameObject.FindGameObjectWithTag("jogador").transform.position.x)
        {
            estadoatual = State.AndandoHorizontal;
        }
        else if (transform.position.x == GameObject.FindGameObjectWithTag("jogador").transform.position.x
            && transform.position.y == GameObject.FindGameObjectWithTag("jogador").transform.position.y)
        {
            estadoatual = State.Idle;
        }
    }
}
