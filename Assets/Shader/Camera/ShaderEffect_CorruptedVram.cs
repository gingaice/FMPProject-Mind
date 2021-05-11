using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect_CorruptedVram : MonoBehaviour 
{

	public float shiftCam = -0.36f;
	private Texture texture;
	private Material material;

	public float _increaseAmount = 0.5f;
	//public float increaser = 1;

	
	void Awake()
	{
		material = new Material( Shader.Find("Hidden/Distortion") );
		texture = Resources.Load<Texture>("Checkerboard-big");
	}
	

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_ValueX", shiftCam);
		material.SetTexture("_Texture", texture);
	    Graphics.Blit (source, destination, material);
		
	}

	void Update()
    {

		if(TutFOVDetection.checker == true)
        {
			shiftCam += Time.deltaTime * _increaseAmount;
		}
        else
        {
			shiftCam -= Time.deltaTime * _increaseAmount;
        }

		if(shiftCam <= -0.36f)
        {
			shiftCam = -0.36f;
        }

		//material = new Material(Shader.Find("Hidden/Distortion"));
		//texture = Resources.Load<Texture>("Checkerboard-big");

	}
}
