using Unity.VisualScripting;
using UnityEngine;

public class Porta_Trancada_fim_nvl1 : MonoBehaviour
{
    
    [SerializeField] Quebra_Joia quebroujoia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
            
        if (quebroujoia.Joiaquebrada == true)
        {
            Destroy(gameObject);
        }
          
    }
}
