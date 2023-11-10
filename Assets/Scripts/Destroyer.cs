using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slice" || other.tag == "Obstacle")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
            
    }
}
