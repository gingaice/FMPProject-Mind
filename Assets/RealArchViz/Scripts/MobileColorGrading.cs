// Color Grading image ffects
// Made by ALIyerEdon
// aliyeredon@gmail.com
// All rights reserved
//    2017   - Unity 5.6 - us compitibale with all unity versions even unity 4 (is not tested)    

using UnityEngine;
using System.Collections;

public enum ToneMapping{
	ACES,None
}

[ExecuteInEditMode]
[ImageEffectAllowedInSceneView]
public class MobileColorGrading : MonoBehaviour {

	[Header("Tone Mapping")]
	// Tonemapping type - ACES Filmic or None
	public ToneMapping toneMapping = ToneMapping.ACES;

	Material material;
	public  Shader shader;

	[Header("Image Settings")]
	[Range(0.3f,1)]
	public float Exposure = 1f;

	[Range(1,2)]
	public float Contrast = 1f;

	[Range(1,0)]
	public float Saturation = 1f;

	[Range(0.3f,1)]
	public float Gamma = 1f;

	[Header("Vignette")]
	[Range(0,0.5f)]
	public float vignetteIntensity = 0.5f;

	[Header("Color Balance")]
	[Range(-100,100)]
	public float R;
	[Range(-100,100)]
	public float G;
	[Range(-100,100)]
	public float B;


	void Awake ()
	{
		shader = Shader.Find ("Hidden/ALIyerEdon/ColorGrading");
		// Create an private material for image effect
		material = new Material(shader);
	}

	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{

		material.SetVector ("_Color", new Vector4(R/200,G/200,B/200,1f));
		material.SetFloat ("_Contrast", Contrast);
		material.SetFloat ("_Gamma", Gamma);
		material.SetFloat ("_Exposure", Exposure);
		material.SetFloat ("_VignetteIntensity",vignetteIntensity);
		material.SetFloat ("_Saturation", Saturation);

		if (Saturation > 0) {
			material.DisableKeyword ("SaturN_OFF");
			material.EnableKeyword ("SaturN_ON");
		} else {
			material.DisableKeyword ("SaturN_ON");
			material.EnableKeyword ("SaturN_OFF");
		}
		
		if (vignetteIntensity != 0) {
			material.DisableKeyword ("Vignette_OFF");
			material.EnableKeyword ("Vignette_ON");
		} else {
			material.DisableKeyword ("Vignette_ON");
			material.EnableKeyword ("Vignette_OFF");
		}

		if (toneMapping == ToneMapping.ACES){
			material.DisableKeyword ("ACES_OFF");
			material.EnableKeyword ("ACES_ON");
		}
		if (toneMapping == ToneMapping.None) {

			material.DisableKeyword ("ACES_ON");
			material.EnableKeyword ("ACES_OFF");
		}
		Graphics.Blit (source, destination, material);

	}

}