using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CubeSpawner : MonoBehaviour
{
    public Color ColorA;
    public Color ColorB;
    public Cube cube;
    // Start is called before the first frame update
    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 vector3 = new Vector3(i, 0, j);
                Cube loxcube = Instantiate(cube, vector3, Quaternion.identity);
                MeshRenderer rend = loxcube.GetComponent<MeshRenderer>();
                if ((i + j) % 2 == 0)
                {
                    rend.material.SetColor("_Color", ColorA);
                }
                else
                {
                    rend.material.SetColor("_Color", ColorB);
                }

            }
        }
    }
}