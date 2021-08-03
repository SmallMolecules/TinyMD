using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMD
{
    using Particles;

    /// <summary>
    /// Anchor point and bootloader for classes without monobehaviours.
    /// </summary>

    public class TinyMolecularDynamics : MonoBehaviour
    {
        public ParticleManager Manager => manager;
        private ParticleManager manager;

        public bool IsActive => isActive;
        private bool isActive;

        public static TinyMolecularDynamics CreateEnvironment()
        {
            var obj = new GameObject("Tiny Molecular Dynamics");
            var env = obj.AddComponent<TinyMolecularDynamics>();
            return env.StartEnvironment();
        }

        private void Awake()
        {
            if (!isActive)
                StartEnvironment();
        }

        private void OnDestroy()
        {
            if (isActive)
                StopEnvironment();
        }

        public TinyMolecularDynamics StartEnvironment()
        {
            manager = new ParticleManager();
            
            isActive = true;
            return this;
        }

        public TinyMolecularDynamics StopEnvironment()
        {
            manager.DestroyAllParticles();
            manager = null;

            isActive = false;
            return this;
        }
    }
}