using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class clickToMove : MonoBehaviour
{
    public float speed = 5f;
    public static bool mouseCurrentlyOver = false;

    private BoxSelector boxSelectorReference;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    private Vector3 target;
    private bool selected = false;
    private bool recentlyClicked = false;// Prevents the click and move command to happen on the same frame
    private bool walking = false;


    // Start is called before the first frame update
    void Start()
    {
        lineRendererSetup();


        rb = GetComponent<Rigidbody2D>();
        target = transform.position;

        // boxSelectorReference = GameObject.Find("Object Name")  <--- find object by name
        // boxSelectorReference = GameObject.FindWithTag("idName")  <--- find object by ID
        boxSelectorReference = FindAnyObjectByType<BoxSelector>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected && !recentlyClicked)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            walking = true;
            disable();
            boxSelectorReference.setMouseOver(true);
        }

        Vector3 velocity;
        if (walking && ((target - transform.position).magnitude > .1))
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

        rb.velocity = new Vector2(velocity.x, velocity.y);
        recentlyClicked = false;
    }

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.GetComponent<BoxSelector>())
        {
            enable();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxSelector>() && Input.GetMouseButton(0))
        {
            disable();
        }
    }

    private void OnMouseUp()
    {

    }
    private void OnMouseDown()
    {
        boxSelectorReference.setMouseOver(true);
        if (selected == false) { 
            enable(); 
            mouseCurrentlyOver = true; 
        } else { 
            disable(); 
            mouseCurrentlyOver = false; 
        }
        recentlyClicked = true;
        //Delete the box to prevent the BoxSelector from being drawn when you intend to click a single unit
    }

    // Code that runs when the unit is 'selected'
    // We most likely want to put our highlighting code here
    private void enable()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Code that runs when the unit is 'deselected'
    // We most likely want to put our unhighlighting code here
    private void disable()
    {
        selected = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
