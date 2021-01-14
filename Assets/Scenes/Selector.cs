using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public Unit SelectedUnit = null;
    // Update is called once per frame
    void Update()
    {

        if (GameStatus.instatnce.status)
        {
            if (Input.GetMouseButtonDown(0) && !SelectedUnit)
            {
                var (hit, succ) = RayCast();

                if (succ)
                {
                    var unit = hit.transform.GetComponent<Unit>();
                    if (unit)
                    {
                        SelectedUnit = unit;
                        Vector3 coord = hit.transform.position;
                        //cube.unit = Instantiate(unit, coord + new Vector3(0, unit.transform.localScale.y * 1.565f + hit.transform.localScale.y / 200, 0), Quaternion.identity);
                        if (hit.transform.GetComponentInChildren<MeshRenderer>())
                        {
                            hit.transform.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", Color.cyan);
                        }
                        Debug.Log("Selected");
                    }
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                var (hit, succ) = RayCast();

                if (succ)
                {
                    var cube = hit.transform.GetComponent<Cube>();
                    if (cube && cube.unit == null && cube.GetDistance(SelectedUnit.Cube) <= SelectedUnit.MoveSpeed)
                    {
                        
                        Vector3 coord = hit.transform.position;
                        cube.unit = SelectedUnit;
                        //cube.unit = Instantiate(unit, coord + new Vector3(0, unit.transform.localScale.y * 1.565f + hit.transform.localScale.y / 200, 0), Quaternion.identity);
                        SelectedUnit.transform.position = coord + new Vector3(0, SelectedUnit.transform.localScale.y * SelectedUnit.HeightCal, 0);
                        if (SelectedUnit.transform.GetComponentInChildren<MeshRenderer>())
                        {
                            SelectedUnit.transform.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", Color.white);
                        }
                        SelectedUnit.Cube.unit = null;
                        SelectedUnit.Cube = cube;
                        SelectedUnit = null;
                        Debug.Log("Moved");
                    }
                }
            }

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
                    Unit unit = GameStatus.instatnce.unitpPrefub;
                    Vector3 coord = hit.transform.position;
                    cube.unit = Instantiate(unit, coord + new Vector3(0, unit.transform.localScale.y*unit.HeightCal, 0), Quaternion.identity);
                    cube.unit.Cube = cube;
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
