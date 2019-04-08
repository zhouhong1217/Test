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

public class BuildingConfig
{
    private static BuildingConfig instance;

    public static BuildingConfig Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BuildingConfig();
            }
            return instance;
        }
    }

    private BuildingList container;

    public BuildingList Container
    {
        get
        {
            if (container == null)
            {
                LoadConfig();
            }
            return container;
        }
    }

    private void LoadConfig()
    {
        TextAsset s = Resources.Load("BuildingConfig") as TextAsset;

        if (!s)
            return;

        string temp = s.text;
        container = JsonMapper.ToObject<BuildingList>(temp);
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
}
