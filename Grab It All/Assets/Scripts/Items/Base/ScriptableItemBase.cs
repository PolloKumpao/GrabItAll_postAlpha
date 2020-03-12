using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/ItemsBase", order = 1)]
public class ScriptableItemBase : ScriptableObject
{
    [Tooltip("Valor Economico del objeto, en caso que no sea possible de dropear, Valor sera igual a 0.")]
    public int Value;

    [Tooltip("Numero de unidades del objeto, si solo hay 1, se pone 1.")]
    public int Num;

    [Tooltip("Nombre del objeto.")]
    public string Name;
    [Tooltip("Descripcion del objeto.")]
    public string Description;

    [Tooltip("Modelo 3D del objeto.")]
    public GameObject Model;
    [Tooltip("Icono del objeto, para craftear o para el inventario.")]
    public Sprite Icon;

    [Tooltip("Tiempo de casteo del objeto.")]
    public float TimeCast;
    [Tooltip("Descripcion para interactuar con el objeto.")]
    public string TextUI;

    [Tooltip("Se puede guardar o no.")]
    public bool Dropable;
}
