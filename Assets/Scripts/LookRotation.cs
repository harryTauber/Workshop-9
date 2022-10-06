using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    [SerializeField] private Vector3 _forward;
    private Vector3 Forward
    {
        get => this._forward;
        set {
            this._forward = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(forward, Vector3.up);
        transform.rotation = rotation;
    }
}
