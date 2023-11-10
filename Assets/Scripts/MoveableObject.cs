using UnityEngine;

public class MoveableObject : MonoBehaviour
{
 
    void FixedUpdate()
    {
        transform.Translate(-Vector3.right * Time.deltaTime * GameSystem.System.LEVEL.currentSpeed, Space.World);
    }
}
