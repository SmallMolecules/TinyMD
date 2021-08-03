using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TinyMD.Controllers.Editors
{
    [CustomEditor(typeof(ParticleManagerController))]
    public class ParticleManagerControllerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var controller = target as ParticleManagerController;

            if (GUILayout.Button("Create Particle"))
                controller.CreateParticle();

            if (GUILayout.Button("Destroy All Particles"))
                controller.DestroyAllParticles();
        }
    }
}