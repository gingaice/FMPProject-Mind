using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect_CorruptedVram : MonoBehaviour 
{

	public float shiftCam = 1;
	private Texture texture;
	private Material material;

	public float _increaseAmount = 1;
	public float increaser = 1;

	
	void Awake ()
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

	void update()
    {
		TutSanityStuff.shift = shiftCam;
    }
}
