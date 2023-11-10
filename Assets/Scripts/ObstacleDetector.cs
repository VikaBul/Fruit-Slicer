using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    public GameObject knife;
    public Animator animator;

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit))
        {
            if (hit.collider.tag == "Obstacle" && knife.GetComponent<Knife>().isCutting)
            {
                animator.SetBool("isHit", true);
            }
        }
    }
}
