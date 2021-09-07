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
    class SuspensionSql
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
        public string fechaInicio;
        public string fechaFinal;
        public string totalD;
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

        public void ObtenerSuspension(string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select b.*, (select nombre from usuario where idUsuario = (select idCreador from BoletaSuspencionIGSS where idBoleta = {0}))as Creador,(select nombre from usuario where idUsuario = (select idSolicitante from BoletaSuspencionIGSS where idBoleta = {0}))as Solicitante,(select nombre from Departamento where idDepartamento = (select idDepartamento from BoletaSuspencionIGSS where idBoleta = {0}))as Departamento,(select nombre from usuario where idUsuario = (select idJefe from BoletaSuspencionIGSS where idBoleta = {0}))as Jefe,(select nombre from usuario where idUsuario = (select idGerente from BoletaSuspencionIGSS where idBoleta = {0}))as Gerente,(select nombre from usuario where idUsuario = (select idRH from BoletaSuspencionIGSS where idBoleta = {0}))as RH, e.nombre as Estado from BoletaSuspencionIGSS b inner join estado e on b.idEstado = e.idEstado where b.idBoleta = {0}", new string[] { idBoleta }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            correlativo = Convert.ToString(reader["correlativo"]);
            observaciones1 = Convert.ToString(reader["observaciones1"]);
            observaciones2 = Convert.ToString(reader["observaciones2"]);
            observaciones3 = Convert.ToString(reader["observaciones3"]);
            observaciones4 = Convert.ToString(reader["observaciones4"]);
            fechaSolicitud = Convert.ToString(reader["fechaSolicitud"]);
            fechaInicio = Convert.ToString(reader["fechaInicio"]);
            fechaFinal = Convert.ToString(reader["fechaFinal"]);
            totalD = Convert.ToString(reader["totalD"]);
            idSolicitante = Convert.ToString(reader["idSolicitante"]);
            idDepartamento = Convert.ToString(reader["idDepartamento"]);
            idEstado = Convert.ToString(reader["idEstado"]);
            reader.Close();
            conexion.Close();
        }

    }
}
