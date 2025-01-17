using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject Player;
    [SerializeField] private Book_Content libro_abierto_actual;
    [SerializeField] private Collider arbusto_1, arbusto_2, arbusto_3, flauta, cofre, book1, book2, book3, book4, c_locator1, c_locator2, c_locator3, c_locator4;
    [SerializeField] private float timer;
    [SerializeField] private Image panel_fade;
    private bool fade_in_active;
    private bool fade_out_active;

    // Start is called before the first frame update
    void Start()
    {
        fade_in_active = false;
        fade_out_active = true;
        timer = 0;
        if(SceneManager.GetActiveScene().name == "Prueba_2" || SceneManager.GetActiveScene().name == "Prueba_Controller")
        {
            arbusto_1.enabled = false;
            arbusto_2.enabled = false;
            arbusto_3.enabled = false;
            flauta.enabled = false;
            cofre.enabled = false;
            book1.enabled = true;
            book2.enabled = false;
            book3.enabled = false;
            book4.enabled = false;
            c_locator1.enabled = false;
            c_locator3.enabled = true;
            c_locator2.enabled = true;
            c_locator4.enabled = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion del timer para volver a cargar la escena
        if (SceneManager.GetActiveScene().name == "Prueba_2" || SceneManager.GetActiveScene().name == "Prueba_Controller")
        {
            timer += Time.deltaTime;
            //Activa el fade_in
            if(timer >= 298.5f)
            {
                fade_in_active = true;
            }
            if (timer >= 300f)
            {
                timer = 0;
                if(SceneManager.GetActiveScene().name == "Prueba_2")
                    OpenScene();
                else if (SceneManager.GetActiveScene().name == "Prueba_Controller")
                    OpenSceneController();
            }
        }


        //Comprueba si hay que activar un fade_in o fade_out;
        if(fade_in_active)
        {
            FadeIn();
        }
        else if(fade_out_active)
        {
            FadeOut();
        }
    }

    public void ActivefadeIn()
    {
        fade_in_active = true;
        var ColorEditable = panel_fade.color;
        ColorEditable.a = 0f;
        panel_fade.color = ColorEditable;
    }

    private void FadeIn()
    {
        var ColorEditable = panel_fade.color;
        ColorEditable.a += Time.deltaTime;
        if(ColorEditable.a >= 1)
        {
            ColorEditable.a = 1f;
            fade_in_active = false;
        }

        panel_fade.color = ColorEditable;

    }
    
    public void ActivefadeOut()
    {
        fade_out_active = true;
        var ColorEditable = panel_fade.color;
        ColorEditable.a = 1f;
        panel_fade.color = ColorEditable;
    }

    private void FadeOut()
    {
        var ColorEditable = panel_fade.color;
        ColorEditable.a -= Time.deltaTime;
        if (ColorEditable.a <= 0)
        {
            ColorEditable.a = 0f;
            fade_out_active = false;
        }

        panel_fade.color = ColorEditable;
    }

    public void MovePlayer(Control_Localizacion locator)
    {
        Player.transform.position = locator.GetCoords().position;
        Player.transform.rotation = new Quaternion(locator.GetCoords().rotation.x, locator.GetCoords().rotation.y, locator.GetCoords().rotation.z, locator.GetCoords().rotation.w);
        Player_Interaccion.instance.Update_location();
        switch(locator.id)
        {
            case 0:
                arbusto_1.enabled = false;
                arbusto_2.enabled = false;
                arbusto_3.enabled = false;
                flauta.enabled = false;
                cofre.enabled = false;
                book1.enabled = true;
                book2.enabled = false;
                book3.enabled = false;
                book4.enabled = false;
                c_locator1.enabled = false;
                c_locator2.enabled = true;
                c_locator3.enabled = true;
                c_locator4.enabled = true;
                break;
            case 1:
                arbusto_1.enabled = false;
                arbusto_2.enabled = false;
                arbusto_3.enabled = false;
                flauta.enabled = false;
                cofre.enabled = true;
                book1.enabled = false;
                book2.enabled = true;
                book3.enabled = false;
                book4.enabled = false;
                c_locator1.enabled = true;
                c_locator2.enabled = false;
                c_locator3.enabled = true;
                c_locator4.enabled = true;
                break;
            case 2:
                arbusto_1.enabled = false;
                arbusto_2.enabled = false;
                arbusto_3.enabled = false;
                flauta.enabled = true;
                cofre.enabled = false;
                book1.enabled = false;
                book2.enabled = false;
                book3.enabled = true;
                book4.enabled = false;
                c_locator1.enabled = true;
                c_locator2.enabled = true;
                c_locator3.enabled = false;
                c_locator4.enabled = true;
                break;
            case 3:
                arbusto_1.enabled = true;
                arbusto_2.enabled = true;
                arbusto_3.enabled = true;
                flauta.enabled = false;
                cofre.enabled = false;
                book1.enabled = true;
                book2.enabled = false;
                book3.enabled = false;
                book4.enabled = true;
                c_locator1.enabled = true;
                c_locator2.enabled = true;
                c_locator3.enabled = true;
                c_locator4.enabled = false;
                break;
        }
    }

    public void Carga_New_Location()
    {
        Barra_Carga.instance.gameObject.SetActive(true);
        Barra_Carga.instance.Update_Action(0);
    }

    public void Carga_Boton()
    {
        Barra_Carga.instance.gameObject.SetActive(true);
        Barra_Carga.instance.Update_Action(1);
    }

    public void Mostrar_Info_Libro(Book_Content libro)
    {
        if(!libro_abierto_actual)
        {
            libro_abierto_actual = libro;
            libro_abierto_actual.Mostrar_Pagina();
        }  
    }

    public void No_Cargar()
    {
        if(Barra_Carga.instance.gameObject.activeSelf)
            Barra_Carga.instance.gameObject.SetActive(false);
        if(libro_abierto_actual)
        {
            libro_abierto_actual.Cerrar_Pagina();
            libro_abierto_actual = null;
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Prueba_2");
    }

    public void OpenSceneController()
    {
        SceneManager.LoadScene("Prueba_Controller");
    }
}
