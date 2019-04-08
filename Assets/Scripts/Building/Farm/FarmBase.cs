using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FarmType
{
    Hennery = 0,//养鸡场
    CattleFarm = 1,//养牛场
    SheepFarm = 2,//养羊场
}

public class FarmBase : BuildingBase 
{
    public FarmType farmType;
    public int animalCount;

    public List<Animal> animals = new List<Animal>();

    public virtual void InitContent()
    {
        //gameObject.activeInHierarchy
    }
}
