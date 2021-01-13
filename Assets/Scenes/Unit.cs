﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IUnit
{
    public int HitPoints { get; set; }
    public Cube Cube { get; set; } = null;
}