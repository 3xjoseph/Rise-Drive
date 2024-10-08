using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    public void RestartGame()
    {
        int currentSceneIndex;
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exited the Game");
        // For testing purposes in the Editor
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    } 
}
