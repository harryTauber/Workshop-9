using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    [SerializeField] private Vector3 forward = Vector3.forward;
   
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        //Quaternion rotation = Quaternion.LookRotation(forward, Vector3.up);
        //transform.rotation = rotation;
    }

    public void SetLookDirection(Vector3 forward) {
        this.forward = forward;
    }
}
