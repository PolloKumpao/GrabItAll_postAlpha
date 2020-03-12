using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objetivos : MonoBehaviour
{
    
    public string tipo;
    public string mensaje;
    public string mensaje2;
    // Start is called before the first frame update
  
    public virtual int getObjetoaConseguir()
    {
        return 0;
    }
    public virtual int getCantidad()
    {
        return 0;
    }
    public virtual Vector2 getminPos()
    {
     
        return new Vector2 (0 , 0);
    }
    public virtual Vector2 getmaxPos()
    {

        return new Vector2(0, 0);
    }
    public virtual string getInput()
    {

        return "";
    }

}
public class Dinero : Objetivos
{
  
    public Dinero(int i,string t, string m)
    {
        cantidadObjetivo = i;
        tipo = t;
        mensaje = m;
    }
    public override int getCantidad()
    {
        return cantidadObjetivo;
    }
    public int cantidadObjetivo;
}
public class Cantidad : Objetivos
{
    public Cantidad(int i, int k, string t, string m)
    {
        id = i;
        cantidadObjetivo = k;
        tipo = t;
        mensaje = m;
    }
    public int id;
    public int cantidadObjetivo;
    public override int getCantidad()
    {
        return cantidadObjetivo;
    }
    public override int getObjetoaConseguir()
    {
        return id;
    }
}
public class Posicion : Objetivos
{
    public Posicion(int x, int X, int z, int Z, string t, string m)
    {
        minX = x;
        maxX = X;
        minZ = z;
        maxZ = Z;
        tipo = t;
        mensaje = m;

    }
    public int minX;
    public int minZ;
    public int maxX;
    public int maxZ;
    public override Vector2 getminPos()
    {
        return new Vector2 (minX,minZ);
    }
    public override Vector2 getmaxPos()
    {
        return new Vector2(maxX, maxZ);
    }
}
public class Clave : Objetivos
{
    public Clave(int i, string t, string m)
    {
        id = i;
        tipo = t;
        mensaje = m;
    }
    public override int getObjetoaConseguir()
    {
        return id;
    }
    public int id;
}
public class Menus : Objetivos
{
    public Menus(string t, string m, string m2, string I)
    {

        tipo = t;
        mensaje = m;
        tipo_input = I;
        mensaje2 = m2;
    }
    public string tipo_input;

    public override string getInput()
    {

        return tipo_input;
    }

}
