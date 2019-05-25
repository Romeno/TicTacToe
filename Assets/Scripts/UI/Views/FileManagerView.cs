using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FileManagerView : MonoBehaviour
{
    #region Unity
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        //ShowFileManager();
    }
    #endregion

    #region PlayerActions
   
    #endregion

    public void InitFileManager()
    {
        FileManager.Show(Application.temporaryCachePath);
    }

    public static void ImportAssetPressed()
    {
        FileManager.ImportAssetPressed();
    }
}
