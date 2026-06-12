using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerAudioManager : MonoBehaviour
{
    //actions
    [SerializeField] private EventReference attackEvent;
    private EventInstance attackInstance;
    [SerializeField] private EventReference interactEvent;
    private EventInstance interactInstance;
    [SerializeField] private EventReference collectKeyEvent;
    private EventInstance collectKeyInstance;
    [SerializeField] private EventReference doorOpenEvent;
    private EventInstance doorOpenInstance;

    //states
    [SerializeField] private EventReference hurtEvent;
    private EventInstance hurtInstance;
    [SerializeField] private EventReference deathEvent;
    private EventInstance deathInstance;
    
    [SerializeField] private EventReference petrifyEvent;
    private EventInstance petrifyInstance;
    [SerializeField] private EventReference curseWorsenEvent;
    private EventInstance curseWorsenInstance;

    //code references
    [Header("Code References")]
    [SerializeField] private Move_Personagem movePersonagem;
    [SerializeField] private SistemadeVida sistemaDeVida;


    void Start()
    {   
        movePersonagem = FindFirstObjectByType<Move_Personagem>();
        sistemaDeVida = FindFirstObjectByType<SistemadeVida>();
        attackEvent = RuntimeManager.PathToEventReference("event:/SFXs/Player/Attack");
        interactEvent = RuntimeManager.PathToEventReference("event:/SFXs/Player/Interact");
        collectKeyEvent = RuntimeManager.PathToEventReference("event:/SFXs/Scenery/Key Collect");
        doorOpenEvent = RuntimeManager.PathToEventReference("event:/SFXs/Scenery/Door Open");
        hurtEvent = RuntimeManager.PathToEventReference("event:/SFXs/Player/Hurt");
        deathEvent = RuntimeManager.PathToEventReference("event:/SFXs/Player/Death");
        petrifyEvent = RuntimeManager.PathToEventReference("event:/SFXs/Player/Petrify");
        curseWorsenEvent = RuntimeManager.PathToEventReference("event:/Ambiences/Curse Worsen_Inverted Controls");
    }
    public void Attack()
    {   
            RuntimeManager.PlayOneShot(attackEvent);
    }
    public void Interact()
    {
        interactInstance = RuntimeManager.CreateInstance(interactEvent);
        interactInstance.start();
        interactInstance.release();
    }
    public void CollectKey()
    {
        collectKeyInstance = RuntimeManager.CreateInstance(collectKeyEvent);
        collectKeyInstance.start();
        collectKeyInstance.release();
    }
    public void DoorOpen()
    {
        doorOpenInstance = RuntimeManager.CreateInstance(doorOpenEvent);
        doorOpenInstance.start();
        doorOpenInstance.release();
    }
    public void Hurt()
    {
        hurtInstance = RuntimeManager.CreateInstance(hurtEvent);
        hurtInstance.start();
        hurtInstance.release();
    }
    public void Death()
    {
        deathInstance = RuntimeManager.CreateInstance(deathEvent);
        deathInstance.start();
        deathInstance.release();
    }
    public void Petrify()
    {
        petrifyInstance = RuntimeManager.CreateInstance(petrifyEvent);
        petrifyInstance.start();
        petrifyInstance.release();
    }
    public void CurseWorsen()
    {
        curseWorsenInstance = RuntimeManager.CreateInstance(curseWorsenEvent);
        curseWorsenInstance.start();
    }
    public void CurseWorsenStop()
    {
        curseWorsenInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        curseWorsenInstance.release();
    }

    // Update is called once per frame
    void Update()
    {   
        if (movePersonagem == null || sistemaDeVida == null)
        {
            return;
        }
        if (movePersonagem.shot)
        {
            Attack();
            movePersonagem.shot = false;
        }
    }
}
