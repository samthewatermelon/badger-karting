using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kartSelect : NetworkBehaviour
{
    public GameObject selectedcar;
    public GameObject uiElements;
    void Start()
    {
        if (isLocalPlayer || SceneManager.GetActiveScene().name != "kartSelect")
            uiElements.SetActive(false);
        if (!isServer)
            uiElements.transform.Find("OK").gameObject.SetActive(false);
    }

    [Command (requiresAuthority = false)]
    private void CmdSpawn(string carName)
    {
        GameObject carPrefab = NetworkManager.singleton.spawnPrefabs.Find(car => car.name == carName);
        if (!carPrefab)
            return;

        NetworkServer.Destroy(selectedcar);
        GameObject carObj = Instantiate(carPrefab, transform.position, Quaternion.identity);
        selectedcar = carObj;
        NetworkServer.Spawn(carObj, connectionToClient);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        var savedCarPref = playerPreferences.singleton.carPrefrence;
        if (savedCarPref != "")
            CmdSpawn(savedCarPref);
    }

    public void pickCar(string carSelect)
    {
        playerPreferences.singleton.carPrefrence = carSelect;
        CmdSpawn(carSelect);
    }

    public void loadscene(string sceneName)
    {
        if (isServer)
            NetworkManager.singleton.ServerChangeScene(sceneName);
    }
}
