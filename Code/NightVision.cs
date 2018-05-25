
using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(AudioSource))]
public class NightVision : MonoBehaviour
{

    public Light NightVisionLight;

    private FpsController fps;


    [HideInInspector]
    private bool soundplayed = false, ligouCam;
    ColorCorrectionCurves NightVisionEffect;

    private void Start()
    {
        fps = FindObjectOfType(typeof(FpsController)) as FpsController;
        NightVisionEffect = this.GetComponent<ColorCorrectionCurves>();
    }

    void Update()
    {
        
        if (fps.ligarCamera)
        {
            ligouCam = false;
            NightVisionEffect.enabled = true;
            NightVisionLight.enabled = true;
            
        } else if(!ligouCam) {
            NightVisionEffect.enabled = false;
            NightVisionLight.enabled = false;
            
        }
        
    }
}
