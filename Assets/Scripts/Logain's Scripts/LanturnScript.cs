using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanturnScript : MonoBehaviour
{

    public Transform Lanturn_Position;
    public ParticleSystem Flame_Effect;
    public Light Point_light;
    private bool Flame_On = false;
    private ParticleSystem flame;
    private Light light;


    void Awake()
    {
        // Defining the Lanturn Posistion's Parent
        GetComponent<LanturnScript>().Lanturn_Position.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (Flame_On == true)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }

        void TurnOn()
        {

            flame = Instantiate(Flame_Effect, Lanturn_Position);
            light = Instantiate(Point_light, Lanturn_Position);
            Debug.Log("a");
            Flame_On = true;
        }

        void TurnOff()
        {
            Destroy(flame);
            Destroy(light);

            Debug.Log("d");
            Flame_On = false;
        }
    }
}
