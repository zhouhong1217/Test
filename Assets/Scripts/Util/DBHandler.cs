using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class MyBuildingInfo
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Value { get; set; }
    public int DestroyBackCoins { get; set; }
    public string BuildType { get; set; }
}

public class MyBuildingList
{
    public Dictionary<string, MyBuildingInfo> factoryList = new Dictionary<string, MyBuildingInfo>();
    public Dictionary<string, MyBuildingInfo> farmList = new Dictionary<string, MyBuildingInfo>();
    public Dictionary<string, MyBuildingInfo> houseList = new Dictionary<string, MyBuildingInfo>();
    public Dictionary<string, MyBuildingInfo> storeList = new Dictionary<string, MyBuildingInfo>();
}

/// <summary>
/// DBHandler 不考虑线程安全，Unity是单线程的，可以用协程代替多线程
/// </summary>
public class DBHandler
{

    private DBHandler()
    {
        //TODO 读取数据，这里只是初始化
        coins = 100000;
        playerLevel = 1;
        exps = 0;
        population = 100;
        maxPopulation = 200;
        teamNumbers = 3;
        maxTeamNumbers = 5;
    }

    private static DBHandler instance;

    private int playerLevel;

    private int coins;

    private float exps;

    private int population;
    private int maxPopulation;

    private int teamNumbers;
    private int maxTeamNumbers;

    //private List<BuildingBase> buildings = new List<BuildingBase>();

    public int PlayerLevel
    {
        get
        {
            return playerLevel;
        }
    }

    public int Coins
    {
        get
        {
            return coins;
        }
    }

    public float Exps
    {
        get
        {
            return exps;
        }
    }

    public float Population
    {
        get
        {
            return population;
        }
    }

    public float MaxPopulation
    {
        get
        {
            return maxPopulation;
        }
    }

    public float TeamNumbers
    {
        get
        {
            return teamNumbers;
        }
    }

    public float MaxTeamNumbers
    {
        get
        {
            return maxTeamNumbers;
        }
    }

    public static DBHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DBHandler();
            }
            return instance;
        }
    }

    public void AddCoins(int count)
    {
        coins += count;
    }


    /// <summary>
    /// Adds the exps.添加经验，如果经验大于等于100 返回true（已升级），否则返回false
    /// </summary>
    /// <returns>返回true表示升级，返回false表示没有升级</returns>
    /// <param name="count">Count.</param>
    public bool AddExps(int count)
    {
        exps += count;
        if (exps >= 100)
        {
            playerLevel += 1;
            exps = 0;
            return true;
        }
        return false;
    }

    public void AddMaxPopulation(int count)
    {
        maxPopulation += count;
    }

    /// <summary>
    /// Adds the population.如果人口数添加后大于最大人口数则不添加并返回false
    /// </summary>
    /// <returns>返回true表示添加人口成功，返回false表示添加人口失败</returns>
    /// <param name="count">Count.</param>
    public bool AddPopulation(int count)
    {
        if (population + count > maxPopulation)
            return false;
        population += count;
        return true;
    }

    public void AddMaxTeamNumbers(int count)
    {
        maxTeamNumbers += count;
    }

    /// <summary>
    /// Adds the teamNumbers.如果团队人数添加后大于最大团队人数则不添加并返回false
    /// </summary>
    /// <returns>返回true表示添加团队人数成功，返回false表示添加团队人数失败</returns>
    /// <param name="count">Count.</param>
    public bool AddTeamNumbers(int count)
    {
        if (teamNumbers + count > maxTeamNumbers)
            return false;
        teamNumbers += count;
        return true;
    }

#region 读写农场已有的建筑
    public static void SaveFarmBuildToJsonData(Dictionary<int, FarmBase> farms)
    {
        MyBuildingList myBuildingList = new MyBuildingList();

        for (int i = 0; i < farms.Count; i++)
        {
            MyBuildingInfo info = new MyBuildingInfo()
            {
                Value = farms[i].value,
                Id = farms[i].Id,
                Name = farms[i].Name,
                DestroyBackCoins = farms[i].cost / 2,
                BuildType = farms[i].farmType.ToString()
            };
            myBuildingList.farmList.Add(farms[i].Id.ToString(), info);
        }
        string result = JsonMapper.ToJson(myBuildingList);

        Debug.Log(result);
    }

    public static void ReadFarmBuildToObj()
    {
        
    }
#endregion

#region 读写工厂已有的建筑
    public static void SaveFactoryBuildToJsonData(Dictionary<int, FactoryBase> farms)
    {
        MyBuildingList myBuildingList = new MyBuildingList();

        for (int i = 0; i < farms.Count; i++)
        {
            MyBuildingInfo info = new MyBuildingInfo()
            {
                Value = farms[i].value,
                Id = farms[i].Id,
                Name = farms[i].Name,
                DestroyBackCoins = farms[i].cost / 2,
                BuildType = farms[i].factoryType.ToString()
            };
            myBuildingList.farmList.Add(farms[i].Id.ToString(), info);
        }
        string result = JsonMapper.ToJson(myBuildingList);

        Debug.Log(result);
    }
#endregion
}
