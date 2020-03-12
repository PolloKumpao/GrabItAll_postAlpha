using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TargetController : MonoBehaviour
{
    public enum tipoTarget {POSICION,DINERO,CANTIDAD,CLAVE,DETECCION};
    private string filePath = "E:/edufs/Documents/OneDrive/Escritorio/Proyecto3/Grab-It-All/Grab It All/Assets/HUD/Objetivos/TargetLevel1.txt";
    public Text textoTarget;
    public Text tipoText;
    // Start is called before the first frame update
    void Start()
    {
     

        

    }

    // Update is called once per frame
    void Update()
    {
        readTextFile(filePath);
    }
    public class objetivo
    {
        public objetivo(int i, string s, bool b, tipoTarget t)
        {
            numeroObjetivo = i;
            textoObjetivo = s;
            isDone = b;
            tipo = t;

        }
        public tipoTarget tipo;
        public int numeroObjetivo = 1;
        public string textoObjetivo;
        public bool isDone;
    }
    public void GoalSucced(int n)
    {
        //targetList[n].isDone = true;
        //Debug.Log(targetList[n].textoObjetivo);
        //numeroObjetivoActual++;
    }
    void readTextFile(string file_path)
    {
        int Nlinea = 1;
        StreamReader inp_stm = new StreamReader(file_path);
       

        while (!inp_stm.EndOfStream)
        {

            string inp_ln = inp_stm.ReadLine();
            if (Nlinea % 2 == 0)
            {

                textoTarget.text = inp_ln;
                Nlinea++;

            }
            else
            {
                tipoText.text = inp_ln;
                Nlinea++;
            }
          
        }

        inp_stm.Close();
    }
}
