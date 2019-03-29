using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenneryFarm : FarmBase 
{
    private void Start()
    {
        string key = "animal_chiken" + Id;
        animalCount = PlayerPrefs.GetInt(key, 2);
    }
}
