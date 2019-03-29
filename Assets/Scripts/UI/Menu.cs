using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{
    public Button[] buttons;

	void Start () 
    {
        buttons[0].onClick.AddListener(BuildCattleFarm);
	}

    private void BuildCattleFarm()
    {
        Debug.Log("BuildClicked");
        BuildingController.instance.BuildFarm(FarmType.CattleFarm);
        gameObject.SetActive(false);
    }
}
