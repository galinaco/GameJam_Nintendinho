using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MainMenuAudioManager : MonoBehaviour
{
    [SerializeField] private EventReference mainMenuMusic;
    private EventInstance mainMenuMusicInstance;
    [SerializeField] private EventReference buttonClickSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMainMenuMusic();
    }
    void OnDestroy()
    {
        StopMainMenuMusic();
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayMainMenuMusic()
    {
        mainMenuMusicInstance = RuntimeManager.CreateInstance(mainMenuMusic);
        mainMenuMusicInstance.start();
    }
    void StopMainMenuMusic()
    {
        mainMenuMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        mainMenuMusicInstance.release();
    }
    void PlayButtonClickSound()
    {
        RuntimeManager.PlayOneShot(buttonClickSound);
    }
    


}
