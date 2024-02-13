using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class clickToMove : MonoBehaviour
{
    public float speed = 5f;
    
    public Vector3 target;

    private static bool mouseCurrentlyOver = false;
    private bool selected = false;
    private BoxSelector boxSelectorReference;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    private bool recentlyClicked = false;// Prevents the click and move command to happen on the same frame
    private bool walking = false;
    private bool deselectOverride = false;


    // Start is called before the first frame update
    void Start()
    {
        lineRendererSetup();


        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        target = transform.position;

        // boxSelectorReference = GameObject.Find("Object Name")  <--- find object by name
        // boxSelectorReference = GameObject.FindWithTag("idName")  <--- find object by ID
        boxSelectorReference = FindAnyObjectByType<BoxSelector>();

    }

    // Update is called once per frame
    void Update()
    {
        if (selected && Input.GetMouseButtonUp(1) && !recentlyClicked && !boxSelectorReference.currentlyDragging && !mouseOverMoveable())
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            walking = true;
            // disable();
            //boxSelectorReference.setMouseOver(true);
        }
        if (Input.GetMouseButtonUp(0) && !recentlyClicked)
        {
            disable();
        }

        Vector3 velocity;
        if ((walking || deselectOverride) && ((target - transform.position).magnitude > .1))
        {
            velocity = (target - transform.position).normalized * speed;
            drawLine();
        }
        else
        {
            velocity = Vector2.zero;
            walking = false;
            eraseLine();
        }

        if (!selected && !deselectOverride)
        {
            target = transform.position;
        }

        rb.velocity = new Vector2(velocity.x, velocity.y);
        recentlyClicked = false;
    }

    public bool isSelected() {return selected;}
    public void setSelected(bool newVal){selected = newVal;}
    public bool isMouseOver(){ return mouseCurrentlyOver; }

    public bool isDeselectOverriden() { return deselectOverride; }
    public void setDeselectOverride(bool newVal) { deselectOverride = newVal;}

    private void lineRendererSetup()
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
        );

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.transform.parent = transform;
        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0f;
        lineRenderer.colorGradient = gradient;
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.sortingOrder--;
    }
    private void drawLine()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target);
    }
    private void eraseLine()
    {
        lineRenderer.positionCount = 0;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BoxSelector>())
        {
            recentlyClicked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxSelector>())
        {
            recentlyClicked = true;
        }
    }
    */
    private void OnMouseUp()
    {
        recentlyClicked = true;
    }
    private void OnMouseDown()
    {
        boxSelectorReference.setMouseOver(true);
        if (selected == false) { 
            enable(); 
            mouseCurrentlyOver = true; 
        } else if (boxSelectorReference.getAmountSelected() == 1){ 
            disable(); 
            mouseCurrentlyOver = false; 
        }
        recentlyClicked = true;
        boxSelectorReference.deselectAllBut(this);
        //Delete the box to prevent the BoxSelector from being drawn when you intend to click a single unit
    }

    private bool mouseOverMoveable()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit && hit.collider.gameObject.GetComponent<clickToMove>() != null)
        {
            return true;
        }
        return false;
    }

    // Code that runs when the unit is 'selected'
    // We most likely want to put our highlighting code here
    public void enable()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Code that runs when the unit is 'deselected'
    // We most likely want to put our unhighlighting code here
    public void disable()
    {
        selected = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
