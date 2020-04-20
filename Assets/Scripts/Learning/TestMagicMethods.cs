using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMagicMethods : MonoBehaviour
{
    void Start()
    {
        //print("~!----------Start called " + Time.frameCount);
    }

    void Update()
    {
        //print("~!-----------Update called " + Time.frameCount);
    }

    void Awake()
    {
        //print("~!-----------Awake called " + Time.frameCount);
    }

    void OnEnable()
    {
        //print("~!-----------OnEnable called " + Time.frameCount);
    }

    static void Quitting()
    {
        print("Quitting");
    }

    [RuntimeInitializeOnLoadMethod]
    static void RunOnStart()
    {
        print("RuntimeMethodLoad: After first Scene loaded " + Time.time);

        Application.quitting += Quitting;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void OnBeforeSceneLoadRuntimeMethod()
    {
        print("Before first Scene loaded " + Time.time);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoadRuntimeMethod()
    {
        print("After first Scene loaded " + Time.time);
    }
}
