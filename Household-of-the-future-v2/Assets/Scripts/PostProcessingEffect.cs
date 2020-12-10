using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingEffect : MonoBehaviour
{
    public PostProcessVolume volume;

    private Vignette _Vignette;
    // Start is called before the first frame update
    void Start()
    {
      //  volume.profile.TryGetSettings(out _Vignette);

       // _Vignette.intensity.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // _Vignette.intensity.value = Mathf.Lerp(_Vignette.intensity.value, 1, .055f * Time.deltaTime);
    }
}
