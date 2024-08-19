using UnityEngine;

public class CollisionHandler : MonoBehaviour
{   
    void OnCollisionEnter(Collision other) 
    {
         switch (other.gameObject.tag)
         {
            case "Friendly":
                Debug.Log("This is safe");
                break;
            case "Finish":
                Debug.Log("You have completed the level");
                break;
            case "Fuel":
                Debug.Log("Rocket Refueld");
                break;
            default:
                Debug.Log("Game Over");
                break;
         }

    }
}
