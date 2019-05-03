using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mark : IRObject<MarkType>
{
    [SerializeField]
    private MarkType _type;

    [SerializeField]
    private GameObject _go;

    public MarkType type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }

    public GameObject go
    {
        get
        {
            return _go;
        }

        set
        {
            _go = value;
        }
    }
}
