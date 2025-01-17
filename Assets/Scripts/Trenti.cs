using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trenti : Monster
{
    [SerializeField] private int id_arbusto;
    [SerializeField] private int contador_encuentros;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    [SerializeField] private Transform last_direction;

    [SerializeField] private Transform arbusto_1, arbusto_2, arbusto_3, pos_final;


    [SerializeField] private float timer;
    [SerializeField] private bool timer_active;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();

        id_arbusto = 1;
        contador_encuentros = 0;

        timer_active = false;
        timer = 0;

        llamado = false;
        vel = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(llamado)
        {
            Movement();
        }
        else
        {
            if(id_arbusto == 3)
            {
                timer_active = true;
            }
        }

        if (timer_active)
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                timer = 0;
                timer_active = false;
                id_arbusto = Random.Range(0, 3);
                llamado = true;
                Movement();
            }
        }
    }

    public int getIdArbusto()
    {
        return id_arbusto;
    }

    public void CambiarArbusto()
    {
        int next_id_arbusto = Random.Range(0, 3);
        while(next_id_arbusto == id_arbusto)
        {
            next_id_arbusto = Random.Range(0, 3);
        }
        id_arbusto = next_id_arbusto;
        contador_encuentros++;
        if(contador_encuentros == 4)
        {
            contador_encuentros = 0;
            id_arbusto = 3;
        }
        llamado = true;
        source.PlayOneShot(clip);
    }

    private void Movement()
    {
        switch(id_arbusto)
        {
            case 0:
                Direccion_Objetivo(arbusto_1);
                Movement(dir_ida, arbusto_1, "walk");
                break;
            case 1:
                Direccion_Objetivo(arbusto_2);
                Movement(dir_ida, arbusto_2, "walk");
                break;
            case 2:
                Direccion_Objetivo(arbusto_3);
                Movement(dir_ida, arbusto_3, "walk");
                break;
            case 3:
                Direccion_Objetivo(pos_final);
                Movement(dir_ida, pos_final, "walk");
                if(!llamado)
                {
                    Go_Last_Pos();
                }
                break;
        }
    }

    private void Go_Last_Pos()
    {

        var rotacion = last_direction.position - transform.position;

        rotacion.y = 0;

        var rotacion_Quaternion = Quaternion.LookRotation(rotacion);

        transform.rotation = rotacion_Quaternion;
    }
}
