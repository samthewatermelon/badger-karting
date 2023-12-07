using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPreferences : MonoBehaviour
{
    public string carPrefrence = "kart1";
    public static playerPreferences singleton;

    private void Start()
    {
        singleton = this;
    }
}
