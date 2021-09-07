using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BoletasUsuario
{
    class EspecialesSQL
    {
        private SqlConnection conexion = new SqlConnection("data source = 192.168.0.7; initial catalog = Permisos; user id = sa; password = grueconsa");
        private DataSet ds;

        public string idBoleta;
        public string correlativo;
        public string fechaSolicitud;
        public string observaciones1;
        public string observaciones2;
        public string observaciones3;
        public string observaciones4;
        public string fecha1;
        public string horaI1;
        public string horaF1;
        public string fecha2;
        public string horaI2;
        public string horaF2;
        public string fecha3;
        public string horaI3;
        public string horaF3;
        public string fecha4;
        public string horaI4;
        public string horaF4;
        public string fecha5;
        public string horaI5;
        public string horaF5;
        public string desc1A;
        public string desc2A;
        public string desc3A;
        public string desc4A;
        public string desc5A;
        public string totalH;
        public string idSolicitante;
        public string idCreador;
        public string idDepartamento;
        public string idJefe;
        public string idGerente;
        public string idRH;
        public string idEstado;
        public string Creador;
        public string Solicitante;
        public string Departamento;
        public string Jefe;
        public string Gerente;
        public string RH;
        public string Estado;

        public void ObtenerEspecial(string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select b.*, (select nombre from usuario where idUsuario = (select idCreador from BoletaEspecial where idBoleta = {0}))as Creador,(select nombre from usuario where idUsuario = (select idSolicitante from BoletaEspecial where idBoleta = {0}))as Solicitante,(select nombre from Departamento where idDepartamento = (select idDepartamento from BoletaEspecial where idBoleta = {0}))as Departamento,(select nombre from usuario where idUsuario = (select idJefe from BoletaEspecial where idBoleta = {0}))as Jefe,(select nombre from usuario where idUsuario = (select idGerente from BoletaEspecial where idBoleta = {0}))as Gerente,(select nombre from usuario where idUsuario = (select idRH from BoletaEspecial where idBoleta = {0}))as RH, e.nombre as Estado from BoletaEspecial b inner join estado e on b.idEstado = e.idEstado where b.idBoleta = {0}", new string[] { idBoleta }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            correlativo = Convert.ToString(reader["correlativo"]);
            observaciones1 = Convert.ToString(reader["observaciones1"]);
            observaciones2 = Convert.ToString(reader["observaciones2"]);
            observaciones3 = Convert.ToString(reader["observaciones3"]);
            observaciones4 = Convert.ToString(reader["observaciones4"]);
            fechaSolicitud = Convert.ToString(reader["fechaSolicitud"]);
            fecha1 = Convert.ToString(reader["fecha1"]);
            horaI1 = Convert.ToString(reader["horaI1"]);
            horaF1 = Convert.ToString(reader["horaF1"]);
            fecha2 = Convert.ToString(reader["fecha2"]);
            horaI2 = Convert.ToString(reader["horaI2"]);
            horaF2 = Convert.ToString(reader["horaF2"]);
            fecha3 = Convert.ToString(reader["fecha3"]);
            horaI3 = Convert.ToString(reader["horaI3"]);
            horaF3 = Convert.ToString(reader["horaF3"]);
            fecha4 = Convert.ToString(reader["fecha4"]);
            horaI4 = Convert.ToString(reader["horaI4"]);
            horaF4 = Convert.ToString(reader["horaF4"]);
            fecha5 = Convert.ToString(reader["fecha5"]);
            horaI5 = Convert.ToString(reader["horaI5"]);
            horaF5 = Convert.ToString(reader["horaF5"]);
            desc1A = Convert.ToString(reader["desc1A"]);
            desc2A = Convert.ToString(reader["desc2A"]);
            desc3A = Convert.ToString(reader["desc3A"]);
            desc4A = Convert.ToString(reader["desc4A"]);
            desc5A = Convert.ToString(reader["desc5A"]);
            totalH = Convert.ToString(reader["totalH"]);
            idSolicitante = Convert.ToString(reader["idSolicitante"]);
            idDepartamento = Convert.ToString(reader["idDepartamento"]);
            idEstado = Convert.ToString(reader["idEstado"]);
            reader.Close();
            conexion.Close();
        }
    }
}
