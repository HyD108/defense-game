using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HyD
{
    public class Enemy : MonoBehaviour , IConponentChecking
    {
        private Animator m_anim;
        private Rigidbody2D m_rb;
        public float speed;
        public float atkDistance;
        private Player m_player;


        // Start is called before the first frame update
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();

        }
        void Start()
        {

        }
        public bool IsComponentsNull()
        {
            return m_anim == null || m_rb == null || m_player == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentsNull()) return;

            float DisToPlayer = Vector2.Distance(m_player.transform.position, transform.position);

            if (DisToPlayer <= atkDistance) 
            {           
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_rb.velocity = Vector2.zero;
            }
            else
                    
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);

        }
        public void Die()
        {
            if(IsComponentsNull()) return;

            m_anim.SetTrigger(Const.DEATH_ANIM);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEATH_LAYER);
        }
    }

}