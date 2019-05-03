using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Product
{
    public string Name;
    public System.DateTime ExpiryDate;
    public float Price;
    public string[] Sizes;
}

public class GameDataInitializer : MonoBehaviour
{
    JsonSerializerSettings settings;

    void Start()
    {
        //Product p = new Product();
        //p.Name = "Apple";
        //p.ExpiryDate = new System.DateTime(2008, 12, 28);
        //p.Price = 3.99f;
        //p.Sizes = new string[] { "Small", "Medium", "Large" };

        //string output = JsonConvert.SerializeObject(p);
        //Debug.Log("++++++++++");
        //Debug.Log(output);
        //Debug.Log("++++++++++");

        //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

        settings = new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.Auto,
            ContractResolver = UnityContractResolver.Instance
        };

        //EnemyType et = new EnemyType();
        //et.name = "Skull";
        //et.physicalShape = new int[1, 1] { { 1 } };
        //et.moveBehaviour = new Stationary();
        //et.actionBehaviour = new MarkAttackerRadial();
        //et.model = "qq";

        //string output = JsonConvert.SerializeObject(et, settings);
        //Debug.Log("++++++++++");
        //Debug.Log(output);
        //Debug.Log("++++++++++");

        //ObstacleType ot = null;
        //ot = new ObstacleType();
        //ot.name = "Skull";
        //ot.size = new Vector2Int(3, 3);
        //ot.center = new Vector2Int(1, 1);
        //ot.physicalShape = new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
        //ot.model = "qq";

        //using (StreamReader sr = new StreamReader(@"c:\json1.txt"))
        //{
        //    ot = JsonConvert.DeserializeObject<ObstacleType>(sr.ReadToEnd(), settings);
        //}

        //JsonSerializer serializer = JsonSerializer.Create(settings);
        //using (StreamWriter sw = new StreamWriter(@"c:\json1.txt"))
        //{
        //    using (JsonWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
        //    {
        //        serializer.Serialize(writer, ot);
        //    }
        //}

        ReadObstacleTypes();
        ReadEnemyTypes();
    }

    void ReadObstacleTypes()
    {
        TextAsset t = Resources.Load<TextAsset>("Data/ObstacleTypes");
        TicTacToeGlobal.obstacleTypes = JsonConvert.DeserializeObject<ObstacleType[]>(t.text, settings);
    }

    void ReadEnemyTypes()
    {
        TextAsset t = Resources.Load<TextAsset>("Data/EnemyTypes");
        TicTacToeGlobal.enemyTypes = JsonConvert.DeserializeObject<EnemyType[]>(t.text, settings);
    }
}
