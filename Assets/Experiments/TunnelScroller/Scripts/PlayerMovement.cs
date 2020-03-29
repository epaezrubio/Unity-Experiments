using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int sphereSteps = 3;

    private bool rotating = false;
    

    void Update()
    {

        if (!rotating)
        {
            if (Input.GetKey("right"))
            {
                StartCoroutine(RotatePlayer(transform.rotation * Quaternion.Euler(Vector3.forward * 360 / sphereSteps)));
            } else if (Input.GetKey("left"))
            {
                StartCoroutine(RotatePlayer(transform.rotation * Quaternion.Euler(- Vector3.forward * 360 / sphereSteps)));
            }

        }
    }

    private IEnumerator RotatePlayer(Quaternion target)
    {
        rotating = true;

        while (Mathf.Abs(Quaternion.Angle(transform.rotation, target)) > 1)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 20);
            yield return null;
        }

        transform.rotation = target;

        rotating = false;

        yield return null;
    }
}
