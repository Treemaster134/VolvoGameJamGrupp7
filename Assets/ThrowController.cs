using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowController : MonoBehaviour
{
    
    private InputAction aimAction;
    private LineRenderer lineRenderer;
    private Camera cam;
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
            Vector2 aimDelta = aimAction.ReadValue<Vector2>();
            Vector2 target = transform.position - cam.ScreenToWorldPoint(new Vector3(Mathf.Round(aimDelta.x), Mathf.Round(aimDelta.y), 10));
            
            
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target);
        }
    }
}
