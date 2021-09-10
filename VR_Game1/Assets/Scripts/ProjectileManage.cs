using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManage : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.tag == "Player")
                {
                    //togli vita al player
                    Destroy(gameObject);
                }
            }

   
}
