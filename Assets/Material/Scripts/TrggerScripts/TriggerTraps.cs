using FMODUnity;
using UnityEngine;
using FMOD.Studio;

public class TriggerTraps : MonoBehaviour
{
    [SerializeField] public GameObject PauseBtn;
    [SerializeField] public ParticleSystem particleSystem; 
    [SerializeField] public GameObject losPannel;

    public void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particleSystem.Play();
            PauseBtn.SetActive(false);
            losPannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

