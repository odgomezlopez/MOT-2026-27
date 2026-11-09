using DesignPatterns.Singleton;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class RunGameManager : Singleton<RunGameManager>
{
    public void GameOver()
    {
        //Time.timeScale = 0f;
        //UIManager.Instance.ShowGameOverPanel();
        //RestartGame();

        StartCoroutine(RestartGameWithDelay(0.5f));
    }


    public IEnumerator RestartGameWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RestartGame();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#else 
        Application.Quit();
#endif
        
    }
}
