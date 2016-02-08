using UnityEngine;
using System.Collections;

public class UnitSelection : MonoBehaviour {
	
	private bool activeSelection= false;
	private Vector3 onClick;
	private Vector3 offClick;
	private Rect selectionbox;
	public Texture2D selectionTexture;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	    if (Input.GetMouseButtonDown (0)) 
		    {
			    onClick = Input.mousePosition;
			    activeSelection = true;

			    selectionbox.position = onClick;
			    selectionbox.position = new Vector2(selectionbox.position.x, Screen.height - selectionbox.position.y);
          

           
		    }
		else if (Input.GetMouseButtonUp(0))
		    {
			    offClick = Input.mousePosition;
			    activeSelection = false;

		    }
		SetRect ();




	
	}
	void SetRect()
	{
        if (activeSelection)
        {
            selectionbox.height = onClick.y - Input.mousePosition.y;
            selectionbox.width = Input.mousePosition.x - onClick.x;
         if (selectionbox.height < 0)
        {
            selectionbox.y = Screen.height - onClick.y + selectionbox.height;
            selectionbox.height = -selectionbox.height;
        }
            if (selectionbox.width < 0)
            {
                selectionbox.x = onClick.x + selectionbox.width;
                selectionbox.width = -selectionbox.width;
            }

		}
	}

	void OnGUI()
	{
		if (activeSelection) 
		{
		GUI.DrawTexture (selectionbox,selectionTexture);
		}
	}

}
