using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace TinyMD.Tests
{
    using Particles;

    public class ParticleTests
    {
        [Test]
        public void ParticleShouldBeAbleToBeReferencedAfterCreation()
        {
            ParticleManager manager = new ParticleManager();
            Particle particle = manager.CreateParticle(1f, Vector3.Zero, Vector3.Zero);
            bool canBeReferenced = manager.Particles.Contains(particle);
            Assert.IsTrue(canBeReferenced);
        }

        [Test]
        public void CreatingFourParticlesShouldResultInSixPairs()
        {
            ParticleManager manager = new ParticleManager();
            manager.CreateParticles(4);

            int numberOfPairs = manager.Pairs.Count;
            Assert.AreEqual(6, numberOfPairs);
        }

        [Test]
        public void CreatingAndDestroyingThreeParticlesShouldResultInZeroParticles()
        {
            ParticleManager manager = new ParticleManager();
            List<Particle> particles = manager.CreateParticles(3);

            foreach (var particle in particles)
                manager.DestroyParticle(particle);

            int numberOfParticles = manager.Particles.Count;
            int numberOfPairs = manager.Pairs.Count;

            Assert.AreEqual(0, numberOfParticles);
            Assert.AreEqual(0, numberOfPairs);
        }
    }
}