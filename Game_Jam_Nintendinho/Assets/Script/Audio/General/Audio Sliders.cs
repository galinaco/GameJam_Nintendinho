using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMOD;
using FMODUnity;
using FMOD.Studio;

public class AudioSliders : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private Slider slider;
    EventReference sliderSound;
    EventInstance sliderSoundInstance;
    private bool isSliderSoundPlaying;

    void Awake()
    {
        slider = GetComponent<Slider>();
        sliderSound = RuntimeManager.PathToEventReference("event:/UI/Slider");
        sliderSoundInstance = RuntimeManager.CreateInstance(sliderSound);
    }

    void Start()
    {
        slider.SetValueWithoutNotify(GetCurrentVolumeFromStatic());
    }

    void OnEnable()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        slider.SetValueWithoutNotify(GetCurrentVolumeFromStatic());
        slider.onValueChanged.AddListener(OnSliderChange);
    }

    void OnDisable()
    {
        if (slider != null)
        {
            slider.onValueChanged.RemoveListener(OnSliderChange);
        }

        StopSliderSound();
    }

    void OnDestroy()
    {
        StopSliderSound();

        if (sliderSoundInstance.isValid())
        {
            sliderSoundInstance.release();
        }
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartSliderSound();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        StopSliderSound();
    }

    private void StartSliderSound()
    {
        sliderSoundInstance.start();
    }

    private void StopSliderSound()
    {
        sliderSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private float GetCurrentVolumeFromStatic()
    {   
        
        if (gameObject.name == "Music") 
        return AudioSettings.musicVolume;
        if (gameObject.name == "SFXs") 
        return AudioSettings.SFXVolume;
        if (gameObject.name == "Ambiences") 
        return AudioSettings.ambienceVolume;
        if (gameObject.name == "Voice Overs") 
        return AudioSettings.VOVolume;
        if (gameObject.name == "Master") 
        return AudioSettings.masterVolume;
        return 0.5f;
    }
    private void OnSliderChange(float value)
    {
        if (gameObject.name == "Music") 
        AudioSettings.Instance.SetMusicVolume(value);
        if (gameObject.name == "SFXs") 
        AudioSettings.Instance.SetSFXVolume(value);
        if (gameObject.name == "Ambiences") 
        AudioSettings.Instance.SetAmbienceVolume(value);
        if (gameObject.name == "Voice Overs") 
        AudioSettings.Instance.SetVOVolume(value);
        if (gameObject.name == "Master") 
        AudioSettings.Instance.SetMasterVolume(value);
    }
}
