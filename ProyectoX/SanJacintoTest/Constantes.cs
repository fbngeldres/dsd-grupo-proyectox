using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJacintoTest
{
    class Constantes
    {
        public static string ERROR_PLACA_CREADA = "Ya existe un auto con la misma placa registrado";
        public static string ERROR_PLACA_MODIFICAR = "No se puede modificar el auto, ya que existe uno con la misma placa ingresado.";
        public static string ERROR_PLACA_EN_USO_MODIFICAR = "Actualmente el auto esta en uso, por ello no se puede modificar.";
        public static string ERROR_PLACA_ELIMINAR = "El auto ya ha sido eliminado";
        public static string ERROR_PLACA_EN_USO_ELIMINAR = "Actualmente el auto esta en uso, por ello no se puede eliminar.";
    }
}
