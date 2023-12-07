using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene you want to load

    // This method is called when the button is clicked
    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneToLoad); // Load the specified scene
    }
}
