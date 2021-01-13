using UnityEngine;

public class DistanceMeasurer : MonoBehaviour
{
	public Cube CubeA;
	public Cube CubeB;

	public float Distance = 0f;

	public void Update()
	{
		if (CubeA && CubeB)
			Distance = CubeB.GetDistance(CubeA);
	}
}
