using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosSpawnPoint : MonoBehaviour
{
   public float pointRange;
   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.blue;
      Gizmos.DrawWireSphere(transform.position, pointRange);
   }
}
