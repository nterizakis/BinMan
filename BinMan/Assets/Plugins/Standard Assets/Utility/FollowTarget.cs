using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(2.5f, 2.72f, 7.83f);


        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
