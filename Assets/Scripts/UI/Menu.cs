using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{
    public Button[] buttons;

    public GameObject scrollView;
    
    private Button menuBtn;
    
	void Start ()
	{
	    menuBtn = GetComponent<Button>();
	    menuBtn.onClick.AddListener(MenuClicked);

        buttons[0].onClick.AddListener(BuildCattleFarm);
        buttons[1].onClick.AddListener(BuildHennery);
        buttons[2].onClick.AddListener(BuildSheepFarm);
	}

    private void MenuClicked()
    {
        scrollView.SetActive(true);
    }
    
    private void BuildCattleFarm()
    {
        BuildingController.instance.BuildFarm(FarmType.CattleFarm);
        scrollView.SetActive(false);
    }
    
    private void BuildHennery()
    {
        BuildingController.instance.BuildFarm(FarmType.Hennery);
        scrollView.SetActive(false);
    }
    
    private void BuildSheepFarm()
    {
        BuildingController.instance.BuildFarm(FarmType.SheepFarm);
        scrollView.SetActive(false);
    }
}
