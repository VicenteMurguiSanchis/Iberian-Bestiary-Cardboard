using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Localizacion : MonoBehaviour
{
    [SerializeField] private Transform coords;
    public int id;

    public Transform GetCoords()
    {
        return coords;
    }
}
