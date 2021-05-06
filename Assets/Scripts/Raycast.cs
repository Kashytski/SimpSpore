using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    Camera cam;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        cam = GetComponent<Camera>();
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * 100);

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
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.GetComponent<Cell_Script>().getPoints = true;
                var interactComponent = gameObject.GetComponent<IInteractable>();
                interactComponent.PointsTransfer();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
        }
    }
}
