using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMD.Particles.Behaviours
{
    /// <summary>
    /// Central reference component for behaviour-based particles.
    /// </summary>

    public class ParticleBehaviour : MonoBehaviour
    {
        public EventHandler<Particle> OnParticleChanged;

        public Particle Particle
        {
            get { return particle; }
            set { SetParticle(value); }
        }
        private Particle particle;

        private void SetParticle (Particle value)
        {
            if (particle == value)
                return;

            particle = value;
            OnParticleChanged?.Invoke(this, particle);
        }

        public void SetPosition (System.Numerics.Vector3 position)
        {
            transform.localPosition = new Vector3()
            {
                x = position.X,
                y = position.Y,
                z = position.Z
            };
        }
    }
}