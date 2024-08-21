using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] float delayInSeconds;
    //Audio Clip for getting specific audio
    [SerializeField] AudioClip rocketCrash;
    [SerializeField] AudioClip levelSuccess;
    //Particle System for getting specific Particle Prefab
    [SerializeField] ParticleSystem particleCrash;
    [SerializeField] ParticleSystem particleSuccess;    

    int currentSceneIndex;
    // Bool variable for State
    bool isTransitioning = false;
    bool collisionsDisabled = false;

    AudioSource audioSource;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() 
    {
        //CheatKeys();
    }

    void CheatKeys()
    {
        if(Input.GetKey(KeyCode.L)) 
        {
            LoadNextLevel();
        }
        else if(Input.GetKey(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionsDisabled) { return; }
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
        particleCrash.Play();
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
        particleSuccess.Play();
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
