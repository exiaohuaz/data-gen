using System;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags;
using UnityEngine.Perception.Randomization.Samplers;
using UnityEngine;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Randomizes the rotation of objects tagged with a RotationRandomizerTag
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Object Randomizer")]
    public class ObjectRandomizer : Randomizer
    {
        [Tooltip("Prefab to randomize")]
        public GameObject[] prefabs;
        public UniformSampler index = new UniformSampler(0, 15);

        [Tooltip("The width and height of the area in which objects will be placed. These should be positive numbers and sufficiently large in relation with the Separation Distance specified.")]
        public Vector2Parameter placementArea;
        


        /// <summary>
        /// The range of random rotations to assign to target objects
        /// </summary>
        [Tooltip("The range of random rotations to assign to target objects.")]
        /*public Vector3Parameter rotation = new Vector3Parameter
        {
            x = new UniformSampler(0, 360),
            y = new UniformSampler(0, 360),
            z = new UniformSampler(0, 360)
        };*/
        private UniformSampler rotation = new UniformSampler(0, 360);

        //private Rigidbody rb;
        private GameObject prefab;

        /// <summary>
        /// Randomizes the rotation of tagged objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            prefab = prefabs[(int)index.Sample()];
            //rb = prefab.GetComponent<Rigidbody>();
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            Vector2 position = placementArea.Sample();
            prefab = GameObject.Instantiate(prefab);
            prefab.transform.position = new Vector3(position.x, 0, position.y);
            prefab.transform.rotation = Quaternion.Euler(new Vector3(0, rotation.Sample(), 0));
            //prefab.transform.rotation = Quaternion.Euler(rotation.Sample());
        }

        protected override void OnIterationEnd()
        {
            GameObject.Destroy(prefab);
        }

    }
}