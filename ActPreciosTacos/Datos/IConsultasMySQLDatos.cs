using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPreciosTacos.Datos
{
    public interface IConsultasMySQLDatos
    {
        bool pruebaConn();

        Modelos.Usuarios validaAcceso(string usuario, string pass);

        bool buscaUsuario(string usuario);

        long generaBitacora(string detalle, string fecha);

        void insertaProductos(List<Modelos.Productos> productos);

        List<Modelos.Productos> obtieneProductos();

        bool buscaCorreo(string correo);

        bool insertaUsuario(string nombreCompleto, string correo, string usuario, string clave, string fecha);

        bool validaClave(string claveActual, int _idUsuario);

        bool actualizaClave(string clave, int idUsuario, string usuario);

        int getSigBloque();

        bool guardaActualizacion(List<Modelos.Productos> seleccionados, int bloque, string fecha);

        void guardaBitacora(List<Modelos.Productos> anteriores, List<Modelos.Productos> seleccionados, long resultado);

        List<int> obtieneBloques(string fechaIni, string fechaFin);

        List<Modelos.Actualizacion> obtieneInformacion(string fechaIni, string fechaFin, int bloque, bool pendiente, bool realizado);
    }
}
