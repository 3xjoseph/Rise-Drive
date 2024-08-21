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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation() 
    {
        //Rotate Rocket
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            RotateLeftRocket();
        }
        else if ( Input.GetKey(KeyCode.D ) && !Input.GetKey(KeyCode.A))
        {
            RotateRightRocket();
        }
        else
        {
            StopRotation();
        }
    }

    void StartThrusting()
    {
        myRigidbody.AddRelativeForce((Vector3.up * mainThrust) * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketThrust);
        }
        if (!particleMainThruster.isPlaying)
        {
            particleMainThruster.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        particleMainThruster.Stop();
    } 

    void RotateLeftRocket()
    {
        ApplyRotation(rotateThrust);
        if (!particleLeftThruster.isPlaying)
        {
            particleLeftThruster.Play();
        }
    }

    void RotateRightRocket()
    {
        ApplyRotation(-rotateThrust);
        if (!particleRightThruster.isPlaying)
        {
            particleRightThruster.Play();
        }
    }

    void StopRotation()
    {
        particleLeftThruster.Stop();
        particleRightThruster.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate((Vector3.forward * rotationThisFrame) * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
}
