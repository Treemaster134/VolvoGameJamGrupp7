using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowController : MonoBehaviour
{
    
    private InputAction aimAction;
    private InputAction throwAction;
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    private Camera cam;
    private bool holdingThrow = false;
    [SerializeField] private float maxDistance;
    public PantInformation info;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimAction = InputSystem.actions.FindAction("Aim");
        throwAction = InputSystem.actions.FindAction("Throw");
        
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingThrow)
        {
            Vector3 delta = Vector3.zero;
            if(throwAction.IsPressed())
            {
                Vector2 mousePosition = aimAction.ReadValue<Vector2>();
                delta = cam.ScreenToWorldPoint(new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y), 0)) - transform.position;
                float strength = Mathf.Min(maxDistance, delta.magnitude);
            
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position - delta.normalized * strength);
            }
            else
            {
                rb.simulated = true;
                rb.linearVelocity = delta;
            }
        }

        holdingThrow = throwAction.IsPressed();
    }
}