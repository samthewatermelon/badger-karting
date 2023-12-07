using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public string url = "";
    public RawImage rawImage;

    IEnumerator Start()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error downloading image: " + www.error);
            }
            else
            {
                // Assign texture to RawImage
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                rawImage.texture = texture;
            }
        }
    }
}
