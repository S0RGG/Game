using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public MaximUnit unit;
    // Update is called once per frame
    void Update()
    {
        if (GameStatus.instatnce.status)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var (hit,succ) = RayCast();

            if (succ)
            {
                var cube = hit.transform.GetComponent<Cube>();
                if (cube && cube.unit == null)
                {
                    Vector3 coord = hit.transform.position;
                    cube.unit = Instantiate(unit, coord + new Vector3(0, unit.transform.localScale.y*1.565f + hit.transform.localScale.y / 200, 0), Quaternion.identity);
                    Debug.Log("Spawned");
                }
                else if (cube && cube.unit != null)
                {
                    Debug.Log("Zanyato");
                }
            }
        }
    }

    private (RaycastHit, bool) RayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.gameObject.name);
            return (hit, true);
        }

        return (hit,false);
    }
}
