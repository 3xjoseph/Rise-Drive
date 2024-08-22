using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) {return;}

        //continually growing over time.
        float cycles = Time.time / period;

        //Constant value of 6.283.
        const float tau = Mathf.PI * 2;

        //Going from -1 to 1.
        float rawSinWave = Mathf.Sin(cycles * tau);

        //Recalculated to go from 0 to 1 so it's cleaner.
        movementFactor = (rawSinWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
