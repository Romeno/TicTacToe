using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ActionBehaviourWrap : MonoBehaviour
{
    ActionBehaviour behaviour;

    void Start()
    {
        behaviour.Start();
    }

    void Update()
    {
        behaviour.Update();
    }
}
