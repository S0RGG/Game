using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelector : MonoBehaviour
{
    public Dropdown dropdown;
    public MaximUnit MaximUnitPrefub;
    public FootmanUnit FootmanUnitPrefub;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(UnitChange);
    }

    private void UnitChange(int arg0)
    {
        switch (arg0)
        {
            case 0:
                GameStatus.instatnce.unitpPrefub = FootmanUnitPrefub;
                break;
            case 1:
                GameStatus.instatnce.unitpPrefub = MaximUnitPrefub;
                break;
        }
    }
}
