using UnityEngine;
using System.Collections;

public class ZombieBrain : MonoBehaviour {

	public float speed;
	Vector3 mouse_pos;
	Vector3 object_pos;
	private Vector3 targetaim;
	Vector3 relativ_pos;
	private Animator anim;
	bool isChasing = false;
	float myspeed;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
        


	}
	
	// Update is called once per frame
	void Update () {

       
    



            float distance = Vector2.Distance(targetaim, object_pos);

            if (isChasing)
            {
                myspeed = speed;
                myspeed *= Time.deltaTime;
                transform.Translate(myspeed, 0, 0);
                anim.SetBool("Gun_walk", true);
            }

            if (distance < 0.2)
            {
                myspeed = 0;
                isChasing = false;
                Debug.Log("not Chasing");
                anim.SetBool("Gun_walk", false);
            }

            object_pos = transform.position;
            relativ_pos.x = targetaim.x - object_pos.x;
            relativ_pos.y = targetaim.y - object_pos.y;
            float angle = Mathf.Atan2(relativ_pos.y, relativ_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), 0.1f);


        if (Einheiten.selected)
        {
            if (Input.GetMouseButton(1))
            {
                targetaim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isChasing = true;
                Debug.Log("Chasing");
            }

            

            if (Input.GetKeyDown("p"))
            {
                GetComponent<WeaponSpawner>().Waffenclone.PressTrigger();
                anim.SetTrigger("Gun_Shoot");
            }
            else if(Input.GetKeyUp("p"))
            {
                GetComponent<WeaponSpawner>().Waffenclone.ReleaseTrigger();
            }
        }
	}
}
