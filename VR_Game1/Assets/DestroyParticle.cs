using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem ps;
    public bool psIsCreated = false;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /*
        Debug.Log("PS: " + ps + "PS IS ALIVE: "+ps.IsAlive() + "PSISCREATED: "+ psIsCreated);
        
        if (ps && !ps.IsAlive() && psIsCreated)
        {
            Debug.Log("Entro nell if per distruggere particelle");
            Destroy(gameObject);
        }*/

       if (ps.IsAlive())
       {
           Destroy(gameObject, 2f);
       }
    }
    
}
