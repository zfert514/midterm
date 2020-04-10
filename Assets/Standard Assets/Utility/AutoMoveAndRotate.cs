using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class AutoMoveAndRotate : MonoBehaviour
    {
        public Vector3andSpace moveUnitsPerSecond;
        public Vector3andSpace rotateDegreesPerSecond;
        public bool ignoreTimescale;
        private float m_LastRealTime;
        private Vector3 m_position;
        public Vector3 distance;
        private Transform m_Armature;
        private Vector3 direction;



        private void Start()
        {
            m_LastRealTime = Time.realtimeSinceStartup;
            m_position = transform.position;
            m_Armature = transform.Find("SnakeArmature");
            direction = m_Armature.eulerAngles;
            distance += m_position;
        }


        // Update is called once per frame
        private void Update()
        {
            m_position = transform.position;

            float deltaTime = Time.deltaTime;
            if (ignoreTimescale)
            {
                deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
                m_LastRealTime = Time.realtimeSinceStartup;
            }
            transform.Translate(moveUnitsPerSecond.value*deltaTime, moveUnitsPerSecond.space);
            transform.Rotate(rotateDegreesPerSecond.value*deltaTime, moveUnitsPerSecond.space);

            if (m_position == distance)
            {

                Vector3 theScale = m_Armature.eulerAngles;
                if (theScale != direction)
                {
                    theScale.y -= 90;
                }
                else
                {
                    theScale.y += 90;
                }
                m_Armature.eulerAngles = theScale;
            }
        }


        [Serializable]
        public class Vector3andSpace
        {
            public Vector3 value;
            public Space space = Space.Self;
        }
    }
}
