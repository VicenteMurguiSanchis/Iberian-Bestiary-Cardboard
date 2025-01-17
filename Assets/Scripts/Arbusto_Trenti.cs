using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbusto_Trenti : MonoBehaviour
{
    [SerializeField] private int id_arbusto;
    [SerializeField] private Trenti trenti;
    
    public void ComprobarArbusto()
    {
        if(id_arbusto == trenti.getIdArbusto() && !trenti.llamado)
        {
            trenti.CambiarArbusto();
        }
    }
}
