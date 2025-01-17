using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [SerializeField] private Cuelebre cuelebre;
    [SerializeField] private float timer;
    [SerializeField] private bool timer_active;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        timer_active = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer_active)
        {
            timer += Time.deltaTime;
            if(timer >= 30f)
            {
                timer = 0;
                timer_active = false;
                cuelebre.regresando = true;
            }
        }
    }

    public void LlamarCuelebre()
    {
        if(!timer_active)
        {
            source.PlayOneShot(clip);
            cuelebre.llamado = true;
            cuelebre.regresando = false;
            timer_active = true;
        }
    }
}
