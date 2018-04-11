using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float timeBetweenAttack = 0.3f; // ??
    //public float range = 100f;


    float timer;
    //int DamagedMask;
    Animator anim;
    float effectsDisplayTime = 0.2f;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float vertAttack = Input.GetAxisRaw("VerticalAttack");
        float horizAttack = Input.GetAxisRaw("HorizontalAttack");
        if ((Mathf.Abs(vertAttack) ==1 || Mathf.Abs(horizAttack) == 1) && timer >= timeBetweenAttack && Time.timeScale != 0) // таймСкале заглядывая на перед
        {
            Attack(vertAttack,horizAttack);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
        /*
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }*/
    }
    void Attack(float vertAttack,float horizAttack)
    {
        timer = 0f;
        anim.SetBool("isAttack", true);
        anim.SetFloat("AttackHorizontal", horizAttack);
        anim.SetFloat("AttackVertical", vertAttack);
    }
}
