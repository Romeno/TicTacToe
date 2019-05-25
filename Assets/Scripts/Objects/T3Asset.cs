using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;


class T3Asset
{
    public string path;
    public string name;
}


class T3ArtModelAsset : T3Asset
{
    public Texture2D texture;
    public Sprite sprite;
}