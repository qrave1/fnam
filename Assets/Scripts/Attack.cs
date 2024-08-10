using System.Runtime.CompilerServices;
using UnityEngine;
using System.Threading;

public class Attack : MonoBehaviour
{
    public GameObject screamer;
    public GameObject tab;
    public GameObject UI;
    TabController cameras;
    Animator anim;


    private void Awake()
    {
        anim = screamer.GetComponent<Animator>();
        cameras = UI.GetComponent<TabController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"collide with {other.tag}");
        if (other.tag == "Player")
        {
            Invoke("End", 1f);
            cameras.Close();
            //Destroy(tab);
            //Destroy(UI);
            gameObject.SetActive(false);
            screamer.SetActive(true);
            anim.SetBool("Scream", true);
        }
    }

    public void End()
    {
        Application.Quit();
    }
}
