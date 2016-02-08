using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour {
	public Transform Player;
	public Transform Direction;
	public Waffe myWaffe;
    public Waffe Waffenclone;




	// Use this for initialization
	void Start () {

       //myWaffe = (GameObject)Instantiate(Resources.Load("Gun"),new Vector3(0,0,-50),Quaternion.identity);


    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("w")) {
			
            Waffenclone = Instantiate(myWaffe);
		}

        Waffenclone.transform.eulerAngles = Direction.eulerAngles;
        Waffenclone.transform.position = Player.position;
	}
}
