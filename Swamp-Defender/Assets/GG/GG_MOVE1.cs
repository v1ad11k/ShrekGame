using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GG_MOVE1 : MonoBehaviour
{
    private float SpeedKick;
    private int Health, Stamina,Force;
    private int[] Hits;
    private Ability[] Skills;
    float Ver, Hor, Jump,mouseX,xRotation,FB,LR;
    bool isGround;
    public float Speed = 10, JumpSpeed = 200,mouseSens=100f;
    Animator Ani;
    public void SetHealth(int bonus)
    {
        Health = Health+bonus;
    }
    public void SetStamina(int bonus)
    {
        Stamina = Stamina + bonus;
    }
    public void SetForce(int bonus)
    {
        Force = Force + bonus;
    }
    public int GetForce()
    {
        return Force;
    }
    private void Start()
    {
        
        Ani=GetComponent<Animator>();
        Health = 100;
        Stamina = 100;
        Force = 30;
        Hits = new int[3];
        Hits[0] = -10; Hits[1] = -20; Hits[2] = -30;
        SpeedKick = 1;
        Skills = new Ability[6];
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
    private void FixedUpdate()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        FB = Input.GetAxis("Vertical");
        LR = Input.GetAxis("Horizontal");
        Ani.SetFloat("RunFB", FB);
        Ani.SetFloat("RunLR", LR);
        if (isGround)
        {
            Ver = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;
            GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
           
        } transform.Translate(new Vector3(Hor, 0, Ver));
        //Ani.SetFloat("Kick", Input.GetAxis("Fire1"));
        if (Input.GetAxis("Fire1")>0)
        {
            Ani.SetBool("Fight", true);
            Ani.SetFloat("Kick", 1);
            if(Ani.GetBool("Fight"))
            {
                Ani.SetFloat("Kick", 2);
            }
        }
        else { Ani.SetFloat("Kick", 0); Ani.SetBool("Fight", false); }

        if (Input.GetKeyDown("space"))
        {
            Ability s = new Ability(10, 1);
            ActiveSkills(s);
        }

    }
    public void OnHit(int i)
    {
        SetHealth(Hits[i]);
        if (Health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    private void ActiveSkills(Ability skil)
    {
        if (skil.Gettype() == 1)
        {
            SpeedKick += skil.Getboost();
            Ani.SetFloat("SpeedPunc1", SpeedKick);
        }
    }
}
