using UnityEngine;

public class Cube : MonoBehaviour
{
    public Unit unit = null;
    public Vector3Int price = Vector3Int.zero;
    
    public void clicked()
    {
        Debug.Log("Sike");
    }

    public int GetDistance(Cube otherCube)
    {
        return (
            Mathf.Abs(price.x - otherCube.price.x) +
            Mathf.Abs(price.y - otherCube.price.y) +
            Mathf.Abs(price.z - otherCube.price.z)
            ) / 2;
    }
}
