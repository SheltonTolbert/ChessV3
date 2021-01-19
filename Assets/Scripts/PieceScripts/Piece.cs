using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    bool dragging = false;
    float floatPosition;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && dragging)
        {
            dragObject();
        }

    }

    private void dragObject()
    {
        float lift = 0.25f;
        Vector3 mouse = Input.mousePosition;
        Vector3 position = transform.position;
        //transform.position = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);

        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            position.x = hit.point.x;
            position.z = hit.point.z;
            
            // Move piece up a bit as to not collide with the board
            position.y = floatPosition + lift;
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = position;
        }

    }

    private void OnMouseDown()
    {
        dragging = true;
        floatPosition = transform.position.y;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
