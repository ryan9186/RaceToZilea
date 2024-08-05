using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{

    /*CamerageDrag provides functionality to the camerage to pan around the game scene
     * during gameplay using right click + mouse drag
     */

    #region Variables

    private Vector3 origin;
    private Vector3 difference;

    private Camera mainCamera;

    private bool isDragging;

    #endregion

    private void Awake()
    {
        mainCamera = Camera.main;
        Debug.Log("Awake");
    }


    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) origin = GetMousePosition;
        isDragging = ctx.started || ctx.performed;

    }

    public void LateUpdate()
    {
        if (!isDragging) return;

        difference = GetMousePosition - transform.position;
        transform.position = origin - difference;
        Debug.Log("LateUpdate");
    }

    private Vector3 GetMousePosition => mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}