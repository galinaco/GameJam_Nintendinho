using UnityEngine;

public class Move_Personagem_Invertido : MonoBehaviour
{

    //componentes 
    [HideInInspector] public Rigidbody2D rg;
    SpriteRenderer sprite;
    [SerializeField] private Animator animator;


    //checks
    bool taandando = false;

    //estado do personagem
    enum State { Idle, AndandoHorizontal, AndandoVertical, AtaqueEspada, DefesaEscudo }
    [SerializeField] State estadoatual = State.Idle;

    //movimenta��o base
    [Header("Movimento Base")]
    Vector2 movimento = new Vector2();
    [SerializeField] public float velocidadejogador = 5f;
    [HideInInspector] public Vector2 inputmovimento = new Vector2();

    //Yuri
    int lastdirectionx;
    int lastdirectiony;
    State lastState;
    Vector2Int ultimaDirecao;


    //inputs
    bool inputhorizontal;
    bool inputvertical;
    [HideInInspector] public bool inputataque;
    [HideInInspector] public bool inputdefesa;
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


    //audio references
    [Header("Audio References")]
    [SerializeField] private PlayerAudioManager playerAudioManager;
    [SerializeField] public bool shot = false;
    [SerializeField] public bool defended = false;
    [SerializeField] public bool interacted = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoataqueatual = tempototalataque;
        rg = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //finds playeraudio manager
        playerAudioManager = FindFirstObjectByType<PlayerAudioManager>();
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
        inputmovimento = new Vector2(-(Input.GetAxisRaw("Horizontal")), -(Input.GetAxisRaw("Vertical")));
        inputataque = Input.GetKeyDown(KeyCode.J);
        inputdefesa = Input.GetKeyDown(KeyCode.K);

    }

    private void FixedUpdate()
    {



        //rotacionar a mira baseado no input de movimento, se n�o tiver input de movimento, rotacionar a mira baseado no ultimo input de movimento
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


        if (inputmovimento.x > 0) ultimaDirecao = Vector2Int.right;
        else if (inputmovimento.x < 0) ultimaDirecao = Vector2Int.left;
        else if (inputmovimento.y > 0) ultimaDirecao = Vector2Int.up;
        else if (inputmovimento.y < 0) ultimaDirecao = Vector2Int.down;

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

    void IdleAnimations()
    {
        if (ultimaDirecao == Vector2Int.right)
        {
            sprite.flipX = false;
            animator.Play("Idle Sides");
        }
        else if (ultimaDirecao == Vector2Int.left)
        {
            sprite.flipX = true;
            animator.Play("Idle Sides");
        }
        else if (ultimaDirecao == Vector2Int.up)
        {
            animator.Play("Idle Up");
        }
        else if (ultimaDirecao == Vector2Int.down)
        {
            animator.Play("Idle Down");
        }
        else
        {
            sprite.flipX = false;
            animator.Play("Idle Sides");
        }
    }

    void Idle()
    {
        //comportamento do estado
        taandando = false;

        IdleAnimations();
        lastState = State.Idle;

        //transi��es de estado
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

        //animator
        animator.Play("Walking Sides");

        if (movimento.x > 0f)
        {
            sprite.flipX = false;
            lastdirectionx = 1;
        }
        else if (movimento.x < 0f)
        {
            sprite.flipX = true;
            lastdirectionx = -1;
        }

        rg.MovePosition(rg.position + movimento * velocidadejogador * Time.fixedDeltaTime);




        lastState = State.AndandoHorizontal;
        //Debug.Log("movimento horizontal: " + movimento * velocidadejogador * Time.fixedDeltaTime);

        //transi��es de estado

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

        if (movimento.y > 0f)
        {
            animator.Play("Walking Up");
        }
        else if (movimento.y < 0f)
        {
            animator.Play("Walking Down");
        }
        rg.MovePosition(rg.position + movimento * velocidadejogador * Time.fixedDeltaTime);

        //Debug.Log("movimento vertical: " + movimento * velocidadejogador * Time.fixedDeltaTime);
        lastState = State.AndandoVertical;
        //transi��es de estado
        if (movimento.y == 0)
        {
            estadoatual = State.Idle;
        }
        else if (inputdefesa)
        {
            estadoatual = State.DefesaEscudo;
        }
        else if (inputmovimento.x != 0)
        {
            estadoatual = State.AndandoHorizontal;
        }

        else if (inputataque)
        {
            estadoatual = State.AtaqueEspada;
        }


    }

    void AttackAnimations()
    {
        if (ultimaDirecao == Vector2Int.right)
        {
            sprite.flipX = false;
            animator.Play("Attack Sides");
        }
        else if (ultimaDirecao == Vector2Int.left)
        {
            sprite.flipX = true;
            animator.Play("Attack Sides");
        }
        else if (ultimaDirecao == Vector2Int.up)
        {
            animator.Play("Attack Up");
        }
        else if (ultimaDirecao == Vector2Int.down)
        {
            animator.Play("Attack Down");
        }
        else
        {
            sprite.flipX = false;
            animator.Play("Attack Sides");
        }
    }

    void DefenseAnimations()
    {
        if (ultimaDirecao == Vector2Int.right)
        {
            sprite.flipX = false;
            animator.Play("Shield Sides");
        }
        else if (ultimaDirecao == Vector2Int.left)
        {
            sprite.flipX = true;
            animator.Play("Shield Sides");
        }
        else if (ultimaDirecao == Vector2Int.up)
        {
            animator.Play("Shield Up");
        }
        else if (ultimaDirecao == Vector2Int.down)
        {
            animator.Play("Shield Down");
        }
        else
        {
            sprite.flipX = false;
            animator.Play("Shield Sides");
        }

    }
    void AtaqueEspada()
    {

        tempoataqueatual -= Time.fixedDeltaTime;

        //comportamento do estado
        hitboxataque.SetActive(true);


        AttackAnimations();

        //transi��es de estado

        if (tempoataqueatual <= 0)
        {
            tempoataqueatual = tempototalataque;
            hitboxataque.SetActive(false);
            if (inputmovimento.x != 0)
            {
                estadoatual = State.AndandoHorizontal;
            }
            if (inputmovimento.x == 0 && inputmovimento.y == 0)
            {
                estadoatual = State.Idle;
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

        DefenseAnimations();

        //transi��es de estado

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



