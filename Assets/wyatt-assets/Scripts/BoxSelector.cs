using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Object = UnityEngine.Object;

public class BoxSelector : MonoBehaviour
{
    public bool currentlyDragging = false;

    private LineRenderer lineRenderer;
    private Vector2 initialMousePosition, currentMousePosition;
    private BoxCollider2D boxCollider;

    private clickToMove[] allMoveables;
    private List<clickToMove> selectedList = new List<clickToMove>();
    private int alreadySelected = 0; //Helper variable for the list

    private int selectedIndex;

    public bool mouseOverMoveable = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        allMoveables = Object.FindObjectsByType<clickToMove>(FindObjectsSortMode.None);

        lineRenderer.positionCount = 0;
        selectedIndex = 0;
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
            Debug.Log("Remove");
            setMouseOver(false);
            removeBox();
        }
        
        // Handle scroll wheel input for selection
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0 && !currentlyDragging)
        {
            UpdateObjectSelection(scrollInput);
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

        float x = Math.Abs(initialMousePosition.x - currentMousePosition.x);
        float y = Math.Abs(initialMousePosition.y - currentMousePosition.y);
        x = x * x;
        y = y * y;
        if (Math.Sqrt(x + y) > 1)
        {
            currentlyDragging = true;
        }
    }
    public void removeBox()
    {
        
        Destroy(boxCollider); 
        boxCollider = null;
        lineRenderer.positionCount = 0;
        transform.position = Vector3.zero;

        if (currentlyDragging == false) return;
        
        selectedList.ForEach(moveable => { moveable.enable(); });
        deselectAllBut(selectedList);

        selectedList.Clear();
        alreadySelected = 0;
        currentlyDragging = false;
    }
    public void deselectAllBut()
    {
        Debug.Log("deselect1");
        foreach (clickToMove moveable in allMoveables)
        {
            moveable.disable();
        }
    }
    public void deselectAllBut(clickToMove ignore)
    {
        Debug.Log("deselect2");
        foreach (clickToMove moveable in allMoveables)
        {
            if(moveable == ignore)
            {
                continue;
            }
            moveable.disable();
        }
    }
    public void deselectAllBut(List<clickToMove> ignore)
    {
        Debug.Log("deselect3");
        foreach (clickToMove moveable in allMoveables)
        {
            if (ignore.Contains(moveable))
            {
                continue;
            }
            moveable.disable();
        }
    }
    public int getAmountSelected()
    {
        int amountSelected = 0;
        foreach (clickToMove moveable in allMoveables)
        {
            if (moveable.isSelected())
            {
                amountSelected++;
            }
        }
        return amountSelected;
    }

    public void setMouseOver(bool val)
    {
        mouseOverMoveable = val;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Col");
        if (collision.gameObject.GetComponent<clickToMove>())
        {
            selectedList.Add(collision.gameObject.GetComponent<clickToMove>());
            if (collision.gameObject.GetComponent<clickToMove>().isSelected())
            {
                alreadySelected++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<clickToMove>() && Input.GetMouseButton(0))
        {
            if (collision.gameObject.GetComponent<clickToMove>().isSelected())
            {
                alreadySelected--;
            }
            selectedList.Remove(collision.gameObject.GetComponent<clickToMove>());
        }
    }

    private void UpdateObjectSelection(float scrollInput)
    {
        int scrollDirection = 0;
        if (scrollInput > 0){
            scrollDirection = 1;
        }
        else if (scrollInput < 0){
            scrollDirection = -1;
        }
        else {
            scrollDirection = 0;
        }
        // Adjust the selected index based on scroll direction
        selectedIndex += scrollDirection;

        // Ensure the selected index stays within bounds
        if (selectedIndex < 0)
        {
            selectedIndex = allMoveables.Length - 1;
        }
        else if (selectedIndex >= allMoveables.Length)
        {
            selectedIndex = 0;
        }

        // Deselect all objects
        deselectAllBut();

        // Select the object at the updated index
        allMoveables[selectedIndex].enable();
    }
}
