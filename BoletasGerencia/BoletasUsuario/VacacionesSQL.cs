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
    class VacacionesSQL
    {
        private SqlConnection conexion = new SqlConnection("data source = 192.168.0.7; initial catalog = Permisos; user id = sa; password = grueconsa");
        private DataSet ds;
        public string idBoleta;
        public string correlativo;
        public string obs1;
        public string obs2;
        public string obs3;
        public string obs4;
        public string fechaSolicitud;
        public string obs;
        public string fecha1;
        public string fecha2;
        public string fecha3;
        public string fecha4;
        public string fecha5;
        public string fecha6;
        public string fecha7;
        public string fecha8;
        public string fecha9;
        public string fecha10;
        public string desc1;
        public string desc2;
        public string desc3;
        public string desc4;
        public string desc5;
        public string desc6;
        public string desc7;
        public string desc8;
        public string desc9;
        public string desc10;
        public string totalD;
        public string creador;
        public string departamento;
        public string jefe;
        public string gerente;
        public string RH;
        public string estado;
        public string idSolicitante;
        public string idDepartamento;
        public string idEstado;



        public void ObtenerVacaciones(string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select b.*, (select nombre from usuario where idUsuario = (select idCreador from BoletaVacaciones where idBoleta = {0}))as Creador,(select nombre from usuario where idUsuario = (select idSolicitante from BoletaVacaciones where idBoleta = {0}))as Solicitante,(select nombre from Departamento where idDepartamento = (select idDepartamento from BoletaVacaciones where idBoleta = {0}))as Departamento,(select nombre from usuario where idUsuario = (select idJefe from BoletaVacaciones where idBoleta = {0}))as Jefe,(select nombre from usuario where idUsuario = (select idGerente from BoletaVacaciones where idBoleta = {0}))as Gerente,(select nombre from usuario where idUsuario = (select idRH from BoletaVacaciones where idBoleta = {0}))as RH, e.nombre as Estado from boletaVacaciones b inner join estado e on b.idEstado = e.idEstado where b.idBoleta = {0}", new string[] { idBoleta }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            correlativo = Convert.ToString(reader["correlativo"]);
            obs1 = Convert.ToString(reader["observaciones1"]);
            obs2 = Convert.ToString(reader["observaciones2"]);
            obs3 = Convert.ToString(reader["observaciones3"]);
            obs4 = Convert.ToString(reader["observaciones4"]);
            fechaSolicitud = Convert.ToString(reader["fechaSolicitud"]);
            fecha1 = Convert.ToString(reader["fecha1"]);
            fecha2 = Convert.ToString(reader["fecha2"]);
            fecha3 = Convert.ToString(reader["fecha3"]);
            fecha4 = Convert.ToString(reader["fecha4"]);
            fecha5 = Convert.ToString(reader["fecha5"]);
            fecha6 = Convert.ToString(reader["fecha6"]);
            fecha7 = Convert.ToString(reader["fecha7"]);
            fecha8 = Convert.ToString(reader["fecha8"]);
            fecha9 = Convert.ToString(reader["fecha9"]);
            fecha10 = Convert.ToString(reader["fecha10"]);
            desc1 = Convert.ToString(reader["desc1"]);
            desc2 = Convert.ToString(reader["desc2"]);
            desc3 = Convert.ToString(reader["desc3"]);
            desc4 = Convert.ToString(reader["desc4"]);
            desc5 = Convert.ToString(reader["desc5"]);
            desc6 = Convert.ToString(reader["desc6"]);
            desc7 = Convert.ToString(reader["desc7"]);
            desc8 = Convert.ToString(reader["desc8"]);
            desc9 = Convert.ToString(reader["desc9"]);
            desc10 = Convert.ToString(reader["desc10"]);
            totalD = Convert.ToString(reader["totalD"]);
            creador = Convert.ToString(reader["Creador"]);
            idDepartamento = Convert.ToString(reader["idDepartamento"]);
            jefe = Convert.ToString(reader["Jefe"]);
            gerente = Convert.ToString(reader["Gerente"]);
            RH = Convert.ToString(reader["RH"]);
            estado = Convert.ToString(reader["Estado"]);
            idSolicitante = Convert.ToString(reader["idSolicitante"]);
            idEstado = Convert.ToString(reader["idEstado"]);
            reader.Close();
            conexion.Close();
        }

        public void sumarDias(string dias, string idUsuario)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE Usuario SET vacaciones += '{0}' WHERE idUsuario = '{1}'", new string[] { dias, idUsuario }), conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void anularBoleta(string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET idEstado = 14 WHERE idBoleta = '{0}' ",new string[] { idBoleta }), conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
