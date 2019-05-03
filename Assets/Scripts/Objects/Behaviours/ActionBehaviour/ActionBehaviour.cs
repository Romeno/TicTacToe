using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;


public abstract class ActionBehaviour
{
    // bound component
    [JsonIgnore]
    public MonoBehaviour c;

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }
}
