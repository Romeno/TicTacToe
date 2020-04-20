using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FileManagerView : MonoBehaviour
{
    public GameObject geAssetButtonPfb;
    public GameObject panelParent;
    public GameObject chooseBtn;
    public GameObject renameBtn;
    public GameObject deleteBtn;
    public GameObject substituteBtn;

    // icons for generic GE asset types
    public Sprite imageIcon;
    public Sprite soundIcon;
    public Sprite otherIcon;

    #region Unity
    void Start()
    {
        FileManager.Init(this);
        FileManager.Show();
    }

    void Update()
    {

    }

    void OnEnable()
    {

    }
    #endregion

    #region PlayerActions

    public void RenameGEAsset()
    {
        FileManager.RenameSelectedAsset();
    }

    public void DeleteGEAsset()
    {
        FileManager.DeleteSelectedAsset();
    }

    public void SubstituteGEAsset()
    {
        FileManager.SubstituteSelectedAsset();
    }

    #endregion

    public void InitFileManager()
    {
        FileManager.Show();
    }

    public void ImportAssetPressed()
    {
        FileManager.ImportAssetPressed();
    }
}
