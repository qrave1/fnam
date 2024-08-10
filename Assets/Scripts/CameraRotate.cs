using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject screamer;
    public float sensivity = 150f;
    float rotateZone = Screen.width / 5;
    public TabController tabController;


    void Update()
    {
        if (screamer.activeSelf == true)
        {
            return;
        }
        if (Input.mousePosition.x < rotateZone && transform.rotation.eulerAngles.y > 30) 
        {
            transform.Rotate(0, -sensivity * Time.deltaTime, 0);
        }
        if (Input.mousePosition.x > Screen.width - rotateZone && transform.rotation.eulerAngles.y < 150)
        {
            transform.Rotate(0, sensivity * Time.deltaTime, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
            tabController.tabChangeVisible();
        }
    }
}
