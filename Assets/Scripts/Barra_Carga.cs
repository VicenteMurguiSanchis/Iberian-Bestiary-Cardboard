using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_Carga : Singleton<Barra_Carga>
{
    [SerializeField] private float valor_actual;
    [SerializeField] private float velocidad = 100f;
    [SerializeField] private int id_action;
    [SerializeField] private GameObject barra_carga;
    // Start is called before the first frame update
    void Start()
    {
        valor_actual = 0;
        barra_carga.transform.localScale = new Vector3(0, 2, 2);
    }

    private void OnEnable()
    {
        barra_carga.transform.localScale = new Vector3(0, 2, 2);
        valor_actual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        valor_actual = (valor_actual + (velocidad * Time.deltaTime));
        barra_carga.transform.localScale = new Vector3(valor_actual / 100, 2, 2);
        if (valor_actual >= 200)
        {
            valor_actual = 0;
            Carga_finalizada();
            this.gameObject.SetActive(false);
        }
    }

    public void Update_Action(int new_action)
    {
        Debug.Log("Se ha cambiado el id de la barra a" + new_action);
        id_action = new_action;
    }

    private void Carga_finalizada()
    {
        switch(id_action)
        {
            case 0:
                Debug.Log("Se activa la funcion de mover");
                GameManager.instance.MovePlayer(Player_Interaccion.instance.get_next_location());
                break;
            case 1:
                Debug.Log("Se activa la funcion de cambiar escena");
                GameManager.instance.OpenScene();
                break;
        }
    }
}
