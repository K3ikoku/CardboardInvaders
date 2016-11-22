using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    protected Stats m_stats;
	// Use this for initialization
	protected virtual void Start ()
    {
        m_stats = this.GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    protected virtual void TakeDamage(float damage)
    {
        m_stats.Health -= damage;

        if (0 >= m_stats.Health)
        {
            Destroy();
        }

    }

    protected virtual void Destroy()
    {

        //TODO: Create function too make death look better
        DestroyObject(gameObject);

    }
}
