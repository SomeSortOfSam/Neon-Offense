using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    int damage { get; }
    bool friendly { get; }
}