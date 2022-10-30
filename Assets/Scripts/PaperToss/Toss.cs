using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Toss : MonoBehaviour
{
    float clickTimeStart, clickTimeFinish, timeInterval;

    [SerializeField]
    float throwForceInXandY = 10f;

    [SerializeField]
    float throwForceInZ = 20f;

    [SerializeField]
    Transform trashPosition;

    private Rigidbody rb;
    private Vector3 initTrashPos;
    private Vector3 initPosition;
    private Vector2 _mouseInitPosition;
    private Vector2 _mouseFinalPosition;
    private Vector2 _mouseInterval;
    private bool _isPressed;
    
    void Awake () {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
        initTrashPos = trashPosition.position;
        Cursor.visible = true;
        SetTrashPosition();
    }
	
    void Update () {
        MoveBallIfSwiped();
    }

    void SetTrashPosition()
    {
        var x = initTrashPos.x;
        var z = initPosition.z;
        var randomX = Random.Range(x - 1.0f, x + 2.0f);
        var randomZ = Random.Range(z - 2.0f, z + 2.0f);
        trashPosition.position = new Vector3(randomX, trashPosition.position.y, randomZ);
    }

    void MoveBallIfSwiped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickTimeStart = Time.time;
            _isPressed = true;
            _mouseInitPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && _isPressed)
        {
            _mouseFinalPosition = Input.mousePosition;
            clickTimeFinish = Time.time;
            timeInterval = clickTimeFinish - clickTimeStart;
            _mouseInterval = (_mouseFinalPosition - _mouseInitPosition) * 0.6f;
            var speedForce = Math.Abs(_mouseInterval.y) * timeInterval * 0.3f;
            var speedDirection = _mouseInterval.x * timeInterval * 1.5f;
            
            rb.isKinematic = false;

            rb.AddForce(speedForce * throwForceInZ, speedForce * throwForceInXandY, -speedDirection);
            rb.useGravity = true;
            Invoke("ReloadBall", 2);
        }

    }

    void ReloadBall()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        transform.position = initPosition;
        rb.velocity = Vector3.zero;
        SetTrashPosition();
    }
} 
