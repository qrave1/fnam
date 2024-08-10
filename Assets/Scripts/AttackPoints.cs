using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoints : NextPoints
{
    public Door door;
    public bool isOpen;

    private void Update()
    {
        isOpen = door.isOpen;
    }
}
