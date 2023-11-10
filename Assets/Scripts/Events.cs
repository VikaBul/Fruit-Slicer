using UnityEngine;

public class Events : MonoBehaviour
{
    public void OnRestart()
    {
        GameSystem.System.OnRestart();
    }

    public void OnKnifeKill()
    {
        GameSystem.System.OnKnifeKill();
    }
}
