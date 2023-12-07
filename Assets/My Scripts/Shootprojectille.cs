using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shootprojectille : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform weaponSpawnPosition;
    public float bulletLifetime = 5f; // Time in seconds before the bullet is destroyed
    public float bulletSpeed = 1000f; // Adjust this value to control the bullet speed
    

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

                CmdShootBullet();
                Debug.Log("shote fired");
            
        }
    }
    // Shooting implementation for projectiles
    [Command]
    void CmdShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, weaponSpawnPosition.position, weaponSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed);
        NetworkServer.Spawn(bullet);

        // Destroy the bullet after the specified lifetime
        Destroy(bullet, bulletLifetime);

        RpcBulletSpawned(bullet);
    }

    [ClientRpc]
    void RpcBulletSpawned(GameObject bullet)
    {
        if (!isLocalPlayer)
        {
            Destroy(bullet, bulletLifetime);
        }
    }
}