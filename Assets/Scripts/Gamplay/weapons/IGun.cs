using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    GameObject Bullet { get; set; }
    int Ammo { get; set; }
}
