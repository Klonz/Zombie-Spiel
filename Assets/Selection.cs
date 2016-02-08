using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

    public static Rect selectionBox;
    private Vector3 onClick = -Vector3.one;
    public Texture2D selectionTexture;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        SetRect();



	
	}

    void SetRect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick = Input.mousePosition;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onClick = -Vector3.one;
        }
        if (Input.GetMouseButton(0))
        {
            selectionBox = new Rect(onClick.x, InvertMouseY(onClick.y),Input.mousePosition.x - onClick.x, onClick.y - Input.mousePosition.y);

            if (selectionBox.height < 0)
            {
                selectionBox.y = InvertMouseY(onClick.y) + selectionBox.height;
                selectionBox.height *= -1;
            }
            if (selectionBox.width < 0)
            {
                selectionBox.x = onClick.x + selectionBox.width;
                selectionBox.width *= -1;
            }
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }

    void OnGUI()
    {
        if (onClick!= -Vector3.one)
        {
            GUI.DrawTexture(selectionBox, selectionTexture);  
        }
    }
}
