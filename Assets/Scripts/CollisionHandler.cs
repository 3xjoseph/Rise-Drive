using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] float delayInSeconds;
    [SerializeField] AudioClip rocketCrash;
    [SerializeField] AudioClip levelSuccess;

    int currentSceneIndex;
    bool isTransitioning = false;

    AudioSource audioSource;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) { return; }
         switch (other.gameObject.tag)
         {
            case "Friendly":
                Debug.Log("This is safe");
                break;
            case "Finish":
                StartSuccessSequence();                
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        //TODO: Particle FX
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(rocketCrash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayInSeconds);
    }

    void ReloadLevel()
    {     
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartSuccessSequence() 
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(levelSuccess);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayInSeconds);
    }
    void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}
