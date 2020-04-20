using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SFB;

static class FileManager
{
    // next id for GE asset
    public static int id = 1;

    // link to FileManagerView GameObject 
    public static FileManagerView fileManView;

    // imported assets
    public static List<GEAsset> impAssets;

    // curently selected asset
    public static GEAssetButton selectedAsset;

    public static string geAssetsDir;

    public static void Init(FileManagerView fmView)
    {
        selectedAsset = null;

        geAssetsDir = Path.Combine(Application.persistentDataPath, "Imported");

        Debug.Log(geAssetsDir);

        fileManView = fmView;
        impAssets = new List<GEAsset>();

        fileManView.chooseBtn.GetComponent<Button>().interactable = false;
        fileManView.renameBtn.GetComponent<Button>().interactable = false;
        fileManView.deleteBtn.GetComponent<Button>().interactable = false;
        fileManView.substituteBtn.GetComponent<Button>().interactable = false;
    }

    public static void Show()
    {
        Debug.Log("- FileManager.Show");
        if (!Directory.Exists(geAssetsDir))
        {
            Directory.CreateDirectory(geAssetsDir);
        }

        foreach (var path in Directory.EnumerateFiles(geAssetsDir))
        {
            LoadAsset(path);
        }
    }

    public static void LoadAsset(string path)
    {
        string ext = Path.GetExtension(path);
        if (ext == ".jpg" ||
            ext == ".jpeg" ||
            ext == ".png")
        {
            GEImageAsset asset = CreateImageAsset(path, ext);
            impAssets.Add(asset);
        }
        else if (ext == ".mp3" ||
            ext == ".wav" ||
            ext == ".flac")
        {
            GESoundAsset asset = CreateSoundAsset(path, ext);
            impAssets.Add(asset);
        }
        else
        {
            GEAsset asset = CreateOtherAsset(path, ext);
            impAssets.Add(asset);
        }
    }

    public static GEImageAsset CreateImageAsset(string path, string ext)
    {
        byte[] fileData = null;

        GEImageAsset asset = new GEImageAsset();

        asset.path = path;
        asset.name = Path.GetFileNameWithoutExtension(path);

        fileData = File.ReadAllBytes(path);
        asset.texture = new Texture2D(2, 2);
        asset.texture.LoadImage(fileData);
        asset.sprite = Sprite.Create(asset.texture, new Rect(0.0f, 0.0f, asset.texture.width, asset.texture.height), new Vector2(0.5f, 0.5f));

        var go = GameObject.Instantiate(fileManView.geAssetButtonPfb, fileManView.panelParent.transform);
        go.SetActive(true);
        go.transform.SetSiblingIndex(fileManView.panelParent.transform.childCount - 2);

        go.GetComponent<GEAssetButton>().asset = asset;

        var cimg = go.transform.GetChild(0).GetComponent<Image>();
        cimg.sprite = GetGEAssetSprite(asset);
        cimg.preserveAspect = true;
        go.transform.GetChild(2).GetComponent<Text>().text = asset.name;

        return asset;
    }

    public static GEAsset CreateOtherAsset(string path, string ext)
    {
        GEAsset asset = new GEAsset();

        asset.path = path;
        asset.name = Path.GetFileNameWithoutExtension(path);

        var go = GameObject.Instantiate(fileManView.geAssetButtonPfb, fileManView.panelParent.transform);
        go.SetActive(true);
        go.transform.SetSiblingIndex(fileManView.panelParent.transform.childCount - 2);

        go.GetComponent<GEAssetButton>().asset = asset;

        var cimg = go.transform.GetChild(0).GetComponent<Image>();
        cimg.sprite = GetGEAssetSprite(asset);
        cimg.preserveAspect = true;
        go.transform.GetChild(2).GetComponent<Text>().text = asset.name;

        return asset;
    }
    
