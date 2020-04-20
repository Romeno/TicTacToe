using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEAssetButton : MonoBehaviour
{
    public GEAsset asset;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region PlayerActions
    public void AssetPressed()
    {
        FileManager.AssetPressed(this);
    }
    #endregion
}
