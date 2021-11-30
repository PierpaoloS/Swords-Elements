using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWallParticle : MonoBehaviour
{
   public GameObject wall;
   public ParticleSystem earthwall;
   public void StartParticleEffect()
   {
      earthwall.Play();
   }

   public void EndParticleEffect()
   {
      earthwall.Stop();
      wall.isStatic = true;
      
   }
}
