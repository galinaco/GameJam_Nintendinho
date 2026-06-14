using UnityEngine;

public class InterfaceKey : MonoBehaviour
{       
    
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject key2;
    [SerializeField] private GameObject key3;
    [SerializeField] private GameObject key4;
    [SerializeField] private GameObject key5;
    Jogador_ContaChaves jogador_ContaChaves;
    void Start()
    {
        jogador_ContaChaves = FindFirstObjectByType<Jogador_ContaChaves>();
    }

    // Update is called once per frame
    void Update()
    {
       switch (jogador_ContaChaves.chavespossuidas)
        {
            case 5: key.SetActive(true); key2.SetActive(true); key3.SetActive(true); key4.SetActive(true); key5.SetActive(true); break;
            case 4: key.SetActive(true); key2.SetActive(true); key3.SetActive(true); key4.SetActive(true); key5.SetActive(false); break;
            case 3: key.SetActive(true); key2.SetActive(true); key3.SetActive(true); key4.SetActive(false); key5.SetActive(false); break;
            case 2: key.SetActive(true); key2.SetActive(true); key3.SetActive(false); key4.SetActive(false); key5.SetActive(false); break;
            case 1: key.SetActive(true); key2.SetActive(false); key3.SetActive(false); key4.SetActive(false); key5.SetActive(false); break;
            case 0: key.SetActive(false); key2.SetActive(false); key3.SetActive(false); key4.SetActive(false); key5.SetActive(false); break;
        } 
    }
}
