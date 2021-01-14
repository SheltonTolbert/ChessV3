using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButton(0) && dragging)
        {
            dragObject();
        }

    }

    void dragObject()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 position = transform.position;
        //transform.position = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);

        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            position.x = hit.point.x;
            position.z = hit.point.z;
            transform.position = position;
        }

    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
