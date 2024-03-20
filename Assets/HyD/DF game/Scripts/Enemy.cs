using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

namespace HyD
{
    public class Enemy : MonoBehaviour
    {
        private Animator m_anim;
        private Rigidbody2D m_rb;
        private float speed;
        // Start is called before the first frame update
        void Start()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}