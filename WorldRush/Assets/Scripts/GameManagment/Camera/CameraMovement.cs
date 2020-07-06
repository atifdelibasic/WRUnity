using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _rotation;
    [SerializeField]
    private float _height;
    private float rotateSpeed = 5;
    [SerializeField]
    private Vector3 offset;
    public Transform pivot;

    void Update()
    {
        //float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        //_target.Rotate(0, horizontal, 0);
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //_target.Rotate(-vertical, 0, 0);
        //transform.position = new Vector3(_target.position.x, _target.position.y + _height, _target.position.z - _distance);
        //transform.rotation = Quaternion.Euler(transform.rotation.x + _rotation, transform.rotation.y, transform.rotation.z);
        //transform.rotation = _target.rotation;
        //float desiredYAngle = _target.eulerAngles.y;
        //float desiredXAngle = _target.eulerAngles.x;
        //Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        //transform.position = _target.position - (rotation * offset);
        transform.position = _target.position - offset;
    }
}
