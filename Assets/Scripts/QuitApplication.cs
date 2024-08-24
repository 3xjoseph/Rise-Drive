using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Quits the applicaition
            Application.Quit();
            Debug.Log("You have exited the game");
        }
    }
}