    public static GESoundAsset CreateSoundAsset(string path, string ext)
    {
        GESoundAsset asset = new GESoundAsset();

        asset.path = path;
        asset.name = Path.GetFileNameWithoutExtension(path);

        var go = GameObject.Instantiate(fileManView.geAssetButtonPfb, fileManView.panelParent.transform);
        go.SetActive(true);
        go.transform.SetSiblingIndex(fileManView.panelParent.transform.childCount - 2);

        go.GetComponent<GEAssetButton>().asset = asset;

        var cimg = go.transform.GetChild(0).GetComponent<Image>();
        cimg.sprite = GetGEAssetSprite(asset);
        cimg.preserveAspect = true;
        go.transform.GetChild(2).GetComponent<Text>().text = asset.name;

        return asset;
    }

    #region PlayerActions
    public static void AssetPressed(GEAssetButton go)
    {
        Debug.Log(go.asset.name + " pressed");

        if (selectedAsset)
        {
            selectedAsset.transform.GetChild(1).gameObject.SetActive(false);
        }

        go.transform.GetChild(1).gameObject.SetActive(true);

        fileManView.chooseBtn.GetComponent<Button>().interactable = true;
        fileManView.renameBtn.GetComponent<Button>().interactable = true;
        fileManView.deleteBtn.GetComponent<Button>().interactable = true;
        fileManView.substituteBtn.GetComponent<Button>().interactable = true;

        selectedAsset = go;
    }

    public static void ImportAssetPressed()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", true);
        foreach (var path in paths)
        {
            var filename = Path.GetFileName(path);
            var destPath = Path.Combine(geAssetsDir, filename);

            try
            {
                File.Copy(path, destPath, true);
            }
            catch (System.Exception)
            {
                //TODO: add modal with error
                throw;
            }

            LoadAsset(destPath);
        }
    }

    public static void OnRenameConfirmed(GameObject modal)
    {
        string newName = modal.GetComponent<InputModalStructure>().input.text;
        string newPath = Path.Combine(Path.GetDirectoryName(selectedAsset.asset.path), newName + Path.GetExtension(selectedAsset.asset.path));

        try
        {
            File.Move(selectedAsset.asset.path, newPath);
        }
        catch (System.Exception)
        {
            //TODO: add modal with error
            throw;
        }

        selectedAsset.transform.GetChild(2).GetComponent<Text>().text = newName;

        selectedAsset.asset.name = newName;
        selectedAsset.asset.path = newPath;

        GameObject.Destroy(modal);
    }

    public static void RenameCanceled(GameObject modal)
    {
        GameObject.Destroy(modal);
    }

    public static void RenameSelectedAsset()
    {
        if (selectedAsset)
        {
            InputModalDescription desc = new InputModalDescription(
                selectedAsset.asset.name, "Enter new name for the asset...", 
                "Rename asset", "",
                "Cancel", RenameCanceled, "OK", OnRenameConfirmed);

            TicTacToeGlobal.modalManager.ShowInputModal(GameObject.Find("Canvas").transform, true, desc);
        }
    }

    public static void DeleteSelectedAsset()
    {
        if (selectedAsset)
        {
            try
            {
                File.Delete(selectedAsset.asset.path);
            }
            catch (System.Exception)
            {
                //TODO: add modal with error
                throw;
            }

            GameObject.Destroy(selectedAsset.gameObject);

            //TODO: delete from impAssets

            selectedAsset = null;
            fileManView.chooseBtn.GetComponent<Button>().interactable = false;
            fileManView.renameBtn.GetComponent<Button>().interactable = false;
            fileManView.deleteBtn.GetComponent<Button>().interactable = false;
            fileManView.substituteBtn.GetComponent<Button>().interactable = false;
        }
    }

    public static void SubstituteSelectedAsset()
    {
        if (selectedAsset)
        {

        }
    }
    #endregion

    #region Utility
    public static Sprite GetGEAssetSprite(GEAsset asset)
    {
        if (asset.type == GEAsset.Type.Image)
        {
            //return fileManView.imageIcon;
            return ((GEImageAsset)asset).sprite;
        }
        else if (asset.type == GEAsset.Type.Sound)
        {
            return fileManView.soundIcon;
        }
        else
        {
            return fileManView.otherIcon;
        }
    }
    #endregion
}
