using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Color[] Colors = new[] { Color.black, Color.blue, Color.green, Color.red, Color.yellow, Color.white };
    public GameObject HexPrefab = null;
    public int N = 55;
    public float Radius = 1f;
    public float Density = 0.06f;
    public float Elevation = 2f;

    void Start()
    {
        var t = Mathf.Sqrt(3 / 4f) * Radius;

        for (int i = 0; i < N / 3; i++)
            for (int j = 0; j < N; j++)
            {
                Vector3 pos;

                if (j % 2 == 0)
                {
                    pos = new Vector3(j * t, 0, i * Radius * 3);
                }
                else
                {
                    pos = new Vector3(j * t, 0, i * Radius * 3 + Radius * 3f / 2f);
                }

                pos.y = Mathf.PerlinNoise(pos.x * Density, pos.z * Density) * Elevation;

                var go = Instantiate(
                    HexPrefab,
                    pos,
                    HexPrefab.transform.rotation);

                go.GetComponent<MeshRenderer>().material.color = Colors[(i * N + j) % Colors.Length];

                // * Quaternion.AngleAxis(360f * (i / N / 3 + j / N) + 360f * Mathf.Sin(0.001f * Mathf.PI * (i / N / 3 + j / N)), Vector3.right)
            }
    }
}
