using System.Text.RegularExpressions; 
public class Persona
{
public int DNI{get;set;}
public string Apellido {get;set;}
public string Nombre {get;set;}
public DateTime FechaDeNacimiento {get;set;}
public string Email {get;set;}
private int Edad;

public Persona (int dni, string apellido, string nombre, DateTime fn, string mail)
{
DNI = dni;
Apellido = apellido;
Nombre = nombre;
FechaDeNacimiento = fn;
Email = mail;
Edad = 0;
}
public int ObtenerEdad()
    {
        DateTime FechaNacimientoHoy = new DateTime(DateTime.Today.Year, FechaDeNacimiento.Month, FechaDeNacimiento.Day);
        if (FechaNacimientoHoy< DateTime.Today)  Edad = DateTime.Today.Year - FechaDeNacimiento.Year;
            else   Edad = DateTime.Today.Year - FechaDeNacimiento.Year -1;
        return Edad; 
    }

public bool PuedeVotar()
{
    bool puedeVotar = false; 
    if(Edad>=16)
    {
        puedeVotar = true;
    }
    return puedeVotar; 

}


}
