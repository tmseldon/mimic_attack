using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Game.FX
{
    [RequireComponent(typeof(PostProcessVolume))]
    public class ChangePostFX : MonoBehaviour
    {
        PostProcessVolume postProcessing;
        Grain grainFX;

        void Start()
        {
            postProcessing = GetComponent<PostProcessVolume>();
            ChangeStateGrainFX(false);
        }

        public void ChangeStateGrainFX(bool estado)
        {
            postProcessing.profile.TryGetSettings(out grainFX);
            grainFX.enabled.value = estado;
        }
    }
}