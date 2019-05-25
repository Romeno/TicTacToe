using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Enemy : MonoBehaviour
{
    [JsonIgnore]
    public MoveState moveState;

    [JsonIgnore]
    public ActionState actionState;

    EnemyType type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
