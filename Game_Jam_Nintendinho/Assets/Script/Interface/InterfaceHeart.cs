using UnityEngine;

public class InterfaceHeart : MonoBehaviour
{
         
    
    [SerializeField] private GameObject Heart;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private GameObject Heart3;
    [SerializeField] private GameObject Heart4;
    [SerializeField] private GameObject Heart5;
    SistemadeVida sistemadeVida;
    void Start()
    {
        sistemadeVida = FindFirstObjectByType<SistemadeVida>();
    }

    // Update is called once per frame
    void Update()
    {
       switch (sistemadeVida.vida)
        {
            case 5: Heart.SetActive(true); Heart2.SetActive(true); Heart3.SetActive(true); Heart4.SetActive(true); Heart5.SetActive(true); break;
            case 4: Heart.SetActive(true); Heart2.SetActive(true); Heart3.SetActive(true); Heart4.SetActive(true); Heart5.SetActive(false); break;
            case 3: Heart.SetActive(true); Heart2.SetActive(true); Heart3.SetActive(true); Heart4.SetActive(false); Heart5.SetActive(false); break;
            case 2: Heart.SetActive(true); Heart2.SetActive(true); Heart3.SetActive(false); Heart4.SetActive(false); Heart5.SetActive(false); break;
            case 1: Heart.SetActive(true); Heart2.SetActive(false); Heart3.SetActive(false); Heart4.SetActive(false); Heart5.SetActive(false); break;
            case 0: Heart.SetActive(false); Heart2.SetActive(false); Heart3.SetActive(false); Heart4.SetActive(false); Heart5.SetActive(false); break;

        } 
    }
}

