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
       // Проверяем, существует ли уже экземпляр
    if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject); // Не уничтожаем при загрузке новой сцены
      }
    else
      {
           Destroy(gameObject); // Уничтожаем дубликат
      }
    }

    void Start()
    {
        //Экземпляр события
        musicEventMenu = RuntimeManager.CreateInstance("event:/Amb1");
        musicEventGame = RuntimeManager.CreateInstance("event:/Amb2");
        musicEventMenu.start();

        //Позицию источника звука
        Vector3 position = transform.position;
        musicEventMenu.set3DAttributes(RuntimeUtils.To3DAttributes(position));
    }
    //Остановка музыки
    public void StopMusicMenu()
    {
        musicEventMenu.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void StopMusicGame()
    {
        musicEventGame.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    //Проигрывание музыки
    public void StartMusicAmb()
    {
        musicEventMenu.start();
    }



    void OnDestroy()
    {
        musicEventMenu.release();
    }
}

