using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region EnumsSkin
public enum BodyMale
{
    BlackJacket = 0,
    BlackTShirt = 1,
    RedShirt = 2,
    Shirt = 3,
    TankTop = 4,
    TankTopI = 5,
    Sport = 6,
    SportChain = 7,
    Jacket = 8,
    GreySuit = 9,
    BrownSuit = 10,
    WhiteSuit = 11,
    RedTie = 12,
    SuitBlak = 13,
    Tuxedo = 14,
    WhiteTshirt = 15,
    YellowTshirt = 16,
    PinkPolo = 17,
    BluePolo = 18,
    Stripes = 19,
    UnderWearWhite = 20,
    UnderWearBlack = 21,
    SwimSuit = 22,
    LeatherJacket = 23,
    GreenJacket = 24,
    Bandit = 25,
    BanditI = 26,
    Worker = 27,
    WorkerI = 28,
    Punk = 29,
    PunkI = 30,
    PunkII = 31,
    PunkIII = 32,
    Rocker = 33,
    RockerI = 34,
    Butcher = 35,
    Farmer = 36,
    FarmerI = 37,
    FarmerII = 38,
    Police = 39,
    PoliceI = 40,
    PoliceII = 41,
    PoliceIII = 42,
    PoliceIV = 43,
    Sailor = 44,
    Priest = 45,
    Doctor = 46,
    Nurse = 47,
    Pilot = 48
}
public enum BodyFemale
{
    White = 0,
    Black = 1,
    Red = 2,
    CasualDress = 3,
    TankTop = 4,
    TankTopBlack = 5,
    SportSkirt = 6,
    SportBlue = 7,
    SportPink = 8,
    SportYellow = 9,
    Office = 10,
    SuitBlak = 11,
    SuitGrey = 12,
    SuitPink = 13,
    BlackJacket = 14,
    LeatherJacket = 15,
    WhiteDress = 16,
    BlackDress = 17,
    PinkDress = 18,
    RedDress = 19,
    UnderWearWhite = 20,
    UnderWearBlack = 21,
    UnderWearPink = 22,
    UnderWearRed = 23,
    WhiteLingerie = 24,
    BlackLingerie = 25,
    Police = 26,
    PoliceI = 27,
    PoliceII = 28,
    PoliceIII = 29,
    Nun = 30,
    Farmer = 31,
    FarmerI = 32,
    FarmerII = 33,
    Nurse = 34,
    NurseWhite = 35,
    Doctor = 36,
    Punk = 37,
    PunkI = 38,
    PunkII = 39,
    PunkIII = 40
}
public enum HeadMale
{
    PeinadoA = 0,
    PeinadoB = 1,
    PeinadoC = 2,
    PeinadoD = 3,
    PeinadoE = 4,
    PeinadoF = 5,
    PeinadoG = 6,
    PeinadoH = 7,
    PeinadoI = 8,
    PeinadoJ = 9,
    PeinadoK = 10,
    PeinadoL = 11,
    PeinadoM = 12,
    PeinadoN = 13,
    PeinadoO = 14,
    PeinadoP = 15,
    Rockabilly = 16,
    LonghairA = 17,
    LonghairB = 18,
    LonghairC = 19,
    LonghairD = 20,
    LonghairE = 21,
    AfroA = 22,
    AfroB = 23,
    AfroC = 24,
    SeniorA = 25,
    SeniorB = 26,
    SeniorC = 27,
    SeniorD = 28,
    CapA = 29,
    CapB = 30,
    CapC = 31,
    CapD = 32,
    CapE = 33,
    BeretA = 34,
    BeretB = 35,
    BeretC = 36,
    HatA = 37,
    HatB = 38,
    HatC = 39,
    HatD = 40,
    HatE = 41,
    HatF = 42,
    HatG = 43,
    HatH = 44,
    CowboyA = 45,
    CowboyB = 46,
    PoliceA = 47,
    PoliceB = 48,
    PoliceC = 49,
    PoliceD = 50,
    PilotA = 51,
    PilotB = 52,
    WorkerA = 53,
    WorkerB = 54,
    FarmerA = 55,
    FarmerB = 56,
    FarmerC = 57,
    FarmerD = 58,
    FarmerE = 59,
    Nurse = 60,
    Butcher = 61,
    Sailor = 62,
    PunkA = 63,
    PunkB = 64,
    PunkC = 65,
    PunkD = 66,
    PunkE = 67
}
public enum HeadFemale
{
    PeinadoA = 0,
    PeinadoB = 1,
    PeinadoC = 2,
    PeinadoD = 3,
    PeinadoE = 4,
    PeinadoF = 5,
    PeinadoG = 6,
    PeinadoH = 7,
    PeinadoI = 8,
    PeinadoJ = 9,
    PeinadoK = 10,
    PeinadoL = 11,
    PeinadoM = 12,
    PeinadoN = 13,
    PeinadoO = 14,
    PeinadoP = 15,
    PeinadoQ = 16,
    PeinadoR = 17,
    PeinadoS = 18,
    PeinadoT = 19,
    PeinadoU = 20,
    PeinadoV = 21,
    PeinadoW = 22,
    PeinadoX = 23,
    PeinadoY = 24,
    PeinadoZ = 25,
    PeinadoAA = 26,
    PeinadoBB = 27,
    PeinadoCC = 28,
    PeinadoDD = 29,
    PeinadoEE = 30,
    PeinadoFF = 31,
    PeinadoGG = 32,
    PeinadoHH = 33,
    PeinadoII = 34,
    PeinadoJJ = 35,
    PeinadoKK = 36,
    PeinadoLL = 37,
    PeinadoMM = 38,
    PeinadoNN = 39,
    PeinadoOO = 40,
    PeinadoPP = 41,
    PeinadoQQ = 42,
    PeinadoRR = 43,
    CapA = 43,
    CapB = 43,
    CapC = 43,
    HatA = 43,
    HatB = 43,
    HatC = 43,
    HatD = 43,
    HatE = 43,
    HatF = 43,
    HatG = 43,
    HatH = 43,
    PoliceA = 43,
    PoliceB = 43,
    Pilot = 43,
    PunkA = 43,
    PunkB = 43,
    PunkC = 43,
    PunkD = 43,
    PunkE = 43,
    NurseA = 43,
    NurseB = 43,
    Nun = 43
}
public enum Item
{
    Nada = 0,
    Clip = 1,
    Lapiz = 2,
    Tarjeta = 3,
    Bateria = 4,
    Llaves = 5,
    Reloj = 6,
    Piedras = 7,
    Mechero = 8,
    Ropa = 9,
    Espejo = 10,
    Herramienta = 11
}
public enum Acc
{
    Glasses = 0,
    GlassesI = 1,
    GlassesII = 2,
    Nada = 3
}
#endregion

