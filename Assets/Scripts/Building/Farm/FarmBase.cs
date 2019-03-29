using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FarmType
{
    Hennery,//养鸡场
    CattleFarm,//养牛场
    SheepFarm,//养羊场
}

public class FarmBase : BuildingBase 
{
    public int Id;
    public int animalCount;

    public List<Animal> animals = new List<Animal>();

    public virtual void InitContent()
    {
        
    }
}
