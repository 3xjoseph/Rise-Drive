using UnityEngine;

public class Movement : MonoBehaviour
{
    //Set how fast it thrusts and rotate
    [SerializeField] float mainThrust;
    [SerializeField] float rotateThrust;
    //Get audio clip for rocket thrust
    [SerializeField] AudioClip rocketThrust;
    
    //Particle System for getting specific Particle Prefab
    [SerializeField] ParticleSystem particleLeftThruster;
    [SerializeField] ParticleSystem particleRightThruster;
    [SerializeField] ParticleSystem particleMainThruster;
    [SerializeField] ParticleSystem particleJetBoost;

    Rigidbody myRigidbody;
    AudioSource audioSource;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {    
        //Gets Thrust
        if (Input.GetKey(KeyCode.Space)) 
        {
            
            myRigidbody.AddRelativeForce((Vector3.up * mainThrust) * Time.deltaTime);
            if(!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(rocketThrust);
            }  
            if (!particleMainThruster.isPlaying) 
            {
                particleMainThruster.Play();
            }          
        }
        else
        {
            audioSource.Stop();
            particleMainThruster.Stop();
        }
    }

    void ProcessRotation() 
    {
        //Rotate Rocket
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateThrust);
            if (!particleLeftThruster.isPlaying) 
            {
                particleLeftThruster.Play();
            }  
        }
        else if ( Input.GetKey(KeyCode.D ) && !Input.GetKey(KeyCode.A)) 
        {
            ApplyRotation(-rotateThrust);
            if (!particleRightThruster.isPlaying) 
            {
                particleRightThruster.Play();
            }  
        }
        else 
        {
            particleLeftThruster.Stop();
            particleRightThruster.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate((Vector3.forward * rotationThisFrame) * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
}
