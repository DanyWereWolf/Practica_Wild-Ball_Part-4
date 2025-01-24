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
            if (Input.GetKeyDown(KeyCode.E)) // ��������� ������� ������� E
            {
                bridgeAnim.SetTrigger("LowerBridge"); // ��������� ��������� �����
                OpenKey.SetActive(false);
                InfoKey.SetActive(false);
                Destroy(TrigZone);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameController.hasKey) // ���������, ��� ��� ����� � � ���� ���� ����
        {
            OpenKey.SetActive(true);
            InfoKey.SetActive(false);
            InTrigPl = true;
            Debug.Log("� ���� ���� ����");
        }
        else if (gameController.hasKey == false)
        {
            InfoKey.SetActive(true);
            Debug.Log("� ���� ��� ����");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OpenKey.SetActive(false);
        InfoKey.SetActive(false);
        InTrigPl = false;
    }
}
