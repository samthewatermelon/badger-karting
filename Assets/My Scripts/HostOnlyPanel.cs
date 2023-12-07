using UnityEngine;
using Mirror;

public class HostOnlyPanel : MonoBehaviour
{
    void Start()
    {
        // Check if the player is the host
        if (NetworkServer.active)
        {
            // Show the panel if the player is the host
            gameObject.SetActive(true);
        }
        else
        {
            // Hide the panel if the player is not the host
            gameObject.SetActive(false);
        }
    }
}
