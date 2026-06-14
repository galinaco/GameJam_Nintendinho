using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class GameplayAudioManager : MonoBehaviour
{
    [Header("Audio References")]
    public EventReference dungeon1OSTEvent;

    private EventInstance dungeon1OSTInstance;
    private EventReference dungeon2OSTEvent;
    private EventInstance dungeon2OSTInstance;
    private EventReference dungeonAmbienceEvent;
    private EventInstance dungeonAmbienceInstance;
    private EventReference curseWorsenEvent;
    private EventInstance curseWorsenInstance;


    void Start()
    {  //set references
        dungeon1OSTEvent = RuntimeManager.PathToEventReference("event:/OSTs/First Dungeon");
        dungeonAmbienceEvent = RuntimeManager.PathToEventReference("event:/Ambiences/Dungeon");
        dungeon2OSTEvent = RuntimeManager.PathToEventReference("event:/OSTs/Second Dungeon");
        curseWorsenEvent = RuntimeManager.PathToEventReference("event:/Ambiences/Curse Worsen_Inverted Controls");
        dungeon1OSTInstance = RuntimeManager.CreateInstance(dungeon1OSTEvent);
        dungeon1OSTInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
