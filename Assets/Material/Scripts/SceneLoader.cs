using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    // ����� ��� �������� �� ������� �� ������
    public void LoadLevel(int sceneIndex)
    {
        // ���������, ���������� �� ����� � ������ ��������
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);

        }
        else
        {
            Debug.LogError("����� � �������� " + sceneIndex + " �� �������!");
        }
    }
    
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void Repit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
