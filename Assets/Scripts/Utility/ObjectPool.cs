using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRObjectType
{
    GameObject objectPrefab
    {
        get;
        set;
    }
}

public interface IRObject<OT>
    where OT : IRObjectType
{
    OT type
    {
        get;
        set;
    }

    GameObject go
    {
        get;
        set;
    }
}

public class ObjectPool<O, T>
    where O : IRObject<T>, new()
    where T : IRObjectType
{
    public Queue<O> objects;

    public O NewObject(T objectType, Transform parent)
    {
        O o;

        if (objects.Count == 0)
        {
            o = new O
            {
                go = GameObject.Instantiate(objectType.objectPrefab, Vector3.zero, Quaternion.identity, parent)
            };
        }
        else
        {
            o = objects.Dequeue();
            o.go.SetActive(true);
        }

        return o;
    }

    public void DeleteObject(O o)
    {
        o.go.SetActive(false);
        objects.Enqueue(o);
    }
}
