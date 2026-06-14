using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioSettings : MonoBehaviour
{
    [Header("Audio Settings")]
    public static bool Audio3DEnabled { get; private set; } = true;

   [Header("Audio tests")]
    [SerializeField] private EventInstance SFXtestEvent;
    [SerializeField] private EventReference SFXtestEventRef;
    [SerializeField] private EventInstance MusictestEvent;
    [SerializeField] private EventReference MusictestEventRef;
    [SerializeField] private EventInstance AmbiencetestEvent;
    [SerializeField] private EventReference AmbiencetestEventRef;
    [SerializeField] private EventInstance VOtestEvent;
    [SerializeField] private EventReference VOtestEventRef;
    [SerializeField] private EventInstance MastertestEvent;
    [SerializeField] private EventReference MastertestEventRef;

    [Header("Audio Buses")]
    private Bus Music;
    private Bus SFX;
    private Bus Ambience;
    private Bus VO;
    private Bus Master;

    [Header("Volume Levels")]

    public static float musicVolume { get; private set; } = 0.5f;
    public static float SFXVolume { get; private set; } = 0.5f;
    public static float ambienceVolume { get; private set; } = 0.5f;
    public static float VOVolume { get; private set; } = 0.5f;
    public static float masterVolume { get; private set; } = 0.5f;

    public static AudioSettings Instance { get; private set; }
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
            private void OnEnable()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDisable()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {   
            // Reassign Fmod buses when a new scene is loaded 
            Music = RuntimeManager.GetBus("bus:/Master/Music");
            SFX = RuntimeManager.GetBus("bus:/Master/SFXs");
            Ambience = RuntimeManager.GetBus("bus:/Master/Ambience");
            VO = RuntimeManager.GetBus("bus:/Master/VOs");
            Master = RuntimeManager.GetBus("bus:/Master");
        }
        
        

    void Start()
    {   
        // Assign Fmod buses at the start of the game
        Music = RuntimeManager.GetBus("bus:/Master/Music");
        SFX = RuntimeManager.GetBus("bus:/Master/SFXs");
        Ambience = RuntimeManager.GetBus("bus:/Master/Ambience");
        VO = RuntimeManager.GetBus("bus:/Master/VOs");
        Master = RuntimeManager.GetBus("bus:/Master");
    }


    // Update is called once per frame
    void Update()
    {   
        // continuously set the volume of each bus to the current volume levels
        Music.setVolume(musicVolume);
        SFX.setVolume(SFXVolume);
        Ambience.setVolume(ambienceVolume);
        VO.setVolume(VOVolume);
        Master.setVolume(masterVolume);
        Set3DAudio(Audio3DEnabled);
    }

    // set the volume levels to slider values and play a test sound when the volume is changed
    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
        PLAYBACK_STATE musicState;
        MusictestEvent.getPlaybackState(out musicState);
        if (musicState != PLAYBACK_STATE.PLAYING)
        {
            MusictestEvent.start();
            StartCoroutine(StopMusicTestEvent());
        }
    }
    // stop the test sound after a delay 
    IEnumerator StopMusicTestEvent()
    {
        yield return new WaitForSeconds(1f);
        MusictestEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    // set the volume levels to slider values and play a test sound when the volume is changed
    public void SetSFXVolume(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;
        PLAYBACK_STATE sfxState;
        SFXtestEvent.getPlaybackState(out sfxState);
        if (sfxState != PLAYBACK_STATE.PLAYING)
        {
            SFXtestEvent.start();
        }
    }
    void Set3DAudio(bool configSwitch)
    {
        RuntimeManager.StudioSystem.setParameterByName("Game State", configSwitch ? 1 : 0);
    }
    public void _3DAudioToggle(bool isEnabled)
    {
        Audio3DEnabled = isEnabled;
    }

    // set the volume levels to slider values and play a test sound when the volume is changed
    public void SetAmbienceVolume(float newAmbienceVolume)
    {
        ambienceVolume = newAmbienceVolume;
        PLAYBACK_STATE ambienceState;
        AmbiencetestEvent.getPlaybackState(out ambienceState);
        if (ambienceState != PLAYBACK_STATE.PLAYING)
        {
            AmbiencetestEvent.start();
            StartCoroutine(StopAmbienceTestEvent());
        }
    }

    // stop the test sound after a delay 
    IEnumerator StopAmbienceTestEvent()
    {
        yield return new WaitForSeconds(1f);
        AmbiencetestEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    // set the volume levels to slider values and play a test sound when the volume is changed
    public void SetVOVolume(float newVOVolume)
    {
        VOVolume = newVOVolume;
        PLAYBACK_STATE voState;
        VOtestEvent.getPlaybackState(out voState);
        if (voState != PLAYBACK_STATE.PLAYING)
        {
            VOtestEvent.start();
        }
    }

    // set the volume levels to slider values 
    public void SetMasterVolume(float newMasterVolume)
    {
        masterVolume = newMasterVolume;
    }

}
