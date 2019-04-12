using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : IRObject<MarkType>
{
    private MarkType _type;
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
