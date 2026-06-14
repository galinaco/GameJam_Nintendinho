using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.EventSystems;

public class TitleButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   

    [Header("Audio Clips")]
    [SerializeField] private EventReference buttonClickSound;
    [SerializeField] private EventReference buttonHoverSound;
    private EventInstance buttonClickInstance;
    private EventInstance buttonHoverInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonClickSound = RuntimeManager.PathToEventReference("event:/SFXs/Title/Buttons");
        buttonHoverSound = RuntimeManager.PathToEventReference("event:/SFXs/Title/Hower");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonClickSound()
    {
        buttonClickInstance = RuntimeManager.CreateInstance(buttonClickSound);
        buttonClickInstance.start();
    }
    public void PlayButtonHoverSound()
    {
        buttonHoverInstance = RuntimeManager.CreateInstance(buttonHoverSound);
        buttonHoverInstance.start();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayButtonHoverSound();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonHoverInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
