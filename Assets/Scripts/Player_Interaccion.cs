using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Interaccion : Singleton<Player_Interaccion>
{
    private float distancia_raycast = 150;
    [SerializeField] private Control_Localizacion control_location;
    [SerializeField] private Control_Localizacion control_location_posible;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distancia_raycast))
        {
            if(hit.collider.tag == "Location")
            {
                if(hit.collider.GetComponent<Control_Localizacion>().id != control_location.id)
                {
                    Debug.Log("Colisiona con el locator");
                    control_location_posible = hit.collider.gameObject.GetComponent<Control_Localizacion>();
                    GameManager.instance.Carga_New_Location();
                }
                else
                {
                    Debug.Log("Colisiona con el locator actual");
                    GameManager.instance.No_Cargar();
                }
            }
            else if(hit.collider.tag == "Book")
            {
                Debug.Log("Colisiona con un libro");
                GameManager.instance.Mostrar_Info_Libro(hit.collider.GetComponent<Book_Content>());
            }
            else if(hit.collider.tag == "Cofre")
            {
                Debug.Log("Colisiona con un cofre");
                hit.collider.GetComponent<Cofre>().LlamarCuelebre();
            }
            else if (hit.collider.tag == "Flute")
            {
                Debug.Log("Colisiona con la flauta");
                hit.collider.GetComponent<Flute_Pillar>().TocarFlauta();
            }
            else if (hit.collider.tag == "Trenti_Tree")
            {
                Debug.Log("Colisiona con un arbusto");
                hit.collider.GetComponent<Arbusto_Trenti>().ComprobarArbusto();
            }
            else if (hit.collider.tag == "Button")
            {
                Debug.Log("Colisiona con un boton");
                GameManager.instance.Carga_Boton();
            }
            else
            {
                Debug.Log("No colisiona");
                GameManager.instance.No_Cargar();

            }
        }
        else
        {
            Debug.Log("No colisiona");
            GameManager.instance.No_Cargar();
        }
    }

    public void Update_location()
    {
        control_location = control_location_posible;
        control_location_posible = null;


    }

    public Control_Localizacion get_next_location()
    {
        return control_location_posible;
    }
}
