using UnityEngine;
using System.Collections;

public class FireCannon : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private LineRenderer line;
    private Light gunLight;
    private GameObject mainCam;
    private int damage = 75;
    private float effectsTimer;
    private float effectsDisplayTime = 0.2f;
    private int shootMask;
    private float range = 200f;

	// Use this for initialization
	void Start ()
    {
        line = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        shootMask = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void Update ()
    {
        effectsTimer += Time.deltaTime;   

        if(effectsTimer >= effectsDisplayTime)
        {
            DisableEffects();
        }
	}

    public void Fire()
    {
        effectsTimer = 0;

        ray.origin = mainCam.transform.position;
        ray.direction = mainCam.transform.forward;

        line.enabled = true;
        line.SetPosition(0, transform.position);

        if(Physics.Raycast (ray, out hit, range))
        {
            Entity entity = hit.collider.GetComponent<Entity>();
            if(entity != null)
            {
                entity.TakeDamage(damage);
            }
            line.SetPosition(1, hit.point);
        }

        else
        {
            line.SetPosition(1, ray.origin + ray.direction * range);
        }

    }

    void DisableEffects()
    {
        line.enabled = false;
        gunLight.enabled = false;
    }
}
