using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute_Pillar : MonoBehaviour
{

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool flauta_tocada;
    [SerializeField] private Musgosu musgosu;

    [SerializeField] private float timer;
    [SerializeField] private bool timer_active;

    // Start is called before the first frame update
    void Start()
    {
        flauta_tocada = false;
        timer_active = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
        {
            flauta_tocada = false;
        }

        if (timer_active)
        {
            timer += Time.deltaTime;
            if (timer >= 25f)
            {
                timer = 0;
                timer_active = false;
                musgosu.regresando = true;
            }
        }
    }

    public void TocarFlauta()
    {
        if(!flauta_tocada && !musgosu.regresando && !musgosu.llamado)
        {
            Debug.Log("Se toca la flauta");
            flauta_tocada = true;
            source.PlayOneShot(clip);
            musgosu.llamado = true;
            timer_active = true;
            
        }
    }
}
