using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SFB;

static class FileManager
{
    public static bool inited = false;

    public static List<T3Asset> assets;

    public static void Init()
    {
        assets = new List<T3Asset>();
        inited = true;
    }

    public static void Show(string rootPath)
    {
        Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$");
        Debug.Log("Showing files at path: " + rootPath);

        byte[] fileData = null;
        if (!inited)
        {
            Init();
        }

        //Transform filesPanel = GameObject.Find("(P) Asset Manager Window").transform.GetChild(3);
        Transform filesPanel = GameObject.Find("(P) Asset Manager Window").transform.GetChild(2).GetChild(0).GetChild(0);
        assets.Clear();
        foreach (var path in Directory.EnumerateFiles(rootPath))
        {
            string ext = Path.GetExtension(path);
            if (ext == ".jpg" ||
                ext == ".jpeg" ||
                ext == ".png")
            {
                T3ArtModelAsset asset = new T3ArtModelAsset();

                asset.path = path;
                asset.name = Path.GetFileNameWithoutExtension(path);

                fileData = File.ReadAllBytes(path);
                asset.texture = new Texture2D(2, 2);
                asset.texture.LoadImage(fileData);
                asset.sprite = Sprite.Create(asset.texture, new Rect(0.0f, 0.0f, asset.texture.width, asset.texture.height), new Vector2(0.5f, 0.5f));

                var go = GameObject.Instantiate(filesPanel.GetChild(filesPanel.childCount - 2).gameObject, filesPanel);
                go.SetActive(true);
                go.transform.SetSiblingIndex(filesPanel.childCount - 3);
                var cimg = go.GetComponent<Image>();
                cimg.sprite = asset.sprite;
                cimg.preserveAspect = true;
                go.transform.GetChild(0).GetComponent<Text>().text = asset.name;
            }
        }
    }

    public static void AssetPressed(Toggle toggle, bool b)
    {
        
    }

    public static void ImportAssetPressed()
    {
        StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
    }
}
