using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
   public ParticleSystem explosion;

   private void OnCollisionEnter(Collision other)
   {
      //if (other.gameObject.tag == "Player" && other.gameObject.tag == "Ground" && other.gameObject.tag == "FireBall" && other.gameObject.tag == "Enviroment")
      //{
         Destroy(gameObject);
         ContactPoint contact = other.contacts[0];
         Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
         Vector3 pos = contact.point;
         ParticleSystem particleExplosion = Instantiate(explosion, pos, rot);
         explosion.Play();
      //}
   }
   
}
