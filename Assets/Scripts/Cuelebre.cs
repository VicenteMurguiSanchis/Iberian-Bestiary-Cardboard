using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuelebre : Monster
{

    [SerializeField] private Transform pos_guardia, origen_cueva;

    // Start is called before the first frame update

    private void Awake() {
        animator = this.GetComponentInChildren<Animator>();
        llamado = false;
        vel = 2.5f;
    }
    void Start()
    {
        Direccion_Objetivo(pos_guardia);
    }

    // Update is called once per frame
    void Update()
    {
        if (llamado)
        {
            Movement(dir_ida, pos_guardia, "fly");
        }

        else if(regresando)
        {
            Movement(dir_vuelta, origen_cueva, "fly");
        }
        else
        {
            
            animator.SetBool("fly", false);
            
        }
    }
}
