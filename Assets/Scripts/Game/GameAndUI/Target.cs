using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    private UnityEngine.Camera _camera;
    [SerializeField] private GameObject block;
    private Vector3 _blockRotation;
    private float _angle = 0f;
    private void Awake()
    {
        _camera = UnityEngine.Camera.main;
    }

    private void OnMouseDown()
    {
        _blockRotation = block.transform.rotation.eulerAngles;
        Debug.Log(_blockRotation.y);
    }

    private void OnMouseDrag()
    {
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        var position = block.transform.position;
        
        _angle = Mathf.Atan2(position.x - mousePosition.x, - position.y + mousePosition.y) * Mathf.Rad2Deg;
        
        if (_blockRotation.y == 0)
        {
            Debug.Log("_blockRotation.y == 0");
            block.transform.rotation = Quaternion.Euler(_blockRotation.x, _blockRotation.y,  _angle);
        }

        if (_blockRotation.y == 180)
        {
            Debug.Log("_blockRotation.y == 180");
            block.transform.rotation = Quaternion.Euler(_blockRotation.x, _blockRotation.y,  - _angle);
        }

        

        
    }
}