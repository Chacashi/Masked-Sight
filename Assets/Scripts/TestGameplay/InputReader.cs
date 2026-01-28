using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, MainInput.IPlayerActions, MainInput.IUIActions

{
    public event Action<float> MovementEvent;
    public event Action JumpEvent;
    public event Action InteractEvent;
    public event Action PauseEvent;
    public event Action ResumeEvent;
    public event Action ChanguePortalEvent;

    private MainInput gameInput;



    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new MainInput();
            gameInput.Player.SetCallbacks(this);
            gameInput.UI.SetCallbacks(this);
            gameInput.Player.Enable();
        }

    }


    private void OnDisable()
    {
        if (gameInput != null)
        {
            gameInput.Player.Disable();
            gameInput.UI.Disable();
        }

    }

    public void SetGameplay()
    {
        gameInput.UI.Disable();
        gameInput.Player.Enable();

    }

    public void SetUI()
    {
        gameInput.Player.Disable();
        gameInput.UI.Enable();

    }
    #region PlayerActions
    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementEvent?.Invoke(context.ReadValue<float>());

    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            InteractEvent?.Invoke();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            JumpEvent?.Invoke();
    }

    public void OnChanguePortal(InputAction.CallbackContext context)
    {
        if(context.performed)
            ChanguePortalEvent?.Invoke();
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseEvent?.Invoke();
            SetUI();
        }

    }

    #endregion

    #region UIActions
    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ResumeEvent?.Invoke();
            SetGameplay();
        }

    }

    #endregion


}
