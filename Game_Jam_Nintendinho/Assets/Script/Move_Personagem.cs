using UnityEngine;
using UnityEngine.U2D;

public class Move_Personagem : MonoBehaviour
{
    //componentes 
    Rigidbody2D rg;
    SpriteRenderer sprite;
    

    //checks
    [SerializeField] float rccheckachao = 0.1f;

    //estado do personagem
    enum State { Idle, Andando, Pulo, Caindo }
    State estadoatual = State.Idle;

    //movimentação base
    Vector3 movimento = new Vector3();
    [SerializeField] float velocidadejogador = 5f;

    //pulo
    [SerializeField] float forcapulo = 7f;

    //inputs
    bool inputpulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * rccheckachao, Color.red);
        inputpulo = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        movimento = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movimento * velocidadejogador * Time.deltaTime;
        movimento.Normalize();

        if (movimento.x > 0f)
        {
            //sprite.flipX = false;
        }
        else if (movimento.x < 0f)
        {
           // sprite.flipX = true;
        }
        switch (estadoatual)
        {
            case State.Idle: Idle(); break;
            case State.Pulo: Pulo(); break;
            case State.Caindo: Caindo(); break;
            case State.Andando: Andando(); break;
        }
    }

    void Idle()
    {
        //comportamento do estado
        

        //transições de estado
        if (movimento.x != 0)
        {
            estadoatual = State.Andando;
        }

        else if (inputpulo && CheckaTaNoChao())
        {
            estadoatual = State.Pulo;
        }
    }

    void Andando()
    {
        //comportamento do estado

       

        //transições de estado
        if (inputpulo && CheckaTaNoChao())
        {
            estadoatual = State.Pulo;
        }
        else if (movimento.x == 0)
        {
            estadoatual = State.Idle;
        }
    }

    void Pulo()
    {

        //comportamento do estado
        

        //animatorjogador.Play("Animação começo pulo");
        Debug.Log("entrou no estado de pulo");

        rg.linearVelocity = Vector2.up * forcapulo;
        //rg.AddForce(new Vector2(0f, forcapulo), ForceMode2D.Impulse);

        //transições
        estadoatual = State.Caindo;
    }

    void Caindo()
    {
        //comportamento do estado
        if (rg.linearVelocity.y > 0f)
        {
            //animatorjogador.Play("Animação meio pulo");
        }
        else
        {
            //animatorjogador.Play("Animação caindo");
        }
        //transições
        if (CheckaTaNoChao() && movimento.x == 0)
        {
            estadoatual = State.Idle;
        }

        if (CheckaTaNoChao() && movimento.x != 0)
        {
            estadoatual = State.Andando;
        }
    }

    //metodo que verifica se o player esta no chão
    private bool CheckaTaNoChao()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rccheckachao, LayerMask.GetMask("chao"));
    }
}

