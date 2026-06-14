using System.Collections;
using UnityEngine;

public class Ataques_Inimigos : MonoBehaviour
{
    //marcar se é um inimigo de ataque corpo a corpo ou distancia
    [Header("Meelee ou Ranged")]
    [SerializeField]bool inimigomeelee;
    [SerializeField]bool inimigodistancia;
    enum TipoInimigo { Meelee, Distancia }
    TipoInimigo tipoInimigo;
    // variaveis pros ataques dos inimigos 
    [Header("Ataque Meelee")]
    [SerializeField] float tempototalataquemeelee = 0.5f;
    [SerializeField] float tempoataqueatualmeelee;
    [SerializeField] float cooldownataquemeelee = 1f;
    [SerializeField] float cooldownataqueatualmeelee;
    [SerializeField] GameObject hitboxataquemeelee;

    [Header("Ataque Distancia")]
    [SerializeField] float cooldownataquedistancia = 1f;
    [SerializeField] float cooldownataquedistanciaatual;
    [SerializeField] GameObject prefabProjetil;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inimigomeelee)
        {
           tipoInimigo = TipoInimigo.Meelee;
        }
        else if (inimigodistancia)
        {
            tipoInimigo = TipoInimigo.Distancia;
        }
        else { 
            Debug.LogError("Nenhum ou mais de um tipo de inimigo selecionado! Selecione um tipo de inimigo para o script Ataques_Inimigos.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (tipoInimigo)
        { 
           case TipoInimigo.Meelee:
            cooldownataqueatualmeelee -= Time.deltaTime;
                if (cooldownataqueatualmeelee <= 0)
           {
            AtaqueMeelee();
            cooldownataqueatualmeelee = cooldownataquemeelee;
           }
                break;

            case TipoInimigo.Distancia:
                cooldownataquedistanciaatual -= Time.deltaTime;
                 if (cooldownataquedistanciaatual <= 0)
              {
                AtaqueDistancia();
                cooldownataquedistanciaatual = cooldownataquedistancia;
                }
                 break;


        }

    }

    void AtaqueMeelee()
    {

        tempoataqueatualmeelee -= Time.fixedDeltaTime;

        //comportamento do estado
        hitboxataquemeelee.SetActive(true);


        //transições de estado

        if (tempoataqueatualmeelee <= 0)
        {
            tempoataqueatualmeelee = tempototalataquemeelee;
            hitboxataquemeelee.SetActive(false);
        }

    }

    void AtaqueDistancia()
    {
        Instantiate(prefabProjetil, transform.position, Quaternion.identity);
    }
}
