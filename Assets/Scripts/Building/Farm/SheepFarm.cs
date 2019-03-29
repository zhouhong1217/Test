using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepFarm : FarmBase 
{
    private void Start()
    {
        string key = "animal_sheep" + Id;
        animalCount = PlayerPrefs.GetInt(key, 2);
    }
}
