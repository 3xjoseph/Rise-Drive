using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust;
    [SerializeField] float rotateThrust;
    [SerializeField] AudioClip rocketThrust;

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
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation() 
    {
        //Rotate Rocket
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateThrust);
        }
        else if ( Input.GetKey(KeyCode.D ) && !Input.GetKey(KeyCode.A)) 
        {
            ApplyRotation(-rotateThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate((Vector3.forward * rotationThisFrame) * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
}
