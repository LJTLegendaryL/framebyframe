using UnityEngine;

public class MouseDragging : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask interactableMask;

    public Transform selectedObject;
    bool selectableObjectInRange;
    Vector2 mousePoint;

    public AudioSource ding;
    public AudioSource click;


    void Update()
    {
        CalculateMousePosition();

        if (selectedObject != null)
            selectedObject.position = Vector3.Lerp(selectedObject.position, mousePoint, 10 * Time.deltaTime);
    }

    private void getAudio()
    {
        DontDestroyOnLoad(transform.gameObject);
        ding = GetComponent<AudioSource>();
        click = GetComponent<AudioSource>();

    }

    void CalculateMousePosition()
    {
        mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData2D = Physics2D.Raycast(mousePoint, Vector2.zero, Mathf.Infinity, interactableMask);

        if (selectedObject == null)
        {
            if (Input.GetMouseButtonDown(0) && hitData2D.transform != null)
            {
                selectedObject = hitData2D.transform;
                click.Play();
            }


        }
        else
            if (Input.GetMouseButtonDown(0))
        {
            selectedObject = null;
            click.Play();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, mousePoint);
    }
}