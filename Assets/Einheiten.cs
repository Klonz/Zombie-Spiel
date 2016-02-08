using UnityEngine;
using System.Collections;

public class Einheiten : MonoBehaviour {
    public Renderer rend;
    public static bool selected;
    private Animator anim;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }

    private bool animplay = false;
	
	void Update () {
        if (rend.isVisible && Input.GetMouseButton(0))
        {
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = Selection.InvertMouseY(camPos.y);
            selected = Selection.selectionBox.Contains(camPos);
           
            
        }
        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.green;
            if (!animplay)

            {
                anim.SetTrigger("animSelection");
                animplay = true;

            }

        }
        else
        {

            GetComponent<Renderer>().material.color = Color.white;
            animplay = false;
        }
            

    }
}

