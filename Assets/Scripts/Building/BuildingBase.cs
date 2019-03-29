using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildType{
    Store,
    Factory,
    House,
    Farm
}

public enum BuildStatus{
    Building,
    BuildComplete,
    Moving
}

public class BuildingBase : MonoBehaviour 
{
    public int value;

    public int cost;

    public int costTime;

    //private BoxCollider2D boxCollider;

    private float pressedTime = 0f;

    private bool isBuilding;
    private bool isDraging;

    private BuildStatus buildStatus;

	private void Awake()
	{
        gameObject.AddComponent<BoxCollider2D>();
        buildStatus = BuildStatus.Moving;
	}

    protected virtual void OnMouseDown()
	{
        //TODO 建筑外轮廓高亮，播放一个放大的动画
        Debug.Log("OnMouseDown");

    }

    protected virtual void OnMouseDrag()
	{
        if (buildStatus == BuildStatus.Moving)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x,pos.y,0);
            return;
        }

        pressedTime += Time.deltaTime;

        if (pressedTime < 1)
            return;
        
        //TODO 一直按压时效果，抬起建筑，可拖动
        Debug.Log("OnMouseDrag");
	}

    protected virtual void OnMouseUpAsButton()
	{
        pressedTime = 0f;
		//TODO 当鼠标抬起时
        Debug.Log("OnMouseUp");
	}
}
