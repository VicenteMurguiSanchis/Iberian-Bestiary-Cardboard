using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public bool llamado;
    public bool regresando;

    protected float vel;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Vector3 dir_ida;

    [SerializeField] protected Vector3 dir_vuelta;


    protected void Direccion_Objetivo(Transform pos_dest)
    {

        float mod_ida = Mathf.Sqrt(Mathf.Pow(pos_dest.position.x - this.transform.position.x, 2) + Mathf.Pow(pos_dest.position.z - this.transform.position.z, 2));
        dir_ida = new Vector3(((pos_dest.position.x - this.transform.position.x) / mod_ida), this.transform.position.y, ((pos_dest.position.z - this.transform.position.z) / mod_ida));

        dir_vuelta = new Vector3(-(dir_ida.x), this.transform.position.y, -(dir_ida.z));
    }

    protected void Movement(Vector3 direction, Transform destino, string name_animation)
    {
        if ((Mathf.Sqrt(Mathf.Pow(this.transform.position.x - destino.position.x, 2) + Mathf.Pow(this.transform.position.z - destino.position.z, 2))) > 1f)
        {
            animator.SetBool(name_animation, true);

            var rotacion = destino.position - transform.position;

            rotacion.y = 0;

            var rotacion_Quaternion = Quaternion.LookRotation(rotacion);

            transform.rotation = rotacion_Quaternion;

            this.transform.position = new Vector3(this.transform.position.x + (vel * direction.x) * Time.deltaTime, this.transform.position.y, this.transform.position.z + (vel * direction.z) * Time.deltaTime);
        }
        else
        {
            animator.SetBool(name_animation, false);
            llamado = false;
            regresando = false;
        }
    }
}
