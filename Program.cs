List<Persona> ListaCenso = new List<Persona>();
int opcion;
do
{
    Console.Clear();
    Console.WriteLine("1. Ingresar Persona");
    Console.WriteLine("2. Ver resultados del censo");
    Console.WriteLine("3. Buscar Persona");
    Console.WriteLine("4. Modificar Email de una Persona");
    Console.WriteLine("5. Salir");
    opcion = Funciones.IngresarEnteroEnRango("Elija opción: ", 1, 5);
    Console.Clear();
    switch (opcion)
    {
        case 1:
            IngresarPersona();
            break;
        case 2:
            VerResultadosCenso();
            break;
        case 3:
            BuscarPersona();
            break;
        case 4:
            ModificarEmail();
            break;
    }
} while (opcion != 5);

void IngresarPersona()
{
    int dni = Funciones.IngresarEntero("Ingrese DNI ");
    bool valido= Funciones.ValidarDni(dni, ListaCenso); 
     if (valido== false )
    {
        Console.WriteLine("Ingrese denuevo el dni"); 
        dni = Funciones.IngresarEntero("Ingrese DNI ");
    }
    bool eldniSeRepite= Funciones.ValidarDniIgual(dni,ListaCenso); 
    if(eldniSeRepite== true)
    {
        Console.WriteLine("El dni se repite con otra persona"); 
        dni = Funciones.IngresarEntero("Ingrese otro dni ");
    }

    string apellido = Funciones.IngresarTexto("Ingrese Apellido ");
    string nombre = Funciones.IngresarTexto("Ingrese Nombre ");
    DateTime fn = Funciones.IngresarFecha("Ingrese Fecha de Nacimiento (aaaa/mm/dd) ");
    string mail = Funciones.IngresarTexto("Ingrese el email ");
    bool esValido = Funciones.ValidarEmail(mail); 
    if (esValido == false )
    {
        Console.WriteLine("Este email no es válido , ingrese devuelta"); 
        mail= Funciones.IngresarTexto("Ingrese el email");

    }

    
    Persona UnaPersona =  new Persona(dni,apellido,nombre,fn,mail);
    ListaCenso.Add(UnaPersona);
    
}

void VerResultadosCenso(){
int personapuedevotar=0;
int sumadeedades=0;
foreach(Persona item in ListaCenso)
{
    int edad = item.ObtenerEdad();
    if(edad>=16)
    {
        personapuedevotar++;
    }
    sumadeedades = sumadeedades + edad;
   
}
Console.WriteLine("Estadisticas del censo");
Console.WriteLine("Cantidad de personas habilitadas para votar: " + personapuedevotar);
Console.WriteLine("Cantidad de personas: "+ ListaCenso.Count);
Console.WriteLine("Promedio de edad: "+ sumadeedades/ListaCenso.Count);
Console.ReadLine();
}

void BuscarPersona()
{
    bool encontrodni = false;
    int dniabuscar = Funciones.IngresarEntero("ingresa tu dni para buscarte en la lista ");
    foreach(Persona item in ListaCenso)
    {
        if(dniabuscar == item.DNI)
        {
        encontrodni=true;
        Console.WriteLine("DNI: " + item.DNI +  " Apellido: " + item.Apellido + " Nombre: " + item.Nombre + " Fecha de nacimiento: " + item.FechaDeNacimiento + " Email: " + item.Email +  " Edad: " + item.ObtenerEdad() + " ¿Puede votar?: " + item.PuedeVotar());
        Console.ReadLine();
        }
        
    }
    if(encontrodni = false)
    {
    Console.WriteLine("No se encuentra el DNI");
    Console.ReadLine();
    }
    

}

void ModificarEmail()
{
    bool encontrodni = false;
    int dniabuscar = Funciones.IngresarEntero("ingresa tu dni para buscarte en la lista ");
    foreach(Persona item in ListaCenso)
    {
        if(dniabuscar == item.DNI)
        {
        encontrodni=true;
        Console.WriteLine("DNI: " + item.DNI + " Email: " + item.Email);
        string mail = Funciones.IngresarTexto("Ingrese el nuevo Email: ");
        item.Email = mail;
        Console.WriteLine("El nuevo email es: " + item.Email);
        Console.ReadLine();
        }
    }
    if(encontrodni = false)
    {
        Console.WriteLine("No se encuentra el DNI en la lista");
        Console.ReadLine();
    }
    

}




