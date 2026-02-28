using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowController : MonoBehaviour
{
    
    private InputAction aimAction;
    private LineRenderer lineRenderer;
    private Camera cam;
    [SerializeField] private float maxDistance;
    public PantInformation info;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimAction = InputSystem.actions.FindAction("Aim");
        lineRenderer = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(aimAction?.activeControl?.displayName != null)
        {
            Vector2 mousePosition = aimAction.ReadValue<Vector2>();
            Vector2 target = transform.position - cam.ScreenToWorldPoint(new Vector3(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y), 10));
            target = ClampMagnitude(target);
            float strength = target.magnitude;
            
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target);
        }
    }

    Vector2 ClampMagnitude(Vector2 v)
    {
        float currentMagnitude = v.magnitude;

        if (currentMagnitude > maxDistance)
        {
            float multiplyBy = maxDistance/currentMagnitude;
            return new Vector2(v.x * multiplyBy, v.y * multiplyBy);
        }

        return v;
    }
}