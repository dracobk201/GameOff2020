using System;
using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    #region Directional buttons
    [Header("Directional Buttons Variables")]
    [SerializeField] private Vector2Reference movementAxis = null;
    [SerializeField] private BoolReference horizontalSinglePress = null;
    [SerializeField] private BoolReference verticalSinglePress = null;
    [SerializeField] private GameEvent nonHorizontalAxisEvent = null;
    [SerializeField] private GameEvent nonVerticalAxisEvent = null;
    [SerializeField] private GameEvent leftButtonEvent = null;
    [SerializeField] private GameEvent rightButtonEvent = null;
    [SerializeField] private GameEvent upButtonEvent = null;
    [SerializeField] private GameEvent downButtonEvent = null;
    [SerializeField] private GameEvent anyDirectionalAxisEvent = null;
    [SerializeField] private GameEvent noDirectionalAxisEvent = null;
    private bool _isHorizontalAxisInUse;
    private bool _isVerticalAxisInUse;


    #endregion

    #region Camera Buttons
    [SerializeField] private Vector2Reference cameraAxis = null;
    [SerializeField] private GameEvent cameraLeftEvent = null;
    [SerializeField] private GameEvent cameraRightEvent = null;
    [SerializeField] private GameEvent cameraUpEvent = null;
    [SerializeField] private GameEvent cameraDownEvent = null;
    [SerializeField] private GameEvent anyCameraAxisEvent = null;
    [SerializeField] private GameEvent noCameraVerticalAxis = null;
    [SerializeField] private GameEvent noCameraHorizontalAxis = null;
    #endregion

    #region Action Buttons
    [Header("Action Buttons Variables")]
    [SerializeField] private GameEvent quitButtonEvent = null;
    [SerializeField] private GameEvent startButtonEvent = null;
    [SerializeField] private GameEvent fireButtonEvent = null;
    [SerializeField] private GameEvent confirmButtonEvent = null;

    private bool _isQuitAxisInUse = false;
    private bool _isStartAxisInUse = false;
    private bool _isFireAxisInUse = false;
    private bool _isConfirmAxisInUse = false;
    #endregion

    [Header("UI Active Variables")]
    [SerializeField] private BoolReference uiPanelActive = null;
    [SerializeField] private GameEvent uiChangeEvent = null;

    private void Update()
    {
        CheckingVerticalAxis();
        CheckingHorizontalAxis();
        CheckingMouseVerticalAxis();
        CheckingMouseHorizontalAxis();
        CheckingStartButton();
        CheckingQuitButton();
        CheckingFireButton();
        CheckingConfirmButton();
        if (Math.Abs(Input.GetAxisRaw(Global.HorizontalAxis)) < Global.Tolerance && Math.Abs(Input.GetAxisRaw(Global.VerticalAxis)) < Global.Tolerance)
            noDirectionalAxisEvent.Raise();
    }

    #region Horizontal Functions

    private void CheckingHorizontalAxis()
    {
        if (Input.GetAxisRaw(Global.HorizontalAxis) < 0 && !_isHorizontalAxisInUse)
            LeftDirectionActions();
        else if (Input.GetAxisRaw(Global.HorizontalAxis) > 0 && !_isHorizontalAxisInUse)
            RightDirectionActions();
        else if (Math.Abs(Input.GetAxisRaw(Global.HorizontalAxis)) < Global.Tolerance)
            NoHorizontalActions();
    }

    private void NoHorizontalActions()
    {
        movementAxis.Value = new Vector2(0, movementAxis.Value.y);
        if (horizontalSinglePress.Value)
            _isHorizontalAxisInUse = false;
        nonHorizontalAxisEvent.Raise();
    }

    private void RightDirectionActions()
    {
        movementAxis.Value = new Vector2(1, movementAxis.Value.y);
        if (horizontalSinglePress.Value)
            _isHorizontalAxisInUse = true;
        rightButtonEvent.Raise();
        anyDirectionalAxisEvent.Raise();
    }

    private void LeftDirectionActions()
    {
        movementAxis.Value = new Vector2(-1, movementAxis.Value.y);
        if (horizontalSinglePress.Value)
            _isHorizontalAxisInUse = true;
        leftButtonEvent.Raise();
        anyDirectionalAxisEvent.Raise();
    }

    #endregion

    #region Vertical Functions
    private void CheckingVerticalAxis()
    {
        if (Input.GetAxisRaw(Global.VerticalAxis) < 0 && !_isVerticalAxisInUse)
            DownDirectionActions();
        else if (Input.GetAxisRaw(Global.VerticalAxis) > 0 && !_isVerticalAxisInUse)
            UpDirectionActions();
        else if (Math.Abs(Input.GetAxisRaw(Global.VerticalAxis)) < Global.Tolerance)
            NoVerticalActions();
    }

    private void NoVerticalActions()
    {
        movementAxis.Value = new Vector2(movementAxis.Value.x, 0);
        if (verticalSinglePress.Value)
            _isVerticalAxisInUse = false;
        nonVerticalAxisEvent.Raise();
    }

    private void UpDirectionActions()
    {
        movementAxis.Value = new Vector2(movementAxis.Value.x, 1);
        if (verticalSinglePress.Value)
            _isVerticalAxisInUse = true;
        upButtonEvent.Raise();
        anyDirectionalAxisEvent.Raise();
    }

    private void DownDirectionActions()
    {
        movementAxis.Value = new Vector2(movementAxis.Value.x, -1);
        if (verticalSinglePress.Value)
            _isVerticalAxisInUse = true;
        downButtonEvent.Raise();
        anyDirectionalAxisEvent.Raise();
    }

    #endregion

    #region Camera Vertical Functions

    private void CheckingMouseVerticalAxis()
    {
        var mouseVerticalValue = Input.GetAxisRaw(Global.MouseVerticalAxis);
        if (mouseVerticalValue < 0)
            DownRotationActions(mouseVerticalValue);
        else if (mouseVerticalValue > 0)
            UpRotationActions(mouseVerticalValue);
        else if (Math.Abs(mouseVerticalValue) < Global.Tolerance)
            NoMouseVerticalActions();
    }

    private void NoMouseVerticalActions()
    {
        cameraAxis.Value = new Vector2(cameraAxis.Value.x, 0);
        noCameraVerticalAxis.Raise();
    }

    private void UpRotationActions(float mouseVerticalValue)
    {
        cameraAxis.Value = new Vector2(cameraAxis.Value.x, mouseVerticalValue);
        cameraUpEvent.Raise();
        anyCameraAxisEvent.Raise();
    }

    private void DownRotationActions(float mouseVerticalValue)
    {
        cameraAxis.Value = new Vector2(cameraAxis.Value.x, mouseVerticalValue);
        cameraDownEvent.Raise();
        anyCameraAxisEvent.Raise();
    }

    #endregion

    #region Camera Horizontal Functions

    private void CheckingMouseHorizontalAxis()
    {
        var mouseHorizontalValue = Input.GetAxisRaw(Global.MouseHorizontalAxis);
        if (mouseHorizontalValue < 0)
            LeftRotationActions(mouseHorizontalValue);
        else if (mouseHorizontalValue > 0)
            RightRotationActions(mouseHorizontalValue);
        else if (Math.Abs(mouseHorizontalValue) < Global.Tolerance)
            NoMouseHorizontalActions();
    }

    private void NoMouseHorizontalActions()
    {
        cameraAxis.Value = new Vector2(0, cameraAxis.Value.y);
        noCameraHorizontalAxis.Raise();
    }

    private void RightRotationActions(float mouseHorizontalValue)
    {
        cameraAxis.Value = new Vector2(mouseHorizontalValue, cameraAxis.Value.y);
        cameraRightEvent.Raise();
        anyCameraAxisEvent.Raise();
    }

    private void LeftRotationActions(float mouseHorizontalValue)
    {
        cameraAxis.Value = new Vector2(mouseHorizontalValue, cameraAxis.Value.y);
        cameraLeftEvent.Raise();
        anyCameraAxisEvent.Raise();
    }

    #endregion

    #region Action Functions

    private void CheckingQuitButton()
    {
        if (Input.GetAxisRaw(Global.QuitAxis) != 0 && !_isQuitAxisInUse)
        {
            quitButtonEvent.Raise();
            _isQuitAxisInUse = true;
        }
        else if (Math.Abs(Input.GetAxisRaw(Global.QuitAxis)) < Global.Tolerance)
            _isQuitAxisInUse = false;
    }

    private void CheckingStartButton()
    {
        if (Input.GetAxisRaw(Global.StartAxis) != 0 && !_isStartAxisInUse)
        {
            startButtonEvent.Raise();
            _isStartAxisInUse = true;
        }
        else if (Math.Abs(Input.GetAxisRaw(Global.StartAxis)) < Global.Tolerance)
            _isStartAxisInUse = false;
    }

    private void CheckingFireButton()
    {
        if (Input.GetAxisRaw(Global.FireAxis) != 0 && !_isFireAxisInUse)
        {
            fireButtonEvent.Raise();
            _isFireAxisInUse = true;
        }
        else if (Math.Abs(Input.GetAxisRaw(Global.FireAxis)) < Global.Tolerance)
            _isFireAxisInUse = false;
    }

    private void CheckingConfirmButton()
    {
        if (Input.GetAxisRaw(Global.JumpAxis) != 0 && !_isConfirmAxisInUse)
        {
            confirmButtonEvent.Raise();
            _isConfirmAxisInUse = true;
        }
        else if (Math.Abs(Input.GetAxisRaw(Global.JumpAxis)) < Global.Tolerance)
            _isConfirmAxisInUse = false;
    }

    #endregion

    #region UI Functions

    private void CheckChangeButtonUi()
    {
        if (uiPanelActive.Value)
            uiChangeEvent.Raise();
    }

    #endregion
}