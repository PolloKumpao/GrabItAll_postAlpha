using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkin", menuName = "ScriptableObjects/Player/SkinBase", order = 2)]
public class PlayerSkinSO : ScriptableObject
{
    [Header("MaleSkinInfo")]
    public HeadMale hMale;
    public BodyMale bMale;

    [Header("FemaleSkinInfo")]
    public HeadFemale hFemale;
    public BodyFemale bFemale;

    [Header("GenderSkinInfo")]
    public bool MaleFame = true;
    public bool WhiteBlack = true;

    [Header("AgenderSkinInfo")]
    public Item iTem;
    public Acc aCc;

    public Material WhiteSkin;
    public Material BlackSkin;

    public GameObject Male;
    public GameObject Female;
}
