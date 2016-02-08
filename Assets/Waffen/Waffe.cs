using UnityEngine;
using System.Collections;

public class Waffe : MonoBehaviour {

    public int MagSize;
    public FireTypes FireType;
    public int TimeToReload;
    public int FireRate;
    public int FireRange;
    public Texture2D Image;
    public Projectile Kugel;


    bool isTriggered;
    int LastShot;


	void Start () {
	
	}
	
	
	void Update () {
        if (isTriggered && LastShot < Time.frameCount - FireRate && MagSize > 0)
        {
            Shoot();
            LastShot = Time.frameCount;
            MagSize -= 1;

        }
	
	}


    void Shoot()
    {
       Projectile tempProjectile = Instantiate(Kugel);
       tempProjectile.transform.eulerAngles = transform.eulerAngles;
       tempProjectile.transform.position = transform.position;
       tempProjectile.transform.Translate(tempProjectile.Speed, 0, 0);
        
    }

    public void PressTrigger()
    {
        isTriggered = true;
    }
    public void ReleaseTrigger()
    {
        isTriggered = false;
    }

    public enum FireTypes {Auto,SemiAuto,SingleShot}
}


