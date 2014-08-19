using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class TShipController : MonoBehaviour 
{
    public float Thrust = 1.0f;
    public float TorqueThrust = 1.0f;

    public GameObject FXText = null;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(transform.up * Thrust);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddTorque(transform.forward * TorqueThrust);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddTorque(-transform.forward * TorqueThrust);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(null != collision.gameObject.GetComponent<TKiller>())
        {
            GameObject FX = GameObject.Instantiate(FXText) as GameObject;
            FX.guiText.text = "Game Over ! (restarting)";
            Invoke("Reload", 2);
        }
        if (null != collision.gameObject.GetComponent<TObjective>())
        {
            GameObject FX = GameObject.Instantiate(FXText) as GameObject;
            FX.guiText.text = "Success ! (restarting)";
            Invoke("Reload", 2);
        }
    }

    void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
