using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Book_Content : MonoBehaviour
{
    [SerializeField] private TMP_Text Titulo, Descripcion;
    [SerializeField] private Image imagen;
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject pagina;

    [TextArea]
    [SerializeField] private string str_titulo, str_descripcion;

    public void Mostrar_Pagina()
    {
        pagina.SetActive(true);
        Titulo.text = str_titulo;
        Descripcion.text = str_descripcion;
        imagen.sprite = sprite;
    }

    public void Cerrar_Pagina()
    {
        pagina.SetActive(false);
    }
}
