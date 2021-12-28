using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
   public ParticleSystem explosion;
    //public Gameobject explosion;
   private void Start()
   {
       //explosion.SetActive(false);
   }
   private void OnCollisionEnter(Collision other)
   {
       ContactPoint contact = other.contacts[0];
         Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
         Vector3 pos = contact.point;
         ParticleSystem particleExplosion = Instantiate(explosion, pos, rot);
         if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Ground")
         {
             explosion.Play();
             //explosion.SetActive(true);
         }
         Destroy(gameObject);
   }
}
