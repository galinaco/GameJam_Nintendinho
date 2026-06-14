using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;

public class ArmorAudioManager : MonoBehaviour
{

    [Header("Audio Clips")]
    [SerializeField] private EventReference hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayHitSound()
    {
        RuntimeManager.PlayOneShot(hitSound);
    }
}
