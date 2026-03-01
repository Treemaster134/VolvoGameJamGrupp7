using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowController : MonoBehaviour
{
    
    private InputAction aimAction;
    private InputAction throwAction;
    private InputAction grabAction;
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    private Camera cam;
    private Animator animator;
    private bool holdingThrow = false;
    private bool holdingPant = false;
    private Vector2 delta = Vector2.zero;
    private Vector2 mouseStartPosition = Vector2.zero;
    [SerializeField] private float maxLineLength;
    [SerializeField] private float maxThrowStrength;
    [SerializeField] private Transform BeltLocation;
    [SerializeField] private Transform HandTransform;
    [SerializeField] private LayerMask mask;
    private GameObject pant;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimAction = InputSystem.actions.FindAction("Aim");
        throwAction = InputSystem.actions.FindAction("Throw");
        grabAction = InputSystem.actions.FindAction("Grab");
        
        lineRenderer = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!holdingPant)
        {
            Collider2D c = Physics2D.OverlapBox(BeltLocation.position, Vector3.one, 0, mask);

            if (c && grabAction.IsPressed())
            {
                pant = c.gameObject;
                pant.transform.parent = HandTransform;
                pant.transform.localPosition = Vector3.zero;
                holdingPant = true;
                animator.SetBool("Hold", true);
            }
            else
            {
                return;
            }
            
        }
        
        if (holdingThrow)
        {
            if(throwAction.IsPressed())
            {
                lineRenderer.enabled = true;
                Vector2 mousePosition = aimAction.ReadValue<Vector2>();
                
                delta = cam.ScreenToWorldPoint(new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y), 0)) - (Vector3)mouseStartPosition;
                
                float lineLength = Mathf.Min(maxLineLength, delta.magnitude);
                float strength = CoolCurve(lineLength / maxLineLength) * maxThrowStrength;
                Vector3 lineDelta = delta.normalized * -lineLength;
                
                delta = delta.normalized * -strength;
                
                lineRenderer.SetPosition(0, HandTransform.position);
                lineRenderer.SetPosition(1, HandTransform.position + lineDelta);

                if ((lineLength / maxLineLength) < 0.5f)
                {
                    lineRenderer.endColor = Color.Lerp(Color.red, Color.yellow, (lineLength / maxLineLength) * 2.0f);
                }
                else
                {
                    lineRenderer.endColor = Color.Lerp(Color.yellow, Color.green, (lineLength / maxLineLength - 0.5f) * 2.0f);
                }
                
            }
            else
            {
                animator.SetBool("Hold", false);
                animator.SetBool("Throw", true);
                lineRenderer.enabled = false;
            }
        }
        else
        {
            if (throwAction.IsPressed())
            {
                mouseStartPosition = cam.ScreenToWorldPoint(new Vector3(Mathf.Round(aimAction.ReadValue<Vector2>().x),
                    Mathf.Round(aimAction.ReadValue<Vector2>().y), 0));
            }
        }

        holdingThrow = throwAction.IsPressed();
    }

    float CoolCurve(float x)
    {
        return (x / Mathf.Sqrt(1.0f + x * x)) * 1.4f;
    }

    public void Throw()
    {
        Rigidbody2D rb = pant.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.linearVelocity = delta;
        pant.transform.parent.DetachChildren();
        holdingPant = false;
        animator.SetBool("Hold", false);
        animator.SetBool("Throw", false);
    }
}