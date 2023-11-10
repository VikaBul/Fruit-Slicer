using UnityEngine;

public class Knife : MonoBehaviour
{
    public Animator knifeAnimator;
    public bool isCutting;
    private Rect screenBounds;

    public float timeElapsed = 0f;
    private float clickTimeFrame = 0.1f;

    void Start()
    {
        screenBounds = new Rect(0, 0, Screen.width, Screen.height - 200);
    }

    public void SetCuttingState(bool state)
    {
        isCutting = state;
        knifeAnimator.SetBool("isCutting", state);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && screenBounds.Contains(Input.mousePosition) && isCutting == false)
        {
            timeElapsed = 0f;
            SetCuttingState(true);
        }
        else
        {
            timeElapsed += Time.fixedDeltaTime;
            if (timeElapsed >= clickTimeFrame && isCutting)
            {
                SetCuttingState(false);
                timeElapsed = 0f;
            }
        }
    }
}
