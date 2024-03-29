using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace HyD
{
    public class Player : MonoBehaviour , IConponentChecking
    {
        public float AtkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private bool m_isDead;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = AtkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        public bool IsComponentsNull()
        {
            return m_anim == null;
        }

        // Update is called once per frame
        void Update()
        {
            if(IsComponentsNull()) return;
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
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
                if (IsComponentsNull()) return;

                m_anim.SetBool(Const.ATTACK_ANIM, false);
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsComponentsNull()) return;
            if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !m_isDead)
            {
                m_anim.SetTrigger(Const.DEATH_ANIM);
                m_isDead = true;
            }
        }
    }

}