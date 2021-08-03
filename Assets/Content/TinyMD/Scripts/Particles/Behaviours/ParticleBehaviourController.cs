using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMD.Particles.Behaviours
{
    [RequireComponent(typeof(ParticleBehaviour))]
    public class ParticleBehaviourController : MonoBehaviour
    {
        public float mass;
        public Vector3 position;
        public Vector3 velocity;

        public bool overrideMass = false;
        public bool overridePosition = false;
        public bool overrideVelocity = false;

        private Particle particle;
        private ParticleBehaviour behaviour;

        private void OnEnable()
        {
            behaviour = GetComponent<ParticleBehaviour>();
            behaviour.OnParticleChanged += OnParticleChanged;

            if (behaviour.Particle != null)
                OnParticleChanged(this, behaviour.Particle);
        }

        private void OnDisable()
        {
            behaviour.OnParticleChanged -= OnParticleChanged;
            behaviour = null;

            OnParticleChanged(this, null);
        }

        private void Update()
        {
            if (particle == null)
                return;

            if (overrideMass) 
                particle.mass = mass; 
            else mass = 
                    particle.mass;
            
            if (overridePosition) 
                particle.position = new System.Numerics.Vector3(position.x, position.y, position.z); 
            else 
                position = new Vector3(particle.position.X, particle.position.Y, particle.position.Z);

            if (overrideVelocity)
                particle.velocity = new System.Numerics.Vector3(velocity.x, velocity.y, velocity.z);
            else
                velocity = new Vector3(particle.velocity.X, particle.velocity.Y, particle.velocity.Z);
        }

        private void OnParticleChanged (object sender, Particle particle)
        {
            this.particle = particle;
        }
    }
}