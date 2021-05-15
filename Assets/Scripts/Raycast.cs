using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject cellController;
    Animator anim;
    Camera cam;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        cam = GetComponent<Camera>();
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Touch myTouch;
        
        if (menuPanel.activeInHierarchy == false)
        {        
            try
            {
                myTouch = Input.GetTouch(0);

                //��������� ������ ��� ������, ������� ����������� ������
                if (myTouch.phase == TouchPhase.Moved)
                    if (Physics.Raycast(ray, out hit)
                        && hit.collider.gameObject.tag == "cell")
                    {
                        var interactComponent = hit.collider.GetComponent<IInteractable>();
                        interactComponent.PointsTransfer();
                    }

                //����� ������-���������� � ������ �������� points
                if (myTouch.phase == TouchPhase.Ended)
                    if (Physics.Raycast(ray, out hit)/* &&
                        (hit.collider.gameObject.tag == "one_cell" || hit.collider.gameObject.tag == "other_cell")*/)
                    {
                        hit.collider.GetComponent<Cell_Script>().getPoints = true;
                        var interactComponent = cellController.GetComponent<IInteractable>();
                        interactComponent.PointsTransfer();
                    }
            }
            catch { }

            //������� one_cell �� touch
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "one_cell")
            {
                anim = hit.collider.gameObject.GetComponent<Animator>();
                if (anim.enabled == false)
                {
                    anim.enabled = true;
                    //��������� ������������� ����� Coroutine
                    StartCoroutine(CellScale());
                }
            }
        }
        
        //��������� ������ ����
        if (Input.GetKeyDown(KeyCode.Escape))
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
    }

    IEnumerator CellScale()
    {
        Animator anim1 = anim;
        yield return new WaitForSeconds(0.51f);
        anim1.enabled = false;
    }
}
