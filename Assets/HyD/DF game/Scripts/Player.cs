using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class Player : MonoBehaviour
    {
        public float AtkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = AtkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                if (m_anim)
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_isAttacked = true;
            }
            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;
                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = AtkRate;
                }

            }

        }
        public void AtkReset()
        {
            if (m_anim)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, false);
            }
        }
    }

}