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
        
        Touch myTouch;

        //Выделение только тех клеток, которые принадлежат игроку
        try
        {
            myTouch = Input.GetTouch(0);
            if (myTouch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "cell")
                    {
                        var interactComponent = hit.collider.GetComponent<IInteractable>();
                        interactComponent.PointsTransfer();
                    }
                    else
                    {
                        hit.collider.GetComponent<Cell_Script>().getPoints = true;
                        var interactComponent = cellController.GetComponent<IInteractable>();
                        interactComponent.PointsTransfer();
                    }
                }
            }
        }
        catch { }

        //Видимость панели меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
        }
    }
}
