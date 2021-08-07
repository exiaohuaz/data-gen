using System;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Randomizes the material texture of objects tagged with a TextureRandomizerTag
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/New Texture Randomizer")]
    public class NewTextureRandomizer : Randomizer
    {
        static readonly int k_BaseMap = Shader.PropertyToID("_BaseMap");
#if HDRP_PRESENT
        const string k_TutorialHueShaderName = "Shader Graphs/HueShiftOpaque";
        static readonly int k_BaseColorMap = Shader.PropertyToID("_BaseColorMap");
#endif

        /// <summary>
        /// The list of textures to sample and apply to target objects
        /// </summary>
        [Tooltip("The list of textures to sample and apply to target objects.")]
        public MaterialParameter texture;

        /// <summary>
        /// Randomizes the material texture of tagged objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            var tags = tagManager.Query<TextureRandomizerTag>();
            foreach (var tag in tags)
            {
                var renderer = tag.GetComponent<Renderer>();
                // Choose the appropriate shader texture property ID depending on whether the current material is
                // using the default HDRP/lit shader or the Perception tutorial's HueShiftOpaque shader
                renderer.material = texture.Sample();
            }
        }
    }
}