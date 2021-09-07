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
    class ReposicionesSQL
    {

        private SqlConnection conexion = new SqlConnection("data source = 192.168.0.7; initial catalog = Permisos; user id = sa; password = grueconsa");
        private DataSet ds;
        public string idBoleta;
        public string correlativo;
        public string observaciones1;
        public string observaciones2;
        public string observaciones3;
        public string observaciones4;
        public string fechaSolicitud;
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
        public string fecha1R;
        public string horaI1R;
        public string horaF1R;
        public string fecha2R;
        public string horaI2R;
        public string horaF2R;
        public string fecha3R;
        public string horaI3R;
        public string horaF3R;
        public string fecha4R;
        public string horaI4R;
        public string horaF4R;
        public string fecha5R;
        public string horaI5R;
        public string horaF5R;
        public string desc1A;
        public string desc2A;
        public string desc3A;
        public string desc4A;
        public string desc5A;
        public string desc1R;
        public string desc2R;
        public string desc3R;
        public string desc4R;
        public string desc5R;
        public string totalH;
        public string totalHR;
        public string Creador;
        public string idSolicitante;
        public string idDepartamento;
        public string Jefe;
        public string Gerente;
        public string RH;
        public string idEstado;


        public void ObtenerReposicion(string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select b.*, (select nombre from usuario where idUsuario = (select idCreador from BoletaReposicion where idBoleta = {0}))as Creador,(select nombre from usuario where idUsuario = (select idSolicitante from BoletaReposicion where idBoleta = {0}))as Solicitante,(select nombre from Departamento where idDepartamento = (select idDepartamento from BoletaReposicion where idBoleta = {0}))as Departamento,(select nombre from usuario where idUsuario = (select idJefe from BoletaReposicion where idBoleta = {0}))as Jefe,(select nombre from usuario where idUsuario = (select idGerente from BoletaReposicion where idBoleta = {0}))as Gerente,(select nombre from usuario where idUsuario = (select idRH from BoletaReposicion where idBoleta = {0}))as RH, e.nombre as Estado from BoletaReposicion b inner join estado e on b.idEstado = e.idEstado where b.idBoleta = {0}", new string[] { idBoleta }), conexion);
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
            fecha1R = Convert.ToString(reader["fecha1R"]);
            horaI1R = Convert.ToString(reader["horaI1R"]);
            horaF1R = Convert.ToString(reader["horaF1R"]);
            fecha2R = Convert.ToString(reader["fecha2R"]);
            horaI2R = Convert.ToString(reader["horaI2R"]);
            horaF2R = Convert.ToString(reader["horaF2R"]);
            fecha3R = Convert.ToString(reader["fecha3R"]);
            horaI3R = Convert.ToString(reader["horaI3R"]);
            horaF3R = Convert.ToString(reader["horaF3R"]);
            fecha4R = Convert.ToString(reader["fecha4R"]);
            horaI4R = Convert.ToString(reader["horaI4R"]);
            horaF4R = Convert.ToString(reader["horaF4R"]);
            fecha5R = Convert.ToString(reader["fecha5R"]);
            horaI5R = Convert.ToString(reader["horaI5R"]);
            horaF5R = Convert.ToString(reader["horaF5R"]);
            desc1A = Convert.ToString(reader["desc1A"]);
            desc2A = Convert.ToString(reader["desc2A"]);
            desc3A = Convert.ToString(reader["desc3A"]);
            desc4A = Convert.ToString(reader["desc4A"]);
            desc5A = Convert.ToString(reader["desc5A"]);
            desc1R = Convert.ToString(reader["desc1R"]);
            desc2R = Convert.ToString(reader["desc2R"]);
            desc3R = Convert.ToString(reader["desc3R"]);
            desc4R = Convert.ToString(reader["desc4R"]);
            desc5R = Convert.ToString(reader["desc5R"]);
            totalH = Convert.ToString(reader["totalH"]);
            totalHR = Convert.ToString(reader["totalHR"]);
            idSolicitante = Convert.ToString(reader["idSolicitante"]);
            idDepartamento = Convert.ToString(reader["idDepartamento"]);
            idEstado = Convert.ToString(reader["idEstado"]);
            reader.Close();
            conexion.Close();
        }

    }
}
