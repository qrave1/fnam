using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButton : MonoBehaviour
{
    public GameObject doorLight;
    public float buttonMoveVar = -0.03f;
    Vector3 position;

    private void Awake()
    {
        position = transform.localPosition;
    }

    private void OnMouseDown()
    {
        transform.localPosition = position - transform.forward * buttonMoveVar;
        doorLight.SetActive(false);
    }

    private void OnMouseUp()
    {
        transform.localPosition = position;
        doorLight.SetActive(true);
    }
}
