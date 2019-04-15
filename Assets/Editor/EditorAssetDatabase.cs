using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;


//public class EditorAssetdatabase
//{
//    [MenuItem("MyMenu/TestAssetDB", false, 20)]
//    public static void TestAssetDatabase()
//    {
//        string[] names = AssetDatabase.GetAllAssetBundleNames();
//        Debug.Log("AssetDatabase.GetAllAssetBundleNames (" + names.Length + "): ");
//        foreach (var name in names)
//        {
//            Debug.Log(name);
//        }
//        Debug.Log("AssetDatabase.GetCurrentCacheServerIp()" + AssetDatabase.GetCurrentCacheServerIp());
//        Debug.Log("AssetDatabase.IsValidFolder()" + AssetDatabase.IsValidFolder("Assets/"));
//    }

//    [OnOpenAsset]
//    public static bool OnOpenAssetCallback(int instanceID, int line)
//    {
//        string name = EditorUtility.InstanceIDToObject(instanceID).name;
//        Debug.Log("Open Asset step: 1 (" + name + ")");

//        return false;
//    }

//}