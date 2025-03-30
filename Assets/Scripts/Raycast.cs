using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject cellManager;
    private GameObject menuPanel => Cell_Controller.Instance.MenuPanel.gameObject;
    private Animator anim;
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        cellManager = gameObject;
        cam = GetComponent<Camera>();
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (!menuPanel.activeInHierarchy)
        {
            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.GetTouch(0);

                if (myTouch.phase == TouchPhase.Moved)
                {
                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("cell"))
                    {
                        IInteractable cell = hit.collider.GetComponent<IInteractable>();
                        cell.PointsTransfer();
                    }
                }

                if (myTouch.phase == TouchPhase.Ended)
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        hit.collider.GetComponent<Cell_Script>().getPoints = true;
                        IInteractable cell = cellManager.GetComponent<IInteractable>();
                        cell.PointsTransfer();
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("cell"))
                    {
                        IInteractable cell = hit.collider.GetComponent<IInteractable>();
                        cell.PointsTransfer();
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        hit.collider.GetComponent<Cell_Script>().getPoints = true;
                        IInteractable cell = cellManager.GetComponent<IInteractable>();
                        cell.PointsTransfer();
                    }
                }
            }

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("one_cell"))
            {
                anim = hit.collider.gameObject.GetComponent<Animator>();

                if (anim != null && !anim.enabled)
                {
                    anim.enabled = true;
                    StartCoroutine(CellScale());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }


    IEnumerator CellScale()
    {
        Animator pulse = anim;
        yield return new WaitForSeconds(0.51f);
        pulse.enabled = false;
    }
}