using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AddressablesLoader {
    public static async Task InitAssets<T>(string label, List<T> createdObjs, Transform parent)
        where T : UnityEngine.Object {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;

        foreach (var location in locations) {
            createdObjs.Add(await Addressables.InstantiateAsync(location, parent).Task as T);
        }
    }

    public static async Task<T> LoadAssetAsync<T>(string assetName) where T : UnityEngine.Object {
        var handle = Addressables.LoadAssetAsync<T>(assetName);
        return await handle.Task;
    }

    public static async Task<GameObject> InstantiatePrefabAsync(string prefabName, Transform parent, Action<GameObject> onLoaded, Action<float> onProgress) {
        var handle = Addressables.InstantiateAsync(prefabName, parent);

        while (!handle.IsDone) {
            onProgress?.Invoke(handle.PercentComplete);
            await Task.Yield();
        }

        var obj = handle.Result;
        onLoaded?.Invoke(obj);

        return obj;
    }
}