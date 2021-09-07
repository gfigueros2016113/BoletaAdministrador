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
    class IGSSsql
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
        public string desc1;
        public string totalH;
        public string idSolicitante;
        public string idDepartamento;
        public string idEstado;
        public void ObtenerConsulta(string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select b.*, (select nombre from usuario where idUsuario = (select idCreador from BoletaConsultaIGSS where idBoleta = {0}))as Creador,(select nombre from usuario where idUsuario = (select idSolicitante from BoletaConsultaIGSS where idBoleta = {0}))as Solicitante,(select nombre from Departamento where idDepartamento = (select idDepartamento from BoletaConsultaIGSS where idBoleta = {0}))as Departamento,(select nombre from usuario where idUsuario = (select idJefe from BoletaConsultaIGSS where idBoleta = {0}))as Jefe,(select nombre from usuario where idUsuario = (select idGerente from BoletaConsultaIGSS where idBoleta = {0}))as Gerente,(select nombre from usuario where idUsuario = (select idRH from BoletaConsultaIGSS where idBoleta = {0}))as RH, e.nombre as Estado from BoletaConsultaIGSS b inner join estado e on b.idEstado = e.idEstado where b.idBoleta = {0}", new string[] { idBoleta }), conexion);
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
            desc1 = Convert.ToString(reader["desc1"]);
            totalH = Convert.ToString(reader["totalH"]);
            idSolicitante = Convert.ToString(reader["idSolicitante"]);
            idDepartamento = Convert.ToString(reader["idDepartamento"]);
            idEstado = Convert.ToString(reader["idEstado"]);
            reader.Close();
            conexion.Close();
        }
    }
}
