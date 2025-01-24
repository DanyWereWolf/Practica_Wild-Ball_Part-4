using UnityEngine;

public class TriggerMagicBridge : MonoBehaviour
{
    [SerializeField] public GameObject BridgeExit;
    [SerializeField] public GameObject BridgeEnter;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BridgeEnter.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BridgeExit.SetActive(false);
        }
    }
}

