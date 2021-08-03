using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMD.Particles.Behaviours
{
    [RequireComponent(typeof(TinyMolecularDynamics))]
    public class ParticleBehaviourManager : MonoBehaviour
    {
        private ParticleManager manager;
        private bool isEnabled;
        
        [SerializeField] private ParticleBehaviour prefab;

        private Dictionary<Particle, ParticleBehaviour> particleBehaviourMap
            = new Dictionary<Particle, ParticleBehaviour>();

        public void EnableManager()
        {
            if (isEnabled)
                return;

            var core = GetComponent<TinyMolecularDynamics>();
            manager = core.Manager;
            
            foreach (var particle in manager.Particles)
                OnParticleCreated(this, particle);

            manager.OnParticleCreated += OnParticleCreated;
            manager.OnParticleDestroyed += OnParticleDestroyed;

            isEnabled = true;
        }

        public void DisableManager()
        {
            if (!isEnabled)
                return;

            manager.OnParticleCreated -= OnParticleCreated;
            manager.OnParticleDestroyed -= OnParticleDestroyed;

            foreach (var particle in manager.Particles)
                OnParticleDestroyed(this, particle);

            manager = null;

            isEnabled = false;
        }

        public void UpdateParticlePositions()
        {
            // Update the rendered position of each particle
            foreach (var pair in particleBehaviourMap)
                pair.Value.SetPosition(pair.Key.position);
        }

        private void OnParticleCreated (object sender, Particle particle)
        {
            if (particleBehaviourMap.ContainsKey(particle))
            {
                Debug.Log("Attempting to create a component for a particle that already has a renderer!");
                return;
            }

            ParticleBehaviour instance;
            if (prefab != null)
                instance = Instantiate(prefab);
            else
                instance = new GameObject("Particle").AddComponent<ParticleBehaviour>();

            instance.Particle = particle;
            instance.transform.parent = transform;
            instance.SetPosition(particle.position);

            particleBehaviourMap.Add(particle, instance);
        }

        private void OnParticleDestroyed (object sender, Particle particle)
        {
            if (!particleBehaviourMap.ContainsKey(particle))
            {
                Debug.Log("Attempting to destroy a non-existent particle component");
                return;
            }

            if (Application.isEditor) 
                DestroyImmediate(particleBehaviourMap[particle].gameObject);
            else 
                Destroy(particleBehaviourMap[particle].gameObject);
            
            particleBehaviourMap.Remove(particle);
        }

        private void OnEnable() { EnableManager(); }

        private void OnDisable() { DisableManager(); }

        private void Update() { UpdateParticlePositions(); }
    }
}