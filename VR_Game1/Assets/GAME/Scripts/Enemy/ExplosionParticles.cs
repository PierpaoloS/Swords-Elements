using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
   public ParticleSystem explosion;
   private DestroyParticle destroyParticle;
    //public Gameobject explosion;
    private void Awake()
    {
       // explosion.Stop();
    }

    private void Start()
   {
       //ThrowRock throwRock;
       destroyParticle = GetComponentInChildren<DestroyParticle>();
   }
   private void OnCollisionEnter(Collision other)
   {
       ContactPoint contact = other.contacts[0];
         Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
         Vector3 pos = contact.point;
         Debug.Log("Prima dell instantiate");
         ParticleSystem particleExplosion = Instantiate(explosion, pos, rot);
         Debug.Log("Dopo l' instantiate");
         if (other.gameObject.tag != "Enemy" && particleExplosion /*&& !throwRock.isHoldingRock*/)
         {
             destroyParticle.psIsCreated = true;
             //explosion.Play();
             particleExplosion.Play();
         }
         Destroy(gameObject);
   }
}
