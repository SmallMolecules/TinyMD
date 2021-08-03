using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMD.Particles.Behaviours
{
    [RequireComponent(typeof(ParticleBehaviour))]
    [RequireComponent(typeof(MeshRenderer))]
    public class ParticleBehaviourRenderer : MonoBehaviour
    {
        private Particle particle;

        private ParticleBehaviour behaviour;
        private MeshRenderer meshRenderer;

        private void OnEnable()
        {
            behaviour = GetComponent<ParticleBehaviour>();
            meshRenderer = GetComponent<MeshRenderer>();

            behaviour.OnParticleChanged += OnParticleChanged;

            if (behaviour.Particle != null)
                OnParticleChanged(this, particle);
        }

        private void OnDisable()
        {
            behaviour.OnParticleChanged -= OnParticleChanged;
            behaviour = null;

            OnParticleChanged(this, null);
        }

        private void OnParticleChanged (object sender, Particle particle)
        {
            this.particle = particle;
            // set associated colours, sizes, etc
        }
    }
}