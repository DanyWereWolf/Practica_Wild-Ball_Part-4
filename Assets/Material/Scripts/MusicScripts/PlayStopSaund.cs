using FMODUnity;
using UnityEngine;
using FMOD.Studio;

public class PlayStopSaund : MonoBehaviour
{
    [SerializeField] private EventInstance cklickEvent;

    void Start()
    {
        cklickEvent = RuntimeManager.CreateInstance("event:/hit0");
        Vector3 position = transform.position;
        cklickEvent.set3DAttributes(RuntimeUtils.To3DAttributes(position));
    }
    public void onCklick()
    {
        cklickEvent.start();
    }
}