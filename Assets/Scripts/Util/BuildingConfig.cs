using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class BuildingInfo
{
    //public string Name { get; set; }
    public int Value{ get; set; }
    public int Cost{ get; set; }
    public int CostTime{ get; set; }
}

public class BuildingList
{
    public Dictionary<string, BuildingInfo> factoryList = new Dictionary<string, BuildingInfo>();
    public Dictionary<string, BuildingInfo> farmList = new Dictionary<string, BuildingInfo>();
}

public class BuildingConfig : MonoBehaviour
{
    public static BuildingConfig instance;

    public BuildingList container = null;

	private void Awake()
	{
        instance = this;
        LoadConfig();
	}

	private void Start()
	{
        //SerializedDic();

        foreach (var info in container.factoryList)
        {
            Debug.Log("  " + info.Value.Cost + "  " + info.Value.Value + "  " + info.Value.CostTime);
        }

        foreach (var info in container.farmList)
        {
            Debug.Log("  " + info.Value.Cost + "  " + info.Value.Value + "  " + info.Value.CostTime);
        }

    }

    //private void SerializedDic()
    //{
    //    Dictionary<string, BuildingInfo> dic = new Dictionary<string, BuildingInfo>(){
    //        {"FeedMill",new BuildingInfo{ Value = 200, Cost = 150, CostTime = 20}},
    //        {"MilkPlant",new BuildingInfo{ Value = 200, Cost = 150, CostTime = 20}},
    //    };
    //    string result = JsonMapper.ToJson(dic);
    //    Debug.Log(result);
    //}

    private void LoadConfig()
    {
        TextAsset s = Resources.Load("BuildingConfig") as TextAsset;

        if (!s)
            return;

        string temp = s.text;
        container = JsonMapper.ToObject<BuildingList>(temp);
    }
}
