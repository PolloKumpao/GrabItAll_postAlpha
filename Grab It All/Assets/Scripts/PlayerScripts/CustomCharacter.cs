using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacter : MonoBehaviour
{

    public PlayerSkin FemaleInfo;
    public PlayerSkin MaleInfo;
    public PlayerSkinSO PlayerInfo;
    public GameObject Male;
    public GameObject Female;

    private void Start()
    {
        if (PlayerInfo.MaleFame)
        {
            Male.SetActive(true);
            Female.SetActive(false);

        }
        else
        {
            Male.SetActive(false);
            Female.SetActive(true);
        }
    }

    private void Update()
    {
        if (PlayerInfo.MaleFame)
        {
            Male.SetActive(true);
            Female.SetActive(false);

        }
        else
        {
            Male.SetActive(false);
            Female.SetActive(true);
        }
    }


    public void MasHead()
    {
        if (PlayerInfo.MaleFame)
        {
            MaleInfo.headInt = (MaleInfo.headInt + 1) % MaleInfo.Head.Length;
        }
        else
        {
            FemaleInfo.headInt = (FemaleInfo.headInt + 1) % FemaleInfo.Head.Length;
        }

    }
    public void MinHead()
    {
        if (PlayerInfo.MaleFame)
        {
            MaleInfo.headInt = (MaleInfo.headInt - 1) % MaleInfo.Head.Length;
            if (MaleInfo.headInt < 0) { MaleInfo.headInt = MaleInfo.Head.Length - 1; }
        }
        else
        {
            FemaleInfo.headInt = (FemaleInfo.headInt - 1) % FemaleInfo.Head.Length;
            if (FemaleInfo.headInt < 0) { FemaleInfo.headInt = FemaleInfo.Head.Length - 1; }
        }

    }
    public void MasItem()
    {
        if (PlayerInfo.MaleFame)
        {
            MaleInfo.handInt = (MaleInfo.handInt + 1) % MaleInfo.HandItem.Length;
        }
        else
        {
            FemaleInfo.handInt = (FemaleInfo.handInt + 1) % FemaleInfo.HandItem.Length;
        }
    }
    public void MinItem()
    {
        if (PlayerInfo.MaleFame)
        {
            MaleInfo.handInt = (MaleInfo.handInt - 1) % MaleInfo.HandItem.Length;
            if (MaleInfo.handInt < 0) { MaleInfo.handInt = MaleInfo.HandItem.Length - 1; }
        }
        else
        {
            FemaleInfo.handInt = (FemaleInfo.handInt - 1) % FemaleInfo.HandItem.Length;
            if (FemaleInfo.handInt < 0) { FemaleInfo.handInt = FemaleInfo.HandItem.Length - 1; }
        }
    }
    public void MasBody()
    {
        if (PlayerInfo.MaleFame)
        {
            MaleInfo.bodyInt = (MaleInfo.bodyInt + 1) % MaleInfo.Bodys.Length;
        }
        else
        {
            FemaleInfo.bodyInt = (FemaleInfo.bodyInt + 1) % FemaleInfo.Bodys.Length;
        }
    }
    public void MinBody()
    {
        if (PlayerInfo.MaleFame)
        {
            MaleInfo.bodyInt = (MaleInfo.bodyInt - 1) % MaleInfo.Bodys.Length;
            if (MaleInfo.bodyInt < 0) { MaleInfo.bodyInt = MaleInfo.Bodys.Length - 1; }
        }
        else
        {
            FemaleInfo.bodyInt = (FemaleInfo.bodyInt - 1) % FemaleInfo.Bodys.Length;
            if (FemaleInfo.bodyInt < 0) { FemaleInfo.bodyInt = FemaleInfo.Bodys.Length - 1; }
        }
    }
    public void White() => PlayerInfo.WhiteBlack = false;

    public void Black() => PlayerInfo.WhiteBlack = true;

    public void Woman() => PlayerInfo.MaleFame = false;

    public void Man() => PlayerInfo.MaleFame = true;

}
