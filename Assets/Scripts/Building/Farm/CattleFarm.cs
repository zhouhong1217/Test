using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CattleFarm : FarmBase 
{
	private void Start()
	{
        string key = "animal_cattle" + Id;
        animalCount = PlayerPrefs.GetInt(key, 2);
	}

	public override void InitContent()
	{
		base.InitContent();
        for (int i = 0; i < animalCount; i++)
        {

        }
    }
}
