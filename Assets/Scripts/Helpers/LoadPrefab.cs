using System.IO;
using UnityEngine;

// https://answers.unity.com/questions/313398/is-it-possible-to-get-a-prefab-object-from-its-ass.html
public class LoadPrefab {
    public static UnityEngine.Object LoadPrefabFromFile(string filename)
    {
        var loadedObject = Resources.Load(filename);
        if (loadedObject == null)
        {
            Debug.Log("Couldn't Find" + filename);
            throw new FileNotFoundException("...no file found - please check the configuration");
        }
        return loadedObject;
    }
}