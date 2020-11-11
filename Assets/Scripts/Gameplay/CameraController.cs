using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2Reference mouseAxis = null;
    [SerializeField] private FloatReference minCameraRotation = null;
    [SerializeField] private FloatReference maxCameraRotation = null;
    [SerializeField] private FloatReference horizontalCameraSensitivity = null;
    [SerializeField] private FloatReference verticalCameraSensitivity = null;
    private GameObject _playerCamera;
    private Transform _playerTransform;
    private float rotAroundY;

    private void Start()
    {
        _playerTransform = transform;
        _playerCamera = Camera.main.gameObject;
        rotAroundY = transform.eulerAngles.y;
    }

    public void RotateCamera()
    {
        rotAroundY += mouseAxis.Value.y * verticalCameraSensitivity.Value * Time.deltaTime;
        CameraRotation();
    }

    private void CameraRotation()
    {
        _playerTransform.rotation = Quaternion.Euler(0, rotAroundY, 0);
        _playerCamera.transform.rotation = Quaternion.Euler(0, rotAroundY, 0);
    }
}