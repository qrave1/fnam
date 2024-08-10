using TMPro;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private float energy = 100;
    public float dischargeCoff = 1f;
    private float discharge = 1f;

    public GameObject[] segments;
    public TabController tablet;
    public Door leftDoor;
    public Door rightDoor;
    public LightButton leftButton;
    public LightButton rightButton;

    private TextMeshProUGUI battery;

    private void Awake()
    {
        if ( battery == null )
            battery = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("Discharge", 1f, 1f);

    }

    private void Update()
    {
        SetDischarge();
    }

    private void Discharge()
    {
        energy -= discharge;
        battery.text = ((int)energy) + "%";
        if (energy <= 66 && energy > 33)
            battery.color = Color.yellow;
        else if (energy <= 33)
            battery.color = Color.red;
    }

    private void SetDischarge()
    {
        float tabletDC;
        float doorsDC;
        float lightDC;

        // планшет
        if (tablet.minimap.activeSelf)
            tabletDC = 0.1f;
        else
            tabletDC = 0f;


        if (leftDoor.isOpen == false && rightDoor.isOpen == false)
            doorsDC = 0.2f;
        else if (leftDoor.isOpen == false && rightDoor.isOpen == true)
            doorsDC = 0.1f;
        else if (leftDoor.isOpen == true && rightDoor.isOpen == false)
            doorsDC = 0.1f;
        else
            doorsDC = 0f;

        if (leftButton.doorLight.activeSelf == true || rightButton.doorLight.activeSelf == true)
            lightDC = 0.1f;
        else 
            lightDC = 0f;

        discharge = dischargeCoff + tabletDC + doorsDC + lightDC;
    }
}
