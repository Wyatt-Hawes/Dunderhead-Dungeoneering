using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelector : MonoBehaviour
{   
    private LineRenderer lineRenderer;
    private Vector2 initialMousePosition, currentMousePosition;
    private BoxCollider2D boxCollider;
    public bool mouseOverMoveable = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !mouseOverMoveable) {
            initializeBox();
        }

        // Draw rectangle while mouse is held
        if(Input.GetMouseButton(0) && !mouseOverMoveable)
        {
            updateBox();
        }

        if(Input.GetMouseButtonUp (0))
        {
            setMouseOver(false);
            removeBox();
        }
    }
    private void initializeBox()
    {
        lineRenderer.positionCount = 4;
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
        lineRenderer.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
        lineRenderer.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
        lineRenderer.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));


        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        boxCollider.offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void updateBox()
    {
        currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lineRenderer.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
        lineRenderer.SetPosition(1, new Vector2(initialMousePosition.x, currentMousePosition.y));
        lineRenderer.SetPosition(2, new Vector2(currentMousePosition.x, currentMousePosition.y));
        lineRenderer.SetPosition(3, new Vector2(currentMousePosition.x, initialMousePosition.y));

        transform.position = (currentMousePosition + initialMousePosition) / 2;

        boxCollider.size = new Vector2(Mathf.Abs(initialMousePosition.x - currentMousePosition.x),
                                        Mathf.Abs(initialMousePosition.y - currentMousePosition.y));
    }
    public void removeBox()
    {
        lineRenderer.positionCount = 0;
        Destroy(boxCollider); boxCollider = null;
        transform.position = Vector3.zero;
    }
    public void setMouseOver(bool val)
    {
        mouseOverMoveable = val;
    }
}
