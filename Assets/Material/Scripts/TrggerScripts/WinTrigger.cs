using UnityEngine;
using WildBall.inputs;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] public ParticleSystem firework;
    [SerializeField] public GameObject listener;
    [SerializeField] public GameObject winPanel;
    [SerializeField] private Vector3 _aLocation;
    [SerializeField] private EventInstance winEvent;
    private void Start()
    {
      
        winPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                winPanel.SetActive(true);
                firework.Play();
                gameController.Drag();
                RuntimeManager.PlayOneShot("event:/Win",  _aLocation);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void Update()
    {
        _aLocation = listener.transform.position;
    }
}

