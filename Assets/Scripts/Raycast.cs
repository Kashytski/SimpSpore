using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Camera cam;

    void Update()
    {
        cam = GetComponent<Camera>();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * 100);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "cell")
            {
                var interactComponent = hit.collider.GetComponent<IInteractable>();
                interactComponent.PointsTransfer();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "cell")
            {
                hit.collider.GetComponent<Cell_Script>().getPoints = true;

                var interactComponent = gameObject.GetComponent<IInteractable>();
                interactComponent.PointsTransfer();
            }
        }
    }
}
