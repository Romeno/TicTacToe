using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

// Game Engine Asset
public class GEAsset
{
    public enum Type
    {
        Other,
        Image,
        Sound
    }

    public string path;
    public string name;
    public Type type;

    public GEAsset()
    {
        type = Type.Other;
    }
}


public class GEImageAsset : GEAsset
{
    public Texture2D texture;
    public Sprite sprite;

    public GEImageAsset()
    {
        type = Type.Image;
    }
}

public class GESoundAsset : GEAsset
{
    public GESoundAsset()
    {
        type = Type.Sound;
    }
}