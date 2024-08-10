using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Door door;
    public float buttonMoveVar = -0.03f;
    Vector3 position;

    private void Awake()
    {
        position = transform.localPosition;
    }

    private void OnMouseDown()
    {
        transform.localPosition = position - transform.forward * buttonMoveVar;
        door.ButtonPressed();
        Invoke("MouseUp", 0.1f);
    }

    void MouseUp()
    {
        transform.localPosition = position;
    }
}
