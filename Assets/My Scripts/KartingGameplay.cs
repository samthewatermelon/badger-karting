using UnityEngine;
using Mirror;

public class KartingGameplay : NetworkBehaviour
{
    // Reference to the sphere object in the scene
    public GameObject sphereObject;

    [Header("Prefabs")]
    public GameObject playerPrefab;
    public GameObject aiPlayerPrefab;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    // Rest of the script...

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // Set the layer of the player object
        gameObject.layer = LayerMask.NameToLayer("Player");

        // Set the tag of the sphere object to match the player object
        if (sphereObject != null)
        {
            sphereObject.tag = gameObject.tag;
        }

        // Rest of the method...
    }

    // Rest of the script...
}