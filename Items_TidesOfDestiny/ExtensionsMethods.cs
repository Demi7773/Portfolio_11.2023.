using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsMethods
{
    public static void ActivateChildren(this Transform transform, bool onoff = true)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(onoff);
        }
    }



    public static void ResetLocalTransform(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var component = gameObject.GetComponent<T>();
        if (ReferenceEquals(component, null))
        {
            component = gameObject.AddComponent<T>();
            Debug.Log("GetOrAddComponent added a component: " + component.name);
        }
        return component;
    }

    public static T GetRandomItem<T>(this IList<T> list)
    {
        if (!ReferenceEquals(list, null) && list.Count > 0)
        {
            return list[Random.Range(0, list.Count)];
        }
        else
        {
            Debug.LogError("List is null or empty");
            return default;
        }
    }

    public static T GetRandomItemAndRemove<T>(this IList<T> list)
    {
        T item = list.GetRandomItem<T>();
        list.Remove(item);
        return item;
    }

    public static T TranscribeToThisList<T>(this IList<T> list, IList<T> listToTranscribe)
    {
        for (int i = 0; i <= listToTranscribe.Count; i++)
        {
            list.Add(listToTranscribe[i]);
        }
        return (T)list;
    }
}
