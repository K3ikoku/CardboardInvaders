using UnityEngine;
using System.Collections;

public class ControlManager : MonoBehaviour
{
    [SerializeField] GameObject[] cannons;
    [SerializeField] private float attackTimer;
    [SerializeField] private float attackCD;
    private Vector3 vrShooterOffset;
    private int cannonNr;


	// Use this for initialization
	void Start ()
    {
        vrShooterOffset = new Vector3(0.0f, -0.4f, 1.0f);  
        if(cannons.Length == 0)
        {
            Debug.Log("Cannon array is empty");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        attackTimer += Time.deltaTime;
	    if(GvrViewer.Instance.VRModeEnabled && GvrViewer.Instance.Triggered && attackTimer >= attackCD)
        {
            attackTimer = 0;
            cannons[cannonNr].GetComponentInChildren<FireCannon>().Fire();
            cannonNr++;
            cannonNr = cannonNr % 2;
        }

        //if (Input.GetButtonDown("Fire1") && attackTimer >= attackCD)
        //{
        //    attackTimer = 0;
        //    cannons[cannonNr].GetComponentInChildren<FireCannon>().Fire();
        //    cannonNr++;
        //    cannonNr = cannonNr % 2;
        //    Debug.Log(cannonNr);
        //}
    }
}
