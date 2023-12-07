using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LoadScene : NetworkBehaviour
{
    [Scene]
    public string sceneName;
    

    public void loadscene()
    {
        if (isServer)
        {
            Debug.Log("Loding Scene" + sceneName);
            NetworkManager.singleton.ServerChangeScene(sceneName);
        }
    }
}
