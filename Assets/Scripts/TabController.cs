using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UIElements;

public class TabController : MonoBehaviour
{
    public GameObject Tablet;
    public Animator anim;
    public int AnimDelay = 500;
    public GameObject minimap;
    public GameObject[] cameras;
    public GameObject mainCamera;
    private int currentCameraIndex = 0;

    private void Awake()
    {
        anim = Tablet.GetComponent<Animator>();
    }

    public void tabChangeVisible()
    {
        if (minimap.activeSelf)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
    async void Open()
    {
        Tablet.SetActive(true);
        anim.SetBool("isOpen", true);
        await Task.Delay(AnimDelay);
        minimap.SetActive(true);
        mainCamera.SetActive(false);
        cameras[currentCameraIndex].SetActive(true);
    }


    async public void Close()
    {
        cameras[currentCameraIndex].SetActive(false);
        mainCamera.SetActive(true);
        minimap.SetActive(false);
        anim.SetBool("isOpen", false);
        await Task.Delay(AnimDelay);
        Tablet.SetActive(false);
    }

    public void ChangeCamera(int index)
    {
        cameras[currentCameraIndex].SetActive(false);
        currentCameraIndex = index;
        cameras[currentCameraIndex].SetActive(true);
    }
}