using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace TinyMD.Particles
{
    public class ParticleManager
    {
        public EventHandler<Particle> OnParticleCreated, OnParticleDestroyed;

        public IReadOnlyCollection<Particle> Particles;
        private List<Particle> particles;

        public IReadOnlyCollection<ParticlePair> Pairs;
        private List<ParticlePair> pairs;

        public ParticleManager()
        {
            particles = new List<Particle>();
            Particles = particles.AsReadOnly();

            pairs = new List<ParticlePair>();
            Pairs = pairs.AsReadOnly();
        }

        public Particle CreateParticle()
        {
            return CreateParticle(1f, Vector3.Zero, Vector3.Zero);
        }

        public Particle CreateParticle (float mass, Vector3 position, Vector3 velocity)
        {
            Particle createdParticle = new Particle()
            {
                mass = mass,
                position = position,
                velocity = velocity
            };
            
            particles.Add(createdParticle);
            UpdatePairs();
            
            OnParticleCreated?.Invoke(this, createdParticle);
            
            return createdParticle;
        }

        public List<Particle> CreateParticles(int numberOfParticles)
        {
            List<Particle> createdParticles = new List<Particle>();

            for (int i = 0; i < numberOfParticles; i++)
            {
                Particle createdParticle = new Particle()
                {
                    mass = 1f,
                    position = Vector3.Zero,
                    velocity = Vector3.Zero
                };

                createdParticles.Add(createdParticle);
            }

            particles.AddRange(createdParticles);
            UpdatePairs();

            foreach (var particle in particles)
                OnParticleCreated?.Invoke(this, particle);

            return createdParticles;
        }

        public void DestroyParticle (Particle particle)
        {
            if (particles.Contains(particle))
            {
                particles.Remove(particle);
                UpdatePairs();
                OnParticleDestroyed?.Invoke(this, particle);
            }
        }

        public void DestroyAllParticles()
        {
            foreach (var particle in particles)
                OnParticleDestroyed?.Invoke(this, particle);

            particles.Clear();
            pairs.Clear();
        }

        private void UpdatePairs()
        {
            // Create all possible combinations of particles
            pairs.Clear();
            for (int i = 0; i < particles.Count - 1; i++)
                for (int j = i + 1; j < particles.Count; j++)
                    pairs.Add(new ParticlePair(particles[i], particles[j]));

            Particles = particles.AsReadOnly();
            Pairs = pairs.AsReadOnly();
        }
    }
}