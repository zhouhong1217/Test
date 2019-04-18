using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour 
{
    public static BuildingController instance;

    [SerializeField] private Transform townContainer;

    private Dictionary<int, HouseBase> houseDictionary = new Dictionary<int, HouseBase>();//key值从1开始。。。key值为id
    private Dictionary<int, FactoryBase> factoryDictionary = new Dictionary<int, FactoryBase>();//key值从1开始。。。
    private Dictionary<int, StoreBase> storeDictionary = new Dictionary<int, StoreBase>();//key值从1开始。。。
    private Dictionary<int, FarmBase> farmDictionary = new Dictionary<int, FarmBase>();//key值从1开始。。。

	private void Awake()
	{
        instance = this;
	}

    public void AddCoins(int count)
    {
        DBHandler.Instance.AddCoins(count);
    }

    public void AddExps(int count)
    {
        bool isUpgrade = DBHandler.Instance.AddExps(count);
        if (isUpgrade)
        {
            //TODO 刷新UI
            Debug.Log("发送消息，升级啦！！！");
        }
    }

    public void AddMaxPopulation(int count)
    {
        DBHandler.Instance.AddMaxPopulation(count);
    }

    public void AddPopulation(int count)
    {
        bool addSuccessed = DBHandler.Instance.AddPopulation(count);
        if (!addSuccessed)
        {
            //TODO 弹出请建造更多的Store来增加最大人口
            Debug.Log("请建造更多的Store来增加最大人口");
        }
    }

    public void AddMaxTeamNumbers(int count)
    {
        DBHandler.Instance.AddMaxTeamNumbers(count);
    }

    public void AddTeamNumbers(int count)
    {
        bool addSuccessed = DBHandler.Instance.AddTeamNumbers(count);
        if (!addSuccessed)
        {
            //TODO 弹出增加等级来增加团队人数最大数
            Debug.Log("增加等级来增加团队人数最大数");
        }
    }

    /// <summary>
    /// Builds the farm.
    /// </summary>
    /// <returns>创建成功返回true，否则返回false</returns>
    /// <param name="farmType">Farm type.</param>
    public bool BuildFarm(FarmType farmType)
    {
        switch (farmType)
        {
            case FarmType.CattleFarm:
                Debug.Log("生成一个养牛场");
                BuildingInfo cattleInfo = BuildingConfig.Instance.Container.farmList["CattleFarm"];

                if (DBHandler.Instance.Coins < cattleInfo.Cost)
                    return false;
                CattleFarm cattleFarmPrefab = Resources.Load<CattleFarm>("Prefabs/CattleFarm");
                CattleFarm cattleFarm = Instantiate(cattleFarmPrefab);
                cattleFarm.farmType = FarmType.CattleFarm;
                InitFarmContent(cattleFarm, cattleInfo);
                break;
            case FarmType.Hennery:
                Debug.Log("生成一个养鸡场");
                BuildingInfo henneryInfo = BuildingConfig.Instance.Container.farmList["Hennery"];

                if (DBHandler.Instance.Coins < henneryInfo.Cost)
                    return false;
                HenneryFarm henneryPrefab = Resources.Load<HenneryFarm>("Prefabs/Hennery");
                HenneryFarm henneryFarm = Instantiate(henneryPrefab);
                henneryFarm.farmType = FarmType.Hennery;
                InitFarmContent(henneryFarm, henneryInfo);
                break;
            case FarmType.SheepFarm:
                Debug.Log("生成一个养羊场");
                BuildingInfo sheepInfo = BuildingConfig.Instance.Container.farmList["SheepFarm"];

                if (DBHandler.Instance.Coins < sheepInfo.Cost)
                    return false;
                SheepFarm sheepFarmPrefab = Resources.Load<SheepFarm>("Prefabs/SheepFarm");
                SheepFarm sheepFarm = Instantiate(sheepFarmPrefab);
                sheepFarm.farmType = FarmType.SheepFarm;
                InitFarmContent(sheepFarm, sheepInfo);
                break;
            default:
                return false;
        }
        return true;
    }

    private void InitFarmContent(FarmBase farm,BuildingInfo info)
    {
        farm.transform.SetParent(townContainer);

        farm.buildStatus = BuildStatus.Moving;
        farm.value = info.Value;
        farm.cost = info.Cost;
        farm.costTime = info.CostTime;
        farm.Id = farmDictionary.Count + 1;
        farm.InitContent();
        farmDictionary.Add(farm.Id, farm);
    }

	public void SaveToJsonData()
    {
        ////TODO test
        //for (int i = 0; i < 10; i++)
        //{
        //    CattleFarm cattleFarmPrefab = Resources.Load<CattleFarm>("Prefabs/CattleFarm");
        //    CattleFarm cattleFarm = Instantiate(cattleFarmPrefab);
        //    cattleFarm.value = i*100;
        //    cattleFarm.cost = i*50;
        //    cattleFarm.costTime = i*10;
        //    cattleFarm.Id = i;
        //    farmDictionary[i] = cattleFarm;
        //}

        DBHandler.SaveFarmBuildToJsonData(farmDictionary);
    }

    /// <summary>
    /// Builds the factory.
    /// </summary>
    /// <returns>创建成功返回true，否则返回false</returns>
    /// <param name="buildType">Build type.</param>
    public bool BuildFactory(FactoryType buildType)
    {
        switch (buildType)
        {
            case FactoryType.FeedMill:
                //TODO Instantiate<Factory> Prefab
                Debug.Log("生成一个饲料厂");
                if (DBHandler.Instance.Coins < BuildingConfig.Instance.Container.factoryList["FeedMill"].Cost)
                    return false;
                FeedMill feedMillPrefab = Resources.Load<FeedMill>("");
                FeedMill feedMill = Instantiate(feedMillPrefab);
                feedMill.Id = factoryDictionary.Count + 1;
                factoryDictionary.Add(factoryDictionary.Count+1, feedMill);
                break;
            case FactoryType.MilkPlant:
                //TODO Instantiate<House> Prefab
                Debug.Log("生成一个乳品厂");
                if (DBHandler.Instance.Coins < BuildingConfig.Instance.Container.factoryList["MilkPlant"].Cost)
                    return false;
                MilkPlant milkPlantPrefab = Resources.Load<MilkPlant>("");
                MilkPlant milkPlant = Instantiate(milkPlantPrefab);
                milkPlant.Id = factoryDictionary.Count + 1;
                factoryDictionary.Add(factoryDictionary.Count + 1, milkPlant);
                break;
            case FactoryType.SugarHouse:
                //TODO Instantiate<Store> Prefab
                Debug.Log("生成一个制糖厂");
                if (DBHandler.Instance.Coins < BuildingConfig.Instance.Container.factoryList["SugarHouse"].Cost)
                    return false;
                SugarHouse SugarHousePrefab = Resources.Load<SugarHouse>("");
                SugarHouse sugarHouse = Instantiate(SugarHousePrefab);
                sugarHouse.Id = factoryDictionary.Count + 1;
                factoryDictionary.Add(factoryDictionary.Count + 1, sugarHouse);
                break;
            //case FactoryType.TextileMill:
            //    //TODO Instantiate<Store> Prefab
            //    Debug.Log("生成一个纺织厂");
            //    break;
            //case FactoryType.SnackFactory:
            //    //TODO Instantiate<Store> Prefab
            //    Debug.Log("生成一个零食厂");
            //    break;
            //case FactoryType.Deli:
            //    //TODO Instantiate<Store> Prefab
            //    Debug.Log("生成一个烘焙坊");
            //    break;
            //case FactoryType.Tailor:
                ////TODO Instantiate<Store> Prefab
                //Debug.Log("生成一个裁缝店");
                //break;
            default:
                return false;
        }
        return true;
    }
}
