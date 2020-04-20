using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class EnemyData
{
    [JsonIgnore]
    public MoveState moveState;

    [JsonIgnore]
    public ActionState actionState;

    EnemyType type;
}
