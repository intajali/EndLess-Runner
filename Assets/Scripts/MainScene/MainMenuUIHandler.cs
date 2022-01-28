
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{

    private const string assestPath = "https://ln5.sync.com/dl/e6d7052d0/3xtf8v5t-nz95zgry-ds8famtc-vtrcbrp3/view/image/7566592670011/texture 1.jpg";

    private string folderName = "LocalAsset";

    private Coroutine routine = null;

    string savePath = "";
    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "/LocalAsset");
    }

    public void LoadAsset()
    {
        if (routine != null)
            StopCoroutine(routine);
        routine = StartCoroutine(DownloadAsset());
       
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(GameConstants.GAMEPLAY_SCENE);
    }

    public void LoadOptimizationScene()
    {
        SceneManager.LoadScene(GameConstants.OPTIMISE_SCENE);
    }

    public void ClearLocalAssets()
    {
        DirectoryInfo di = new DirectoryInfo(savePath);

        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete();
        }
    }


    IEnumerator DownloadAsset()
    {
        using (var www = UnityWebRequestTexture.GetTexture(assestPath))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    //var texture = DownloadHandlerTexture.GetContent(www);
                    byte[] results = www.downloadHandler.data;
                    saveImage(savePath, results);
                }
            }
        }
    }

    void saveImage(string path, byte[] imageBytes)
    {
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        try
        {
            File.WriteAllBytes(path, imageBytes);
            Debug.Log("Saved Data to: " + path.Replace("/", "\\"));
        }
        catch (Exception e)
        {
            Debug.LogWarning("Failed To Save Data to: " + path.Replace("/", "\\"));
            Debug.LogWarning("Error: " + e.Message);
        }
    }



}
