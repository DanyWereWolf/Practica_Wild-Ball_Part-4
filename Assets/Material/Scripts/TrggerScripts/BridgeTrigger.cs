using UnityEngine;
using WildBall.inputs;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] public Animator bridgeAnim;
    [SerializeField] public GameObject TrigZone;
    [SerializeField] public GameObject OpenKey;
    [SerializeField] public GameObject InfoKey;
    [SerializeField] public bool InTrigPl = false;


    private void Start()
    {
        OpenKey.SetActive(false);
        InfoKey.SetActive(false);
    }

    private void Update()
    {
        if (InTrigPl == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Проверяем нажатие клавиши E
            {
                bridgeAnim.SetTrigger("LowerBridge"); // Запускаем опускание моста
                OpenKey.SetActive(false);
                InfoKey.SetActive(false);
                Destroy(TrigZone);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameController.hasKey) // Проверяем, что это игрок и у него есть ключ
        {
            OpenKey.SetActive(true);
            InfoKey.SetActive(false);
            InTrigPl = true;
            Debug.Log("у меня есть ключ");
        }
        else if (gameController.hasKey == false)
        {
            InfoKey.SetActive(true);
            Debug.Log("у меня нет ключ");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OpenKey.SetActive(false);
        InfoKey.SetActive(false);
        InTrigPl = false;
    }
}
