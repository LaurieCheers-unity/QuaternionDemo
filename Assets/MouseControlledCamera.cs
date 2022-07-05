using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlledCamera : MonoBehaviour
{
    Vector3 lastMousePosition;
    public GameObject turret;
    public GameObject gun;
    public float lookaheadDistance;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
        transform.localRotation = Quaternion.Euler(0, deltaMouse.x, 0) * transform.localRotation * Quaternion.Euler(-deltaMouse.y, 0, 0);
        lastMousePosition = Input.mousePosition;

        Quaternion idealRotation = Quaternion.LookRotation(transform.position + transform.forward * lookaheadDistance - turret.transform.position);
        Quaternion localIdealRotation = Quaternion.Inverse(turret.transform.parent.rotation) * idealRotation;
        turret.transform.localRotation = Quaternion.Euler(0, localIdealRotation.eulerAngles.y, 0);

        Debug.Log(localIdealRotation.eulerAngles.x);
        gun.transform.localRotation = Quaternion.Euler(Mathf.Clamp(Mathf.DeltaAngle(0, localIdealRotation.eulerAngles.x), -90, 0), 0, 0);
    }
}
