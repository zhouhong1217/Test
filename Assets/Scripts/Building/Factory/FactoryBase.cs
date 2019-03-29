using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FactoryType
{
    FeedMill,//饲料厂
    MilkPlant,//乳品厂
    SugarHouse,//制糖厂
    TextileMill,//纺织厂
    SnackFactory,//零食厂
    Deli,//烘焙坊
    Tailor,//裁缝店
}

public class FactoryBase : BuildingBase 
{
    public int Id;

    public Goods[] goodsContainer = new Goods[6];//存放已经制作好的商品

    public List<Goods> goods = new List<Goods>();//存放可以制作的商品，可配置

    public List<Goods> productionBox = new List<Goods>();//存放正在生产的商品，开始长度为2 ，花钱可增大到6

}
