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
    private bool wasThrown = false;
    private Vector2 delta = Vector2.zero;
    [SerializeField] private float maxLineLength;
    [SerializeField] private float maxThrowStrength;
    public PantInformation info;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimAction = InputSystem.actions.FindAction("Aim");
        throwAction = InputSystem.actions.FindAction("Throw");
        
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(wasThrown) {return;}
        
        if (holdingThrow)
        {
            if(throwAction.IsPressed())
            {
                lineRenderer.enabled = true;
                Vector2 mousePosition = aimAction.ReadValue<Vector2>();
                
                delta = cam.ScreenToWorldPoint(new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y), 0)) - transform.position;
                
                float lineLength = Mathf.Min(maxLineLength, delta.magnitude);
                float strength = CoolCurve(maxLineLength / lineLength) * maxThrowStrength;
                Vector3 lineDelta = delta.normalized * -lineLength;
                
                delta = delta.normalized * -strength;
                
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + lineDelta);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.linearVelocity = delta;
                lineRenderer.enabled = false;
                wasThrown = true;
            }
        }

        holdingThrow = throwAction.IsPressed();
    }

    float CoolCurve(float x)
    {
        return (x / Mathf.Sqrt(1.0f + x * x)) * 1.4f;
    }
}