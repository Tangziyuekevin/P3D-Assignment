using UnityEngine;
using System.Collections;

public class ParticleAutoDestruction : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }
	
	void Update ()
    {
        bool allStopped = true;

        foreach (ParticleSystem ps in particleSystems)
        {
            if (!ps.isStopped)
            {
                allStopped = false;
            }
        }

        if (allStopped)
        {
            
            if (this.transform.parent != null)
            {
           Destroy(this.transform.parent.gameObject);
            }
            GameObject.Destroy(gameObject);
        }
           
	}

}
