using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.U2D;

public class Move_Personagem : MonoBehaviour
{

    //componentes 
    Rigidbody2D rg;
    SpriteRenderer sprite;


    //checks
    bool taandando = false;

    //estado do personagem
    enum State { Idle, AndandoHorizontal, AndandoVertical, AtaqueEspada, DefesaEscudo }
    State estadoatual = State.Idle;

    //movimentação base
    [Header("Movimento Base")]
    Vector2 movimento = new Vector2();
    [SerializeField] float velocidadejogador = 5f;
    Vector2 inputmovimento = new Vector2();


    //inputs
    bool inputhorizontal;
    bool inputvertical;
    bool inputataque;
    bool inputdefesa;
    //mira
    Vector2 ultimoinputmovimento;
    [SerializeField] Transform mira;

    //ataque 
    [Header(" Variaveis Ataque Espada")]
    [SerializeField] float tempototalataque = 0.5f;
    [SerializeField] float tempoataqueatual;
    [SerializeField] GameObject hitboxataque;


    //defesa
    [Header(" Variaveis Defesa Escudo")]
    [SerializeField] float tempototaldefesa = 0.5f;
    [SerializeField] float tempoadefesaatual;
    [SerializeField] GameObject hitboxdefesa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoataqueatual = tempototalataque;
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //troca de estados
        switch (estadoatual)
        {
            case State.Idle: Idle(); break;
            case State.AndandoHorizontal: AndandoHorizontal(); break;
            case State.AndandoVertical: AndandoVertical(); break;
            case State.AtaqueEspada: AtaqueEspada(); break;
            case State.DefesaEscudo: DefesaEscudo(); break;
        }

        //check de inputs
        inputmovimento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputataque = Input.GetKeyDown(KeyCode.J);
        inputdefesa = Input.GetKeyDown(KeyCode.K);

    }

    private void FixedUpdate()
    {



        //rotacionar a mira baseado no input de movimento, se não tiver input de movimento, rotacionar a mira baseado no ultimo input de movimento
        if (inputmovimento != Vector2.zero)
        {
            ultimoinputmovimento = inputmovimento;
            Vector3 vector3 = Vector3.left * inputmovimento.x + Vector3.down * inputmovimento.y;
            mira.rotation = Quaternion.LookRotation(Vector3.forward, vector3);

        }
        else if (!taandando)
        {
            Debug.Log("ta parado");

            Vector3 direcao = Vector3.left * ultimoinputmovimento.x + Vector3.down * ultimoinputmovimento.y;

            if (direcao != Vector3.zero)
            {
                mira.rotation = Quaternion.LookRotation(Vector3.forward, direcao);
            }

        }

        if (movimento.x > 0f)
        {
            //sprite.flipX = false;
        }
        else if (movimento.x < 0f)
        {
            // sprite.flipX = true;
        }

        // Debug.Log("input movimento: " + inputmovimento);

    }

    void Idle()
    {
        //comportamento do estado
        taandando = false;

        //transições de estado
        if (inputmovimento.x != 0)
        {
            estadoatual = State.AndandoHorizontal;
        }

        else if (inputmovimento.y != 0)
        {
            estadoatual = State.AndandoVertical;
        }

        else if (inputataque)
        {
            estadoatual = State.AtaqueEspada;
        }

        else if (inputdefesa)
        {
            estadoatual = State.DefesaEscudo;
        }

    }

    void AndandoHorizontal()
    {
        //comportamento do estado
        taandando = true;

        movimento = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        movimento.Normalize();
        rg.MovePosition(rg.position + movimento * velocidadejogador * Time.fixedDeltaTime);
        



        //Debug.Log("movimento horizontal: " + movimento * velocidadejogador * Time.fixedDeltaTime);

        //transições de estado

        if (movimento.x == 0)
        {
            estadoatual = State.Idle;
        }
        else if (inputataque)
        {
            estadoatual = State.AtaqueEspada;
        }
        else if (inputdefesa)
        {
            estadoatual = State.DefesaEscudo;
        }
    }
    void AndandoVertical()
    {
        //comportamento do estado
        taandando = true;
        movimento = new Vector2(0, Input.GetAxisRaw("Vertical"));
        movimento.Normalize();
        rg.MovePosition(rg.position + movimento * velocidadejogador * Time.fixedDeltaTime);
        
        //Debug.Log("movimento vertical: " + movimento * velocidadejogador * Time.fixedDeltaTime);

        //transições de estado
        if (movimento.y == 0)
        {
            estadoatual = State.Idle;
        }

        else if (inputataque)
        {
            estadoatual = State.AtaqueEspada;
        }


    }


    void AtaqueEspada()
    {

        tempoataqueatual -= Time.fixedDeltaTime;

        //comportamento do estado
        hitboxataque.SetActive(true);


        //transições de estado

        if (tempoataqueatual <= 0)
        {
            tempoataqueatual = tempototalataque;
            hitboxataque.SetActive(false);
            if (inputmovimento.x != 0)
            {
                estadoatual = State.AndandoHorizontal;
            }
            else if (inputmovimento.y != 0)
            {
                estadoatual = State.AndandoVertical;
            }
            else
            {
                estadoatual = State.Idle;
            }
        }

    }
    void DefesaEscudo()
    {

        tempoadefesaatual -= Time.fixedDeltaTime;

        //comportamento do estado
        hitboxdefesa.SetActive(true);


        //transições de estado

        if (tempoadefesaatual <= 0)
        {
            tempoadefesaatual = tempototaldefesa;
            hitboxdefesa.SetActive(false);
            if (inputmovimento.x != 0)
            {
                estadoatual = State.AndandoHorizontal;
            }
            else if (inputmovimento.y != 0)
            {
                estadoatual = State.AndandoVertical;
            }
            else
            {
                estadoatual = State.Idle;
            }
        }



    }
}

