using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class VCASlider : MonoBehaviour
{
    [SerializeField] public Slider volumeSlider;
    [SerializeField] private FMOD.Studio.EventInstance vcaEvent;

    void Start()
    {
        volumeSlider.value = 1.0f;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0f, 1f);
        RuntimeManager.GetVCA("vca:/VCAmaster").setVolume(volume);
    }
}
