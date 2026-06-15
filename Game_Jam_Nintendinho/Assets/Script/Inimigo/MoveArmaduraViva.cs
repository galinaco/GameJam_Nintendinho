using UnityEngine;

public class MoveArmaduraViva : MonoBehaviour
{
    //variaveis
    Vector2 direcao;

    //estados
    enum State { Idle, AndandoHorizontal, AndandoVertical}
    State estadoatual = State.Idle;
    Classe_Inimigo inimigo; 
    private Animator animator;
    private Vector2Int ultimaDirecao;
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inimigo = GetComponent<Classe_Inimigo>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        ultimaDirecao = Vector2Int.down;

    }

    // Update is called once per frame
    void Update()
    {
       
        
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

    void Idle ()
    {
        //comportamento de estado
            IdleAnimations();
        //transi��o de estado
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

        if (direcao.x > 0)
        {
            sprite.flipX = false;
            animator.Play("Walking Sides");
            ultimaDirecao = Vector2Int.right;
        }
            
        else if (direcao.x < 0)
        {
            sprite.flipX = true;
            animator.Play("Walking Sides");
            ultimaDirecao = Vector2Int.left;
        }
        inimigo.rb.MovePosition(inimigo.rb.position + direcao * inimigo.velocidade * Time.fixedDeltaTime);
        


        //transi��o de estado
        if (Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("jogador").transform.position.x) < 0.1f)
        {
            if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("jogador").transform.position.y)> 0.1f)
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

        if (direcao.y > 0)
        {
            animator.Play("Walking Up");
            ultimaDirecao = Vector2Int.up;
        }
        else if (direcao.y < 0)
        {
            animator.Play("Walking Down");
            ultimaDirecao = Vector2Int.down;
        }

        inimigo.rb.MovePosition(inimigo.rb.position + direcao * inimigo.velocidade * Time.fixedDeltaTime);

        //transi��o de estado
        if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("jogador").transform.position.y) < 0.1f)
        {
            if (Mathf.Abs(transform.position.x - GameObject.FindGameObjectWithTag("jogador").transform.position.x) > 0.1f)
                estadoatual = State.AndandoHorizontal;
            else
            {
                estadoatual = State.Idle;
            }
        }
    }

    
}