public class PlayerSkin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Bodys;
    public GameObject[] HandItem;
    public GameObject[] Head;
    //public GameObject[] Glasses;

    public int bodyInt;
    public int handInt;
    public int headInt;
    public int glassesInt;

    public PlayerSkinSO PlayerInfo;

    //public TMPro.TextMeshProUGUI glassesNum;

    public
    void Start()
    {
        if (PlayerInfo.MaleFame == true)
        {
            bodyInt = (int)PlayerInfo.bMale;
            handInt = (int)PlayerInfo.iTem;
            headInt = (int)PlayerInfo.hMale;
            glassesInt = (int)PlayerInfo.aCc;

        }
        else
        {
            bodyInt = (int)PlayerInfo.bFemale;
            handInt = (int)PlayerInfo.iTem;
            headInt = (int)PlayerInfo.hFemale;
            glassesInt = (int)PlayerInfo.aCc;
        }
        ChangeLook();
    }
    void ChangeLook()
    {
        for (int i = 0; i < Bodys.Length; i++)
        {
            if (i == bodyInt)
            {
                Bodys[i].SetActive(true);
                if (PlayerInfo.WhiteBlack == true)
                {
                    Bodys[i].GetComponent<SkinnedMeshRenderer>().material = PlayerInfo.BlackSkin;
                }else
                {
                    Bodys[i].GetComponent<SkinnedMeshRenderer>().material = PlayerInfo.WhiteSkin;
                }
            }
            else
            {
                Bodys[i].SetActive(false);
            }
        }
        for (int i = 0; i < HandItem.Length; i++)
        {
            if (i == handInt)
            {
                HandItem[i].SetActive(true);
                if (PlayerInfo.WhiteBlack == true)
                {
                    HandItem[i].GetComponent<MeshRenderer>().material = PlayerInfo.BlackSkin;
                }
                else
                {
                    HandItem[i].GetComponent<MeshRenderer>().material = PlayerInfo.WhiteSkin;
                }
            }
            else
            {
                HandItem[i].SetActive(false);
            }
        }
        for (int i = 0; i < Head.Length; i++)
        {
            if (i == headInt)
            {
                Head[i].SetActive(true);
                if (PlayerInfo.WhiteBlack == true)
                {
                    Head[i].GetComponent<MeshRenderer>().material = PlayerInfo.BlackSkin;
                }
                else
                {
                    Head[i].GetComponent<MeshRenderer>().material = PlayerInfo.WhiteSkin;
                }
            }
            else
            {
                Head[i].SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeLook();
    }

    public void MasHead()
    {
        headInt = (headInt + 1) % Head.Length; 
    }
    public void MinHead()
    {
        headInt = (headInt - 1) % Head.Length;
        if(headInt < 0) { headInt = Head.Length - 1; }
    }
    public void MasItem()
    {
        handInt = (handInt + 1) % HandItem.Length;
    }
    public void MinItem()
    {
        handInt = (handInt - 1) % HandItem.Length;
        if (handInt < 0) { handInt = HandItem.Length - 1; }

    }
    public void MasBody()
    {
        bodyInt = (bodyInt + 1) % Bodys.Length;
    }
    public void MinBody()
    {
        bodyInt = (bodyInt - 1) % Bodys.Length;
        if (bodyInt < 0) { bodyInt = Bodys.Length - 1; }

    }
}
