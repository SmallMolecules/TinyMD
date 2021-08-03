using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMD.Controllers
{
    using Particles;

    public class ParticleManagerController : MonoBehaviour
    {
        public ParticleManager Manager
        {
            get { return manager; }
            set { SetManager(value); }
        }
        private ParticleManager manager;

        private void SetManager (ParticleManager value)
        {
            manager = value;
        }

        public Particle CreateParticle()
        {
            return manager.CreateParticle();
        }

        public List<Particle> CreateParticles (int numberOfParticles)
        {
            return manager.CreateParticles(numberOfParticles);
        }

        public void DestroyParticle (Particle particle)
        {
            manager.DestroyParticle(particle);
        }

        public void DestroyAllParticles()
        {
            manager.DestroyAllParticles();
        }
    }
}