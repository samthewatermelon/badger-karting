using Mirror;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameMenuManager : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject menuRoot;
    [Tooltip("Master volume when menu is open")]
    [Range(0.001f, 1f)]
    public float volumeWhenMenuOpen = 0.5f;
    [Tooltip("Toggle component for shadows")]
    public Toggle shadowsToggle;
    [Tooltip("Toggle component for framerate display")]
    public Toggle framerateToggle;
    [Tooltip("GameObject for the controls")]
    public GameObject controlImage;
    [Tooltip("GameObjecj for Track Change")]
    public GameObject Changetrackimage;
    [Tooltip("Panel shown only to Host")]//hopfuly ill get it to work;
    //public GameObject TrackPanel;    
    //test
    public GameObject onoff;    

    FramerateCounter m_FramerateCounter;

    void Start()
    {
        m_FramerateCounter = FindObjectOfType<FramerateCounter>();
        menuRoot.SetActive(false);       

        shadowsToggle.isOn = QualitySettings.shadows != ShadowQuality.Disable;
        shadowsToggle.onValueChanged.AddListener(OnShadowsChanged);

        framerateToggle.isOn = m_FramerateCounter.uiText.gameObject.activeSelf;
        framerateToggle.onValueChanged.AddListener(OnFramerateCounterChanged);
    }

    private void Update()
    {
        if (Input.GetButtonDown(GameConstants.k_ButtonNamePauseMenu)
            || (menuRoot.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel)))
        {
            if (controlImage.activeSelf)
            {
                controlImage.SetActive(false);
                return;
            }

            SetPauseMenuActivation(!menuRoot.activeSelf);            
        }

        if (Input.GetAxisRaw(GameConstants.k_AxisNameVertical) != 0)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                shadowsToggle.Select();
            }
        }
        
    }

    public void ClosePauseMenu()
    {
        SetPauseMenuActivation(false);       
    }

    public void TogglePauseMenu()
    {
        SetPauseMenuActivation(!menuRoot.activeSelf);       
    }
     
    void SetPauseMenuActivation(bool active)
    {        
        menuRoot.SetActive(active);
        onoff.SetActive(active); // Activate or deactivate the onoff GameObject based on the 'active' parameter.

        if (menuRoot.activeSelf)
        {
            //  Cursor.lockState = CursorLockMode.None;
            //  Cursor.visible = true;
            Time.timeScale = 1f;
            AudioUtility.SetMasterVolume(volumeWhenMenuOpen);
            EventSystem.current.SetSelectedGameObject(null);
            Debug.Log("Game is paused");         

        }
        else
        {
            //  Cursor.lockState = CursorLockMode.Locked;
            //  Cursor.visible = false;
            Time.timeScale = 1f;
            AudioUtility.SetMasterVolume(1);
            Debug.Log("Game is not paused");
            
        }
       
    }

    void OnShadowsChanged(bool newValue)
    {
        QualitySettings.shadows = newValue ? ShadowQuality.All : ShadowQuality.Disable;
    }

    void OnFramerateCounterChanged(bool newValue)
    {
        m_FramerateCounter.uiText.gameObject.SetActive(newValue);
    }

    public void OnShowControlButtonClicked(bool show)
    {
        controlImage.SetActive(show);
    }

    public void OnShowTrackbuttonClicked(bool show)
    {
        Changetrackimage.SetActive(show);
    }

    public void Exit()
    {  
        // stops host 
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        // stop client if client-only
        else if (NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopClient();
        }
        // stop server if server-only
        else if (NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }
    }
}