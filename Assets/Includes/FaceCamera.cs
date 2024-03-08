using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
        [Serializable]
        private struct BoolVector3
        {
            public bool x;
            public bool y;
            public bool z;
        }

        [SerializeField] private BoolVector3 _freeAxis;

        [Header("Facing chars")]
        [SerializeField] private Vector3 _worldPosVector = Vector3.back;
        [SerializeField] private Vector3 _worldUpVector = Vector3.up;
    
        void Update()
        {
            if (Camera.main == null)
                return;

            Vector3 oldRotation = transform.localEulerAngles;
            transform.LookAt(transform.position + Camera.main.transform.rotation * _worldPosVector, Camera.main.transform.rotation * _worldUpVector);
            Vector3 endRotation = transform.localEulerAngles;

            endRotation.x = _freeAxis.x ? endRotation.x : oldRotation.x;
            endRotation.y = _freeAxis.y ? endRotation.y : oldRotation.y;
            endRotation.z = _freeAxis.z ? endRotation.z : oldRotation.z;

            transform.localEulerAngles = endRotation;
        }
}
