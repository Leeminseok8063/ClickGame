using Assets.Scripts.Manager;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public LayerMask clickActorLayer;
    public Action MouseClicked;
    public GameObject currentClickActor;

    private void Start()
    {
        clickActorLayer += LayerMask.GetMask("Char", "Mob");
    }

    public void OnMouseClicked(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && !UIManager.Instance.isPanel)
        {
            CastingClickPosition();
            MouseClicked?.Invoke();
        }
    } 

    public void CastingClickPosition()
    {
        Vector2 worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldMouse, Vector2.zero, 0f, clickActorLayer);
        if (hit.collider != null)
        {
            currentClickActor = hit.collider.gameObject;
            if (hit.collider.gameObject.TryGetComponent<Character>(out Character charObject))
            {
                if (!GameManager.Instance.charController.beingSetting)
                {
                    GameManager.Instance.charController.SetTargetObject(charObject);
                }
            }
        }
        else
        {
            currentClickActor = null;
        }        
    }
}
