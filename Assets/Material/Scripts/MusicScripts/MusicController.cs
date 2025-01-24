using FMODUnity;
using UnityEngine;
using FMOD.Studio;


public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private EventInstance musicEventMenu;
    private EventInstance musicEventGame;


    void Awake()
    {
       // ���������, ���������� �� ��� ���������
    if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject); // �� ���������� ��� �������� ����� �����
      }
    else
      {
           Destroy(gameObject); // ���������� ��������
      }
    }

    void Start()
    {
        //��������� �������
        musicEventMenu = RuntimeManager.CreateInstance("event:/Amb1");
        musicEventGame = RuntimeManager.CreateInstance("event:/Amb2");
        musicEventMenu.start();

        //������� ��������� �����
        Vector3 position = transform.position;
        musicEventMenu.set3DAttributes(RuntimeUtils.To3DAttributes(position));
    }
    //��������� ������
    public void StopMusicMenu()
    {
        musicEventMenu.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void StopMusicGame()
    {
        musicEventGame.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    //������������ ������
    public void StartMusicAmb()
    {
        musicEventMenu.start();
    }



    void OnDestroy()
    {
        musicEventMenu.release();
    }
}

