using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class AssetBundleLabelRemover
{
    [MenuItem("Tools/Remove All AssetBundle Labels")]
    public static void RemoveAllAssetBundleLabels()
    {
        string[] allAssetPaths = AssetDatabase.GetAllAssetPaths();
        int count = 0;

        foreach (string assetPath in allAssetPaths)
        {
            string assetBundleName = AssetImporter.GetAtPath(assetPath).assetBundleName;
            if (!string.IsNullOrEmpty(assetBundleName))
            {
                AssetImporter.GetAtPath(assetPath).assetBundleName = "";
                count++;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"Removed AssetBundle labels from {count} assets.");
    }
}
#endif
