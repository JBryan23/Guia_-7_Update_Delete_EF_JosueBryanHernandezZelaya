using (var contextdb = new UNABDbContext())
{
    contextdb.Database.EnsureCreated();

    while (true)
    {
        Console.WriteLine("Menu de Estudiante");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("| Seleccione una opción que desea realizar:        |");
        Console.WriteLine("| 1- Agregar un nuevo registro                     |");
        Console.WriteLine("| 2- Eliminar un registro existente                |");
        Console.WriteLine("| 3- Mostrar los datos de la tabla (Estudiante)    |");
        Console.WriteLine("| 4- Modificar registros de (Estudiante)           |");
        Console.WriteLine("| 5- Salir                                         |");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        Console.Write("Usuario ingrese el número de la opción que quiere realizar: ");

        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            switch (opcion)
            {
                case 1:
                    var Agregar_Nuevo_Registros = true;
                    while (Agregar_Nuevo_Registros)
                    {
                        Console.WriteLine("Ingrese el nombre del estudiante: ");
                        var Nuevo_Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del estudiante");
                        var Nuevo_apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese la edad del estudiante (Solo numeros enteros)");
                        int Nuevo_Edad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el sexo del estudiante (Usar F= Femenino o Usar M= Masculino)");
                        var Nuevo_Sexo = Console.ReadLine();
                        var Estudiante1 = new Estudiante()
                        {
                            Nombres = Nuevo_Nombre,
                            Apellidos = Nuevo_apellido,
                            Edad = Nuevo_Edad,
                            Sexo = Nuevo_Sexo
                        };
                        contextdb.Add(Estudiante1);
                        contextdb.SaveChanges();
                        Console.WriteLine("-Registro completado-");
                        Console.WriteLine();

                        Console.Write(@"Usuario ¿Desea agregar más registros?
Si su respuesta es si ingrese la letra: S
Si su respuesta es No ingrese la letra: N (Y volvera al menu inicial)
Ingrese su respuesta: ");
                        string Respuesta_del_usuario = Console.ReadLine();

                        Agregar_Nuevo_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
                    }
                    break;
                case 2:
                    var Eliminar_Existente_Registros = true;
                    while (Eliminar_Existente_Registros)
                    {
                        Console.WriteLine("Datos de la tabla:");
                        using (var sqlserver = new UNABDbContext())
                        {
                            Console.WriteLine("|-----------------------------------------------------------------------------------|");
                            Console.WriteLine("|                              Datos de la tabla                                    |");
                            Console.WriteLine("|-----------------------------------------------------------------------------------|");
                            Console.WriteLine("| Id        | Nombre y Apellidos                                      | Edad | Sexo |");
                            Console.WriteLine("|-----------------------------------------------------------------------------------|");

                            foreach (var item in sqlserver.Estudiante)
                            {   
                                {
                                    Console.WriteLine($"| {item.Id,-9} | {item.Nombres,-27} {item.Apellidos,-27} | {item.Edad,-4} | {item.Sexo,-5}|");
                                }
                            }
                            Console.WriteLine("|-----------------------------------------------------------------------------------|");
                            Console.WriteLine();
                            //3. Hacer la eliminación de un registro utilizando el siguiente código ocupando la sintaxis de la guia 
                            Console.Write("Ingrese el Id del estudiante que desea eliminar: ");
                            var Id_Eliminar = Console.ReadLine();
                            var Estudiante_Eliminado = sqlserver.Estudiante.SingleOrDefault(Id_estudiante => Id_estudiante.Id == Int32.Parse(Id_Eliminar));
                            if (Estudiante_Eliminado != null)
                            {
                                sqlserver.Estudiante.Remove(Estudiante_Eliminado);
                                sqlserver.SaveChanges();
                                Console.WriteLine("-Registro eliminado-");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine(" Error el Id ingresado no existe, no se pudo eliminar el registro.");
                            }

                            Console.Write(@"Usuario ¿Desea eliminar más registros?
Si su respuesta es si ingrese la letra: S
Si su respuesta es No ingrese la letra: N (Y volvera al menu inicial)
Ingrese su respuesta: ");
                            string Respuesta_del_usuario = Console.ReadLine();

                            Eliminar_Existente_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
                        }
                    }
                    break;
                case 3:
                    using (var sqlserver = new UNABDbContext())
                    {
                        //1. Mostrar todos los datos de la tabla estudiante, como Id, nombres, edad y sexo como lo solicita la guia
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("|                              Datos de la tabla                                    |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("| Id        | Nombre y Apellidos                                      | Edad | Sexo |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");

                        foreach (var item in sqlserver.Estudiante)
                        {
                            Console.WriteLine($"| {item.Id,-9} | {item.Nombres,-27} {item.Apellidos,-27} | {item.Edad,-4} | {item.Sexo,-5}|");
                        }

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    var Modificar_Registros = true;
                    using (var sqlserver = new UNABDbContext())
                    {
                        //1. Mostrar todos los datos de la tabla estudiante, como Id, nombres, edad y sexo como lo solicita la guia
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("|                              Datos de la tabla                                    |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("| Id        | Nombre y Apellidos                                      | Edad | Sexo |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");

                        foreach (var item in sqlserver.Estudiante)
                        {
                            Console.WriteLine($"| {item.Id,-9} | {item.Nombres,-27} {item.Apellidos,-27} | {item.Edad,-4} | {item.Sexo,-5}|");
                        }

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine();
                    }
                    while (Modificar_Registros)
                    {
                        //2. Pedir por teclado que Id se desea modificar y que atributos desea modificar como se
                        //muestra en el ejemplo, agregando como condicion que atributo desea modificar,
                        //NOMBRE, APELLIDO, SEXO o EDAD tal como lo solicita la guia

                        Console.Write("Ingrese el Id del estudiante que desea modificar: ");
                        if (int.TryParse(Console.ReadLine(), out int Id_Modificar))
                        {
                            using (var sqlserver = new UNABDbContext())
                            {
                                var Estudiante_Modifcado = sqlserver.Estudiante.FirstOrDefault(Modificar_Estudiante => Modificar_Estudiante.Id == Id_Modificar);

                                if (Estudiante_Modifcado != null)
                                {
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine("|Seleccione el atributo que desea modificar:        |");
                                    Console.WriteLine("| 1- Nombre                                         |");
                                    Console.WriteLine("| 2- Apellido                                       |");
                                    Console.WriteLine("| 3- Edad                                           |");
                                    Console.WriteLine("| 4- Sexo                                           |");
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine();
                                    Console.Write("Usuario ingrese el número de la opción que quiere realizar: ");

                                    if (int.TryParse(Console.ReadLine(), out int Registro_Modificar))
                                    {
                                        switch (Registro_Modificar)
                                        {
                                            case 1:
                                                Console.Write("Ingrese el nuevo nombre que sera modicado: ");
                                                Estudiante_Modifcado.Nombres = Console.ReadLine();
                                                break;
                                            case 2:
                                                Console.Write("Ingrese el nuevo apellido que sera modicado: ");
                                                Estudiante_Modifcado.Apellidos = Console.ReadLine();
                                                break;
                                            case 3:
                                                Console.Write("Ingrese la nueva edad que sera modicado: ");
                                                if (int.TryParse(Console.ReadLine(), out int Nueva_Edad))
                                                {
                                                    Estudiante_Modifcado.Edad = Nueva_Edad;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                                                }
                                                break;
                                            case 4:
                                                Console.Write("Ingrese el nuevo sexo que sera modicado (Usar F= Femenino o Usar M= Masculino): ");
                                                string Nuevo_Sexo = Console.ReadLine();
                                                if (Nuevo_Sexo.ToUpper() == "F" || Nuevo_Sexo.ToUpper() == "M")
                                                {
                                                    Estudiante_Modifcado.Sexo = Nuevo_Sexo;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error no se realizaron cambios.");
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                                                break;
                                        }

                                        sqlserver.SaveChanges();
                                        Console.WriteLine("-Registro modificado-");
                                        Console.Write(@"Usuario ¿Desea modificar más registros?
Si su respuesta es si ingrese la letra: S
Si su respuesta es No ingrese la letra: N (Y volvera al menu inicial)
Ingrese su respuesta: ");
                                        string Respuesta_del_usuario = Console.ReadLine();

                                        Modificar_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" Error el Id ingresado no existe, no se pudo hacer el cambio del registro.");
                                }                              
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Error el Id ingresado no existe, no se pudo hacer el cambio del registro.");
                        }
                    }
                    break;
                case 5:
                    { Console.WriteLine("Hecho por Josue Bryan Hernandez Zelaya "); }
                    return;
                default:
                    Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                    break;
           
            }
        }
        else
        {
            Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
        }
    }
}









//Datos de la anterior codigo


// El usuario ingrese los datos desde la consola como, nombre, apellido, sexo y edad para ingresar nuevos registros
//using (var contextdb = new UNABDbContext())
//{
//    contextdb.Database.EnsureCreated();
//    var Agregar_Nuevo_Registros = true;
//    while (Agregar_Nuevo_Registros)
//    {
//        Console.WriteLine("Ingrese el nombre del estudiante: ");
//        var Nuevo_Nombre = Console.ReadLine();
//        Console.WriteLine("Ingrese el apellido del estudiante");
//        var Nuevo_apellido = Console.ReadLine();
//        Console.WriteLine("Ingrese la edad del estudiante (Solo numeros enteros)");
//        int Nuevo_Edad = Convert.ToInt32(Console.ReadLine());
//        Console.WriteLine("Ingrese el sexo del estudiante (Usar F= Femenino o Usar M= Masculino");
//        var Nuevo_Sexo = Console.ReadLine();
//        var Estudiante1 = new Estudiante()
//        {
//            Nombres = Nuevo_Nombre,
//            Apellidos = Nuevo_apellido,
//            Edad = Nuevo_Edad,
//            Sexo = Nuevo_Sexo
//        };
//        contextdb.Add(Estudiante1);
//        contextdb.SaveChanges();
//        Console.WriteLine("Registro completado");

//        Console.Write(@"Usuario ¿Desea agregar más registros?
//Si su respuesta es si ingrese la letra: S
//Si su respuesta es No ingrese la letra: N 
//Ingrese su respuesta: ");
//        string Respuesta_del_usuario = Console.ReadLine();

//        Agregar_Nuevo_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
//    }

//}

//Muestra los registros actuales tantos nuevos como antiguos (Total de la Base de datos)


// Modificacion del codigo para registros nuevos

//using (var contextdb = new UNABDbContext())
//{
//    contextdb.Database.EnsureCreated();
//    var estudiante1 = new Estudiante() { Nombres = "Pepito", Apellidos = "Pérez", Edad = 30, Sexo = "M"};
//    contextdb.Add(estudiante1);
//    contextdb.SaveChanges();
//    foreach (var s in contextdb.Estudiante)
//    {
//        Console.WriteLine(s.Apellidos);
//    }
//}
// Nota lo he comentado para que cuando quiera pueda usarlo y darse cuenta que si funciona y registra nuevos datos ya que cuando
// el usuario ingresa de manera implicita se ocupa agregar que tambien ya se registro lo que se solicitaba en ese apartado



// Hecho por Josue Bryan Hernandez Zelaya