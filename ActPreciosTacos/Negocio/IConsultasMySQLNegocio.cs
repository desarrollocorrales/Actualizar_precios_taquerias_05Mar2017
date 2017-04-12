using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPreciosTacos.Negocio
{
    public interface IConsultasMySQLNegocio
    {
        bool pruebaConn();

        Modelos.Response validaAcceso(string usuario, string pass);

        long generaBitacora(string detalle, string fecha);

        void insertaProductos(List<Modelos.Productos> productos);

        List<Modelos.Productos> obtieneProductos();

        Modelos.Response creaUsuario(string nombreCompleto, string correo, string usuario, string clave, string fecha);

        bool validaClave(string claveActual, int _idUsuario);

        bool actualizaClave(string clave, int idUsuario, string usuario);

        int guardaActualizacion(List<Modelos.Productos> seleccionados, string fecha1);

        void guardaBitacora(List<Modelos.Productos> anteriores, List<Modelos.Productos> seleccionados, long resultado);

        List<int> obtieneBloques(string fechaIni, string fechaFin);

        List<Modelos.Actualizacion> obtieneInformacion(string fechaIni, string fechaFin, int bloque, bool pendiente, bool realizado);
    }
}
