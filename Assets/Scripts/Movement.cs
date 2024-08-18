using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody myRigidbody;
    AudioSource audioSource;
    [SerializeField] float mainThrust;
    [SerializeField] float rotateThrust;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource =GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
                audioSource.Play();
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
