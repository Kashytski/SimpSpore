using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject cellController;
    Camera cam;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        cam = GetComponent<Camera>();
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * 100);

        //Выделение только тех клеток, которые принадлежат игроку
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "cell")
            {
                var interactComponent = hit.collider.GetComponent<IInteractable>();
                interactComponent.PointsTransfer();
            }
        }

        //Gеремещение очков клеток в указанную клетку
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.GetComponent<Cell_Script>().getPoints = true;
                var interactComponent = cellController.GetComponent<IInteractable>();
                interactComponent.PointsTransfer();
            }
        }

        //Видимость панели меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
        }
    }
}
