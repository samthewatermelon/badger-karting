using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class cameraFollowPlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.isLocalPlayer)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = gameObject.transform;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = gameObject.transform;
        }
    }

}
