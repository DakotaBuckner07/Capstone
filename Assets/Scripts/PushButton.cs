using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    [SerializeField]
    private float threshold = 0.1f;
    [SerializeField]
    private float deadsone = 0.025f;

    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;

    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPressed && GetValue() + threshold >= 1)
        {
            Press();
        }
        if(isPressed && GetValue() - threshold <= 0)
        {
            Release();
        }
    }

    public void Press()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    public void Release()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

    private float GetValue()
    {
        var val = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(val) < deadsone) val = 0;
        return Mathf.Clamp(val, -1, 1);
    }
}
