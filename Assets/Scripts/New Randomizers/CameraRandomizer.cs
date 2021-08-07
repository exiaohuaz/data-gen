using System;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags;
using UnityEngine.Perception.Randomization.Samplers;
using UnityEngine;
using System.Collections;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Randomizes the rotation of objects tagged with a RotationRandomizerTag
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Camera Randomizer")]
    public class CameraRandomizer : Randomizer
    {
        [Tooltip("Prefab to randomize")]
        public GameObject prefab;

        [Tooltip("Distance of camera from object")]
        public float distance;

        public UniformSampler angle_min_max = new UniformSampler(0, 90);
        public UniformSampler tilt_min_max = new UniformSampler(-90, 90);

        /// <summary>
        /// Randomizes the rotation of tagged objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            float degrees = angle_min_max.Sample();
            float radians = degrees * Mathf.PI / 180;
            float tilt = tilt_min_max.Sample();
            
            prefab.transform.position = new Vector3(0, Mathf.Sin(radians) * distance, -Mathf.Cos(radians) * distance);
            prefab.transform.rotation = Quaternion.Euler(degrees, 0, tilt);

        }
    }
}