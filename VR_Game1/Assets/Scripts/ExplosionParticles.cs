using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
   public ParticleSystem explosion;

   private void OnCollisionEnter(Collision other)
   {
      ContactPoint contact = other.contacts[0];
      Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
      Vector3 pos = contact.point;
      ParticleSystem particleExplosion = Instantiate(explosion, pos, rot);
      Destroy(gameObject);
   }
}
