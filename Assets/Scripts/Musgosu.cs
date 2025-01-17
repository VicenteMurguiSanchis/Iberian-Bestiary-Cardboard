using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musgosu : Monster
{

    [SerializeField] private Transform pos_destino, pos_origen;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();

        llamado = false;
        regresando = false;
        vel = 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Direccion_Objetivo(pos_destino);
    }

    // Update is called once per frame
    void Update()
    {
        if (llamado)
        {
            Moverse();
            Movement(dir_ida, pos_destino, "caminando");
        }

        else if (regresando)
        {
            Moverse();
            Movement(dir_vuelta, pos_origen, "caminando");
        }
        else
        {

            Parar();

        }
    }

    public void Moverse()
    {
        animator.SetBool("caminando", true);
    }

    public void Parar()
    {
        animator.SetBool("caminando", false);
        regresando = false;
        llamado = false;
    }
}
