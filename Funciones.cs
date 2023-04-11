using System.Text.RegularExpressions; 

public static class Funciones

{
    public static string IngresarTexto(string msj)
    {
        string texto = "";
        while (texto == "")
        {
            Console.Write(msj);
            texto = Console.ReadLine();
        }
        return texto;
    }
    public static int IngresarEntero(string msj)
    {
        int entero=-1;
        while (entero == -1)
        {   
            Console.Write(msj);
            int.TryParse(Console.ReadLine(), out entero);
        }
        return entero;
    }

    public static int IngresarEnteroEnRango(string msj, int minimo, int maximo)
    {
        int entero;
        entero = IngresarEntero(msj);
        while (entero < minimo || entero > maximo)
        {
            entero = IngresarEntero("ERROR! " + msj);
        }
        return entero;
    }

    public static DateTime IngresarFecha(string msj)
    {
        DateTime fechaDate;
        string fechaCadena = IngresarTexto(msj);
        while (!DateTime.TryParse(fechaCadena, out fechaDate))
        {
            fechaCadena = IngresarTexto("ERROR! " + msj);
        }
        return fechaDate;
    }
     public static bool ValidarEmail(string email)
     {
        
        String sFormato; 
        sFormato= "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"; 
        if (Regex.IsMatch(email,sFormato))
        {
            if (Regex.Replace(email,sFormato, string.Empty).Length==0)
            {
                return true;
            }
            else
            {
                return false; 
            }

        }
        else 
        {
            return false;
        }
     }
     public static bool ValidarDni(int dni,List<Persona> ListaCenso)
     {
        int digitos = (int)Math.Floor(Math.Log10(dni) + 1);
        bool esvalido = false;
        if (digitos == 8)
        {
            Console.WriteLine("El dni es válido");
            esvalido = true;
        }
        else
        {
            Console.WriteLine("El DNI no es válido, debería tener 8 dígitos");
        }

     return esvalido; 
     }
      public static  bool ValidarDniIgual(int dni,List<Persona> ListaCenso)
      {
        bool encontrodni = false;
        foreach(Persona item in ListaCenso)
        {
            if(dni == item.DNI)
            {
            encontrodni=true;
            }
            else
            {
                encontrodni= false;  
            }
        }
        return encontrodni; 
}}
