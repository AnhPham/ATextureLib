using UnityEngine;
using System.Collections;

public class TextureLoader
{
	public static void MakeNewTexture(GameObject go, string resPath)
	{
		// SET MATERIAL
		Material matRes = Resources.Load("Materials/UnlitAlpha") as Material;
		go.AddComponent<MeshRenderer>();
		go.renderer.material = matRes;

		// SET TEXTURES
		Texture texRes = Resources.Load(resPath) as Texture;
		go.renderer.material.mainTexture = texRes;

		// SET MESH FILTER
		go.AddComponent<MeshFilter>();
		Mesh mesh = go.GetComponent<MeshFilter>().mesh;
		mesh.Clear();

		// CREATE NEW MESH && UV
		Vector2[] vertices2D;
		vertices2D = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0) };

		int[] triangles = new int[6] { 0, 1, 2, 0, 2, 3 };

		Vector3[] vertices3D = new Vector3[vertices2D.Length];
		for (int i = 0; i < vertices3D.Length; i++)
		{
			vertices3D[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
		}

		mesh.vertices = vertices3D;
		mesh.uv = vertices2D;
		mesh.triangles = triangles;
		
		go.transform.localScale = new Vector3(texRes.width, texRes.height, 1);
		go.transform.localPosition = new Vector3(-texRes.width / 2, -texRes.height / 2, 0);
	}
}
