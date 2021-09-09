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
    class ConsultasSQL
    {
        private SqlConnection conexion = new SqlConnection("data source = 192.168.0.5; initial catalog = Permisos; user id = sa; password = grueconsa");
        private DataSet ds;


        public bool Ingresar(string user, string contrasena)
        {
            conexion.Open();
            int resultado;
            SqlCommand cmd = new SqlCommand(string.Format("SELECT *from Usuario where usuario = '{0}' AND contrasena = '{1}'", new string[] { user, contrasena }), conexion);
            resultado = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            if (resultado > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        public string id;
        public string nombre;
        public string puesto;
        public string dias;
        public string contador;
        public string inicioLabores;
        public string permiso;
        public string empresa;
        public string departamentoPrincipal;
        public string horario;
        public string idDepa;
        public string idEmpresa;
        public void ObtenerUsuario(string user, string contrasena)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT u.idUsuario, u.nombre, u.puesto, u.vacaciones, u.contador, u.inicioLabores, u.permiso, e.nombre as empresa, u.idDepartamentoP from Usuario u inner join Empresa e on u.idEmpresa = e.idEmpresa where u.usuario = '{0}' AND u.contrasena = '{1}'", new string[] { user, contrasena }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            id = Convert.ToString(reader["idUsuario"]);
            nombre = Convert.ToString(reader["nombre"]);
            puesto = Convert.ToString(reader["puesto"]);
            dias = Convert.ToString(reader["vacaciones"]);
            contador = Convert.ToString(reader["contador"]);
            inicioLabores = Convert.ToString(reader["inicioLabores"]);
            permiso = Convert.ToString(reader["permiso"]);
            empresa = Convert.ToString(reader["empresa"]);
            departamentoPrincipal = Convert.ToString(reader["idDepartamentoP"]);
            reader.Close();
            conexion.Close();
        }
        public void ObtenerUsuarioXid(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select u.*, e.idEmpresa,e.nombre as empresa , h.nombre from Usuario u inner join Empresa e on u.idEmpresa = e.idEmpresa inner join horario h on u.horario = h.idHorario where u.idUsuario = {0}", new string[] { id }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            id = Convert.ToString(reader["idUsuario"]);
            nombre = Convert.ToString(reader["nombre"]);
            puesto = Convert.ToString(reader["puesto"]);
            dias = Convert.ToString(reader["vacaciones"]);
            contador = Convert.ToString(reader["contador"]);
            inicioLabores = Convert.ToString(reader["inicioLabores"]);
            permiso = Convert.ToString(reader["permiso"]);
            empresa = Convert.ToString(reader["empresa"]);
            idEmpresa = Convert.ToString(reader["idEmpresa"]);
            departamentoPrincipal = Convert.ToString(reader["idDepartamentoP"]);
            horario = Convert.ToString(reader["horario"]);
            reader.Close();
            conexion.Close();
        }

        public string nivel;
        public void ObtenerNivel(string idUsuario, string idDep)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select nivel from UsuarioDep where idUsuario = {0} and idDepartamento = {1}", new string[] { idUsuario, idDep }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            nivel = Convert.ToString(reader["nivel"]);
            reader.Close();
            conexion.Close();
        }

        public DataTable ObtenerMarcas()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select top 50 m.idMarca as ID, u.nombre as Usuario, d.nombre as Departamento, convert(varchar(10), m.hora, 103) as Fecha, convert(varchar(5), m.hora, 108) as Hora , t.nombreTipo as Tipo from Marca m inner join Usuario u on m.idUsuario = u.idUsuario inner join Tipo t on m.idTipo = t.idTipo inner join departamento d on u.idDepartamentoP = d.idDepartamento"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ObtenerMarcasPorFecha(string fechaInicial, string fechaFinal)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select m.idMarca as ID, u.nombre as Usuario, convert(varchar(10), m.hora, 103) as Fecha, convert(varchar(5), m.hora, 108) as Hora , t.nombreTipo from Marca m inner join Usuario u on m.idUsuario = u.idUsuario inner join Tipo t on m.idTipo = t.idTipo  where hora between convert(varchar(10), '{0}', 103) and convert(varchar(10), '{1}', 103)", new string[] { fechaInicial, fechaFinal}), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ObtenerMarcasPorID(string idUsuario)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select m.idMarca as ID, u.nombre as Usuario, convert(varchar(10), m.hora, 103) as Fecha, convert(varchar(5), m.hora, 108) as Hora , t.nombreTipo as Tipo from Marca m inner join Usuario u on m.idUsuario = u.idUsuario inner join Tipo t on m.idTipo = t.idTipo where u.idUsuario = {0}", new string[] { idUsuario }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool CrearVacacionesNivel2(string obs, 
            string fecha1, string desc1,
            string fecha2, string desc2,
            string fecha3, string desc3,
            string fecha4, string desc4,
            string fecha5, string desc5,
            string fecha6, string desc6,
            string fecha7, string desc7,
            string fecha8, string desc8,
            string fecha9, string desc9,
            string fecha10, string desc10, string idSolicitante, string idCreador, string idDepartamento, string total, int filas
            )
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8,fecha9, desc9,fecha10, desc10, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1,  desc1,fecha2,desc2,fecha3,  desc3,fecha4,  desc4,fecha5,  desc5,fecha6,  desc6,fecha7,  desc7,fecha8,  desc8,fecha9,  desc9,fecha10,  desc10,  idSolicitante,  idCreador,  idDepartamento,total }), conexion);

            SqlCommand cmd1 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', {21}, {22}, '{23}', 1, {24}); ", new string[] { obs,fecha1,  desc1,fecha2,  desc2,fecha3,  desc3,fecha4,  desc4,fecha5,  desc5,fecha6,  desc6,fecha7,  desc7,fecha8,  desc8,fecha9,  desc9,fecha10,  desc10,  idSolicitante,  idCreador,  idDepartamento,total }), conexion);

            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs,fecha1,  desc1,fecha2,  desc2,fecha3,  desc3,fecha4,  desc4,fecha5,  desc5,fecha6,  desc6,fecha7,  desc7,fecha8,  desc8,fecha9,  desc9,fecha10,  desc10,  idSolicitante,  idCreador,  idDepartamento,total }), conexion);

            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',{21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd4 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}', '{8}',{21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd5 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd6 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd7 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd8 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}','{15}','{16}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd9 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones2,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8,fecha9, desc9, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}','{15}','{16}','{17}','{18}', {21}, {22}, {23}, 1, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);
            int filasafectadas = 0;
            if (filas == 1)
            {
               filasafectadas = cmd1.ExecuteNonQuery();
            }
            else if (filas == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (filas == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            else if (filas == 4)
            {
                filasafectadas = cmd4.ExecuteNonQuery();
            }
            else if (filas == 5)
            {
                filasafectadas = cmd5.ExecuteNonQuery();
            }
            else if (filas == 6)
            {
                filasafectadas = cmd6.ExecuteNonQuery();
            }
            else if (filas == 7)
            {
                filasafectadas = cmd7.ExecuteNonQuery();
            }
            else if (filas == 8)
            {
                filasafectadas = cmd8.ExecuteNonQuery();
            }
            else if (filas == 9)
            {
                filasafectadas = cmd9.ExecuteNonQuery();
            }
            else if (filas == 10)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }


            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool CrearVacacionesNivel3(string obs,
    string fecha1, string desc1,
    string fecha2, string desc2,
    string fecha3, string desc3,
    string fecha4, string desc4,
    string fecha5, string desc5,
    string fecha6, string desc6,
    string fecha7, string desc7,
    string fecha8, string desc8,
    string fecha9, string desc9,
    string fecha10, string desc10, string idSolicitante, string idCreador, string idDepartamento, string total, int filas
    )
        {
            conexion.Open();
            

            SqlCommand cmd1 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', {21}, {22}, '{23}', 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',{21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd4 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}', '{8}',{21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd5 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd6 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd7 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd8 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}','{15}','{16}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd9 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8,fecha9, desc9, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}','{15}','{16}','{17}','{18}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones3,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8,fecha9, desc9,fecha10, desc10, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', {21}, {22}, {23}, 2, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);
            int filasafectadas = 0;
            if (filas == 1)
            {
                filasafectadas = cmd1.ExecuteNonQuery();
            }
            else if (filas == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (filas == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            else if (filas == 4)
            {
                filasafectadas = cmd4.ExecuteNonQuery();
            }
            else if (filas == 5)
            {
                filasafectadas = cmd5.ExecuteNonQuery();
            }
            else if (filas == 6)
            {
                filasafectadas = cmd6.ExecuteNonQuery();
            }
            else if (filas == 7)
            {
                filasafectadas = cmd7.ExecuteNonQuery();
            }
            else if (filas == 8)
            {
                filasafectadas = cmd8.ExecuteNonQuery();
            }
            else if (filas == 9)
            {
                filasafectadas = cmd9.ExecuteNonQuery();
            }
            else if (filas == 10)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }


            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool CrearVacacionesNivel4(string obs,
            string fecha1, string desc1,
            string fecha2, string desc2,
            string fecha3, string desc3,
            string fecha4, string desc4,
            string fecha5, string desc5,
            string fecha6, string desc6,
            string fecha7, string desc7,
            string fecha8, string desc8,
            string fecha9, string desc9,
            string fecha10, string desc10, string idSolicitante, string idCreador, string idDepartamento, string total, int filas
        )
        {
            conexion.Open();
            SqlCommand cmd1 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', {21}, {22}, '{23}', 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',{21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd4 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}', '{8}',{21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd5 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd6 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd7 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd8 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}','{15}','{16}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd9 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4,fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8,fecha9, desc9, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}', '{12}','{13}','{14}','{15}','{16}','{17}','{18}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);

            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaVacaciones(correlativo, fechaSolicitud, observaciones4, fecha1, desc1,fecha2, desc2,fecha3, desc3,fecha4, desc4,fecha5, desc5,fecha6, desc6,fecha7, desc7,fecha8, desc8,fecha9, desc9,fecha10, desc10, idSolicitante, idCreador, idDepartamento, idEstado,totalD) values ((SELECT ISNULL(MAX(correlativo), 0) + 1 FROM BoletaVacaciones), GETDATE(), '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', {21}, {22}, {23}, 3, {24}); ", new string[] { obs, fecha1, desc1, fecha2, desc2, fecha3, desc3, fecha4, desc4, fecha5, desc5, fecha6, desc6, fecha7, desc7, fecha8, desc8, fecha9, desc9, fecha10, desc10, idSolicitante, idCreador, idDepartamento, total }), conexion);
            int filasafectadas = 0;
            if (filas == 1)
            {
                filasafectadas = cmd1.ExecuteNonQuery();
            }
            else if (filas == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (filas == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            else if (filas == 4)
            {
                filasafectadas = cmd4.ExecuteNonQuery();
            }
            else if (filas == 5)
            {
                filasafectadas = cmd5.ExecuteNonQuery();
            }
            else if (filas == 6)
            {
                filasafectadas = cmd6.ExecuteNonQuery();
            }
            else if (filas == 7)
            {
                filasafectadas = cmd7.ExecuteNonQuery();
            }
            else if (filas == 8)
            {
                filasafectadas = cmd8.ExecuteNonQuery();
            }
            else if (filas == 9)
            {
                filasafectadas = cmd9.ExecuteNonQuery();
            }
            else if (filas == 10)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }


            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public DataTable MostrarHorarios()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select *from hora order by valor"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarUsuarios()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select * from Usuario order by nombre"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarEmpresas()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select *from Empresa"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool CrearReposicion(string obs, string fecha1, string horaI1, string horaF1,string fecha2, string horaI2, string horaF2,string fecha3, string horaI3, string horaF3,string fecha4, string horaI4, string horaF4,string fecha5, string horaI5, string horaF5,string fecha1R, string horaI1R, string horaF1R,string fecha2R, string horaI2R, string horaF2R,string fecha3R, string horaI3R, string horaF3R,string fecha4R, string horaI4R, string horaF4R,string fecha5R, string horaI5R, string horaF5R,string totalH, string totalHR, string idSolicitante, string idDepartamento,string desc1,string desc2,string desc3,string desc4,string desc5,string desc6,string desc7,string desc8,string desc9,string desc10,int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaReposicion(correlativo, fechaSolicitud, observaciones2, fecha1,horai1,horaf1,fecha2,horai2,horaf2,fecha3,horai3,horaf3,fecha4,horai4,horaf4,fecha5,horai5,horaf5,fecha1R,horai1R,horaf1R,fecha2R,horai2R,horaf2R,fecha3R,horai3R,horaf3R,fecha4R,horai4R,horaf4R,fecha5R,horai5R,horaf5R,totalH, totalHR, idSolicitante, idCreador, idDepartamento, desc1A,desc2A,desc3A,desc4A,desc5A,desc1R,desc2R,desc3R,desc4R,desc5R,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaReposicion), GETDATE(),'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}',{8},{9},'{10}',{11},{12},'{13}',{14},{15},'{16}',{17},{18},'{19}',{20},{21},'{22}',{23},{24},'{25}',{26},{27},'{28}',{29},{30}, {31}, {32},{33}, {33}, {34},'{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}',1);", new string[] { obs, fecha1, horaI1, horaF1, fecha2, horaI2, horaF2, fecha3, horaI3, horaF3, fecha4, horaI4, horaF4, fecha5, horaI5, horaF5, fecha1R, horaI1R, horaF1R, fecha2R, horaI2R, horaF2R, fecha3R, horaI3R, horaF3R, fecha4R, horaI4R, horaF4R, fecha5R, horaI5R, horaF5R, totalH, totalHR, idSolicitante, idDepartamento, desc1, desc2, desc3, desc4, desc5, desc6, desc7, desc8, desc9, desc10 }), conexion);

            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaReposicion(correlativo, fechaSolicitud, observaciones3, fecha1,horai1,horaf1,fecha2,horai2,horaf2,fecha3,horai3,horaf3,fecha4,horai4,horaf4,fecha5,horai5,horaf5,fecha1R,horai1R,horaf1R,fecha2R,horai2R,horaf2R,fecha3R,horai3R,horaf3R,fecha4R,horai4R,horaf4R,fecha5R,horai5R,horaf5R,totalH, totalHR, idSolicitante, idCreador, idDepartamento, desc1A,desc2A,desc3A,desc4A,desc5A,desc1R,desc2R,desc3R,desc4R,desc5R,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaReposicion), GETDATE(),'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}',{8},{9},'{10}',{11},{12},'{13}',{14},{15},'{16}',{17},{18},'{19}',{20},{21},'{22}',{23},{24},'{25}',{26},{27},'{28}',{29},{30}, {31}, {32},{33}, {33}, {34},'{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}',2);", new string[] { obs, fecha1, horaI1, horaF1, fecha2, horaI2, horaF2, fecha3, horaI3, horaF3, fecha4, horaI4, horaF4, fecha5, horaI5, horaF5, fecha1R, horaI1R, horaF1R, fecha2R, horaI2R, horaF2R, fecha3R, horaI3R, horaF3R, fecha4R, horaI4R, horaF4R, fecha5R, horaI5R, horaF5R, totalH, totalHR, idSolicitante, idDepartamento, desc1, desc2, desc3, desc4, desc5, desc6, desc7, desc8, desc9, desc10 }), conexion);

            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaReposicion(correlativo, fechaSolicitud, observaciones4, fecha1,horai1,horaf1,fecha2,horai2,horaf2,fecha3,horai3,horaf3,fecha4,horai4,horaf4,fecha5,horai5,horaf5,fecha1R,horai1R,horaf1R,fecha2R,horai2R,horaf2R,fecha3R,horai3R,horaf3R,fecha4R,horai4R,horaf4R,fecha5R,horai5R,horaf5R,totalH, totalHR, idSolicitante, idCreador, idDepartamento, desc1A,desc2A,desc3A,desc4A,desc5A,desc1R,desc2R,desc3R,desc4R,desc5R,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaReposicion), GETDATE(),'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}',{8},{9},'{10}',{11},{12},'{13}',{14},{15},'{16}',{17},{18},'{19}',{20},{21},'{22}',{23},{24},'{25}',{26},{27},'{28}',{29},{30}, {31}, {32},{33}, {33}, {34},'{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}',3);", new string[] { obs, fecha1, horaI1, horaF1, fecha2, horaI2, horaF2, fecha3, horaI3, horaF3, fecha4, horaI4, horaF4, fecha5, horaI5, horaF5, fecha1R, horaI1R, horaF1R, fecha2R, horaI2R, horaF2R, fecha3R, horaI3R, horaF3R, fecha4R, horaI4R, horaF4R, fecha5R, horaI5R, horaF5R, totalH, totalHR, idSolicitante, idDepartamento, desc1, desc2, desc3, desc4, desc5, desc6, desc7, desc8, desc9, desc10 }), conexion);

            int filasafectadas = 0;
            if (Nivel == 2)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }else if (Nivel == 3)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            } else if(Nivel == 4)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }                  
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool CrearConsultaIgss(string obs, string fecha1, string horaI1, string horaF1, string desc, string totalH, string idSolicitante, string idDepartamento, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaConsultaIGSS(correlativo, fechaSolicitud, observaciones2, fecha1, horaI1, horaF1, desc1, totalH, idsolicitante, idCreador, idDepartamento, idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaConsultaIGSS), GETDATE(), '{0}','{1}',{2},{3},'{4}',{5},{6},{6},{7},1)", new string[] { obs, fecha1, horaI1, horaF1,desc, totalH, idSolicitante, idDepartamento}), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaConsultaIGSS(correlativo, fechaSolicitud, observaciones3, fecha1, horaI1, horaF1, desc1, totalH, idsolicitante, idCreador, idDepartamento, idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaConsultaIGSS), GETDATE(), '{0}','{1}',{2},{3},'{4}',{5},{6},{6},{7},2)", new string[] { obs, fecha1, horaI1, horaF1, desc, totalH, idSolicitante, idDepartamento }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaConsultaIGSS(correlativo, fechaSolicitud, observaciones4, fecha1, horaI1, horaF1, desc1, totalH, idsolicitante, idCreador, idDepartamento, idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaConsultaIGSS), GETDATE(), '{0}','{1}',{2},{3},'{4}',{5},{6},{6},{7},3)", new string[] { obs, fecha1, horaI1, horaF1, desc, totalH, idSolicitante, idDepartamento }), conexion);



            int filasafectadas = 0;
            if (Nivel == 2)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 4)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool CrearSuspensionIgss(string obs, string fechaI, string fechaF, string idSolicitante, string idDepartamento,string totalD, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; Insert into BoletaSuspencionIGSS(correlativo, fechaSolicitud, observaciones2, fechaInicio, fechaFinal,idSolicitante,idCreador,idDepartamento,totalD,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaSuspencionIGSS), GETDATE(), '{0}','{1}','{2}',{3},{3},{4},{5},1);", new string[] {  obs,  fechaI,  fechaF,  idSolicitante,  idDepartamento,  totalD }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; Insert into BoletaSuspencionIGSS(correlativo, fechaSolicitud, observaciones3, fechaInicio, fechaFinal,idSolicitante,idCreador,idDepartamento,totalD,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaSuspencionIGSS), GETDATE(), '{0}','{1}','{2}',{3},{3},{4},{5},2);", new string[] { obs, fechaI, fechaF, idSolicitante, idDepartamento, totalD }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; Insert into BoletaSuspencionIGSS(correlativo, fechaSolicitud, observaciones4, fechaInicio, fechaFinal,idSolicitante,idCreador,idDepartamento,totalD,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaSuspencionIGSS), GETDATE(), '{0}','{1}','{2}',{3},{3},{4},{5},3);", new string[] { obs, fechaI, fechaF, idSolicitante, idDepartamento, totalD }), conexion);

            int filasafectadas = 0;
            if (Nivel == 2)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 4)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool CrearEspecial(string obs, string fecha1, string horaI1, string horaF1,string fecha2, string horaI2, string horaF2,string fecha3, string horaI3, string horaF3,string fecha4, string horaI4, string horaF4,string fecha5, string horaI5, string horaF5,string desc1,string desc2,string desc3,string desc4,string desc5,string totalH, string idSolicitante, string idDepartamento,  int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaEspecial (correlativo, fechaSolicitud, observaciones2,fecha1,horaI1,horaF1,fecha2,horaI2,horaF2,fecha3,horaI3,horaF3,fecha4,horaI4,horaF4,fecha5,horaI5,horaF5,desc1A,desc2A,desc3A,desc4A,desc5A,totalH,idSolicitante,idCreador,idDepartamento,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaEspecial), GETDATE(),'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}',{8},{9},'{10}',{11},{12},'{13}',{14},{15},'{16}','{17}','{18}','{19}','{20}',{21},{22},{22},{23},1);", new string[] { obs, fecha1, horaI1, horaF1, fecha2, horaI2, horaF2, fecha3, horaI3, horaF3, fecha4, horaI4, horaF4, fecha5, horaI5, horaF5, desc1, desc2, desc3, desc4, desc5, totalH, idSolicitante, idDepartamento }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaEspecial (correlativo, fechaSolicitud, observaciones3,fecha1,horaI1,horaF1,fecha2,horaI2,horaF2,fecha3,horaI3,horaF3,fecha4,horaI4,horaF4,fecha5,horaI5,horaF5,desc1A,desc2A,desc3A,desc4A,desc5A,totalH,idSolicitante,idCreador,idDepartamento,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaEspecial), GETDATE(),'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}',{8},{9},'{10}',{11},{12},'{13}',{14},{15},'{16}','{17}','{18}','{19}','{20}',{21},{22},{22},{23},2);", new string[] { obs, fecha1, horaI1, horaF1, fecha2, horaI2, horaF2, fecha3, horaI3, horaF3, fecha4, horaI4, horaF4, fecha5, horaI5, horaF5, desc1, desc2, desc3, desc4, desc5, totalH, idSolicitante, idDepartamento }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaEspecial (correlativo, fechaSolicitud, observaciones4,fecha1,horaI1,horaF1,fecha2,horaI2,horaF2,fecha3,horaI3,horaF3,fecha4,horaI4,horaF4,fecha5,horaI5,horaF5,desc1A,desc2A,desc3A,desc4A,desc5A,totalH,idSolicitante,idCreador,idDepartamento,idEstado) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaEspecial), GETDATE(),'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}',{8},{9},'{10}',{11},{12},'{13}',{14},{15},'{16}','{17}','{18}','{19}','{20}',{21},{22},{22},{23},3);", new string[] { obs, fecha1, horaI1, horaF1, fecha2, horaI2, horaF2, fecha3, horaI3, horaF3, fecha4, horaI4, horaF4, fecha5, horaI5, horaF5, desc1, desc2, desc3, desc4, desc5, totalH, idSolicitante, idDepartamento }), conexion);

            int filasafectadas = 0;
            if (Nivel == 2)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 4)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool CrearSansion(string obs, string fecha1, string fecha2, string fecha3, string fecha4, string fecha5, string fecha6, string fecha7, string fecha8, string fecha9, string fecha10, string totalD, string idSolicitante, string idDepartamento, int Nivel, string tipo)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaSancion(correlativo, fechaSolicitud, observaciones2,fecha1,fecha2,fecha3,fecha4,fecha5,fecha6,fecha7,fecha8,fecha9,fecha10,totalD,idSolicitante,idCreador,idDepartamento,idEstado,tipo) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaSancion), GETDATE(), '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},{12},{13},1,'{14}')", new string[] { obs, fecha1, fecha2, fecha3, fecha4, fecha5, fecha6, fecha7, fecha8, fecha9, fecha10, totalD, idSolicitante, idDepartamento, tipo }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaSancion(correlativo, fechaSolicitud, observaciones3,fecha1,fecha2,fecha3,fecha4,fecha5,fecha6,fecha7,fecha8,fecha9,fecha10,totalD,idSolicitante,idCreador,idDepartamento,idEstado,tipo) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaSancion), GETDATE(), '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},{12},{13},2,'{14}')", new string[] { obs, fecha1, fecha2, fecha3, fecha4, fecha5, fecha6, fecha7, fecha8, fecha9, fecha10, totalD, idSolicitante, idDepartamento, tipo }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into BoletaSancion(correlativo, fechaSolicitud, observaciones4,fecha1,fecha2,fecha3,fecha4,fecha5,fecha6,fecha7,fecha8,fecha9,fecha10,totalD,idSolicitante,idCreador,idDepartamento,idEstado,tipo) values ((SELECT ISNULL(MAX(correlativo),0) + 1 FROM BoletaSancion), GETDATE(), '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},{12},{13},3,'{14}')", new string[] { obs, fecha1, fecha2, fecha3, fecha4, fecha5, fecha6, fecha7, fecha8, fecha9, fecha10, totalD, idSolicitante, idDepartamento, tipo }), conexion);

            int filasafectadas = 0;
            if (Nivel == 2)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 4)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public DataTable MostrarVacaciones(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, e.nombre as Estado from BoletaVacaciones b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0}", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarPendientesVacaciones(string dep,string nivel)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, u.nombre as Solicitante,b.totalD as DíasSolicitados, e.nombre as Estado from BoletaVacaciones b inner join Estado e on b.idEstado = e.idEstado inner join Usuario u on b.idSolicitante = u.idUsuario where b.idDepartamento = {0} and b.idEstado = {1}", new string[] { dep, nivel }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarReposiciones(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.totalH as HorasSolicitadas,  e.nombre as Estado from BoletaReposicion b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0}", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarPendientesReposiciones(string dep, string nivel)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,u.nombre as Solicitante,b.totalH as HorasSolicitadas,  e.nombre as Estado from BoletaReposicion b inner join Estado e on b.idEstado = e.idEstado inner join Usuario u on b.idSolicitante = u.idUsuario where b.idDepartamento = {0} and b.idEstado = {1}", new string[] { dep, nivel }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarEspeciales(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalH as HorasSolicitadas, e.nombre as Estado from BoletaEspecial b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0}", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarPendientesEspeciales(string dep, string nivel)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,u.nombre as Solicitante, b.totalH as HorasSolicitadas, e.nombre as Estado from BoletaEspecial b inner join Estado e on b.idEstado = e.idEstado inner join Usuario u on b.idSolicitante = u.idUsuario where b.idDepartamento = {0} and b.idEstado = {1} OR b.idEstado = 8", new string[] { dep, nivel }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarConsultasIGGS(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalH as HorasSolicitadas, e.nombre as Estado from BoletaConsultaIGSS b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0}", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarPendientesConsultasIGGS(string dep, string nivel)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,u.nombre as Solicitante, b.totalH as HorasSolicitadas,e.nombre as Estado from BoletaConsultaIGSS b inner join Estado e on b.idEstado = e.idEstado inner join Usuario u on b.idSolicitante = u.idUsuario where b.idDepartamento = {0} and b.idEstado = {1}", new string[] { dep, nivel }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarSuspencionesIGGS(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalD as DíasDeSuspensión, e.nombre as Estado from BoletaSuspencionIGSS b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0}", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarPendientesSuspencionesIGGS(string dep, string nivel)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,u.nombre as Solicitante, b.totalD as DíasDeSuspensión, e.nombre as Estado from BoletaSuspencionIGSS b inner join Estado e on b.idEstado = e.idEstado inner join Usuario u on b.idSolicitante = u.idUsuario where b.idDepartamento = {0} and b.idEstado = {1}", new string[] { dep, nivel }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarSanciones(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta,b.tipo as Tipo, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalD as DíasDeSanción, e.nombre as Estado from BoletaSancion b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0}", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarPendientesSanciones(string dep, string nivel)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select b.idBoleta,b.tipo as Tipo, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,u.nombre as Solicitante, b.totalD as DíasDeSanción, e.nombre as Estado from BoletaSancion b inner join Estado e on b.idEstado = e.idEstado inner join Usuario u on b.idSolicitante = u.idUsuario where b.idDepartamento = {0} and b.idEstado = {1}", new string[] { dep, nivel }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
       
        public void BuscarUsuario(string idU)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT u.idUsuario, u.nombre, u.puesto, u.vacaciones, u.contador, u.inicioLabores, u.permiso, e.nombre as empresa, u.idDepartamentoP from Usuario u inner join Empresa e on u.idEmpresa = e.idEmpresa where u.idUsuario = {0}", new string[] { idU }), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            id = Convert.ToString(reader["idUsuario"]);
            nombre = Convert.ToString(reader["nombre"]);
            puesto = Convert.ToString(reader["puesto"]);
            dias = Convert.ToString(reader["vacaciones"]);
            contador = Convert.ToString(reader["contador"]);
            inicioLabores = Convert.ToString(reader["inicioLabores"]);
            permiso = Convert.ToString(reader["permiso"]);
            empresa = Convert.ToString(reader["empresa"]);
            departamentoPrincipal = Convert.ToString(reader["idDepartamentoP"]);
            reader.Close();
            conexion.Close();
        }

        public bool AutorizarVacaciones(string obs,string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones1 = '{0}', idGerente = {1}, idEstado = 9 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones2 = '{0}', idJefe = {1}, idEstado = 1 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones3 = '{0}', idEstado = 2 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool enviaraGGVacaciones(string obs, string idUser, string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones1 = '{0}', idGerente = {1}, idEstado = 8 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool DenegarVacaciones(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones1 = '{0}', idGerente = {1}, idEstado = 10 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones2 = '{0}', idJefe = {1}, idEstado = 6 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET observaciones3 = '{0}', idEstado = 7 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarReposicion(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones1 = '{0}', idGerente = {1}, idEstado = 9 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones2 = '{0}', idJefe = {1}, idEstado = 1 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones3 = '{0}', idEstado = 2 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool enviaraGGReposicion(string obs, string idUser, string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones1 = '{0}', idGerente = {1}, idEstado = 8 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool DenegarReposicion(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones1 = '{0}', idGerente = {1}, idEstado = 10 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones2 = '{0}', idJefe = {1}, idEstado = 6 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaReposicion SET observaciones3 = '{0}', idEstado = 7 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool AutorizarConsultaIGSS(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones1 = '{0}', idGerente = {1}, idEstado = 9 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones2 = '{0}', idJefe = {1}, idEstado = 1 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones3 = '{0}', idEstado = 2 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool enviaraGGConsultaIGSS(string obs, string idUser, string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones1 = '{0}', idGerente = {1}, idEstado = 8 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool DenegarConsultaIGSS(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones1 = '{0}', idGerente = {1}, idEstado = 10 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones2 = '{0}', idJefe = {1}, idEstado = 6 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET observaciones3 = '{0}', idEstado = 7 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarSuspencionIGSS(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones1 = '{0}', idGerente = {1}, idEstado = 9 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones2 = '{0}', idJefe = {1}, idEstado = 1 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones3 = '{0}', idEstado = 2 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool enviaraGGSuspencionIGSS(string obs, string idUser, string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones1 = '{0}', idGerente = {1}, idEstado = 8 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool DenegarSuspencionIGSS(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones1 = '{0}', idGerente = {1}, idEstado = 10 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones2 = '{0}', idJefe = {1}, idEstado = 6 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET observaciones3 = '{0}', idEstado = 7 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarEspecial(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones1 = '{0}', idGerente = {1}, idEstado = 9 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones2 = '{0}', idJefe = {1}, idEstado = 1 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones3 = '{0}', idEstado = 2 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool enviaraGGEspecial(string obs, string idUser, string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones1 = '{0}', idGerente = {1}, idEstado = 8 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool DenegarEspecial(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones1 = '{0}', idGerente = {1}, idEstado = 10 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones2 = '{0}', idJefe = {1}, idEstado = 6 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaEspecial SET observaciones3 = '{0}', idEstado = 7 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool AutorizarSansion(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones1 = '{0}', idGerente = {1}, idEstado = 9 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones2 = '{0}', idJefe = {1}, idEstado = 1 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones3 = '{0}', idEstado = 2 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
        public bool enviaraGGSansion(string obs, string idUser, string idBoleta)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones1 = '{0}', idGerente = {1}, idEstado = 8 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool DenegarSansion(string obs, string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones1 = '{0}', idGerente = {1}, idEstado = 10 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones2 = '{0}', idJefe = {1}, idEstado = 6 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaSancion SET observaciones3 = '{0}', idEstado = 7 WHERE idBoleta = {2};", new string[] { obs, idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarVacacionesM(string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET  idGerente = {0}, idEstado = 9 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET  idJefe = {0}, idEstado = 1 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaVacaciones SET idEstado = 2 WHERE idBoleta IN ({1});", new string[] { idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }


        public bool AutorizarReposicionM( string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();           
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaReposicion SET idGerente = {0}, idEstado = 9 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaReposicion SET  idJefe = {0}, idEstado = 1 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaReposicion SET idEstado = 2 WHERE idBoleta IN ({1});", new string[] { idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarConsultaIGSSM( string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET  idGerente = {0}, idEstado = 9 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET  idJefe = {0}, idEstado = 1 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaConsultaIGSS SET idEstado = 2 WHERE idBoleta IN ({1});", new string[] { idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarSuspencionIGSSM( string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET idGerente = {0}, idEstado = 9 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET  idJefe = {0}, idEstado = 1 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaSuspencionIGSS SET idEstado = 2 WHERE idBoleta IN ({1});", new string[] { idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarEspecialM(string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();           
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaEspecial SET idGerente = {0}, idEstado = 9 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaEspecial SET  idJefe = {0}, idEstado = 1 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaEspecial SET idEstado = 2 WHERE idBoleta IN ({1});", new string[] { idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AutorizarSansionM( string idUser, string idBoleta, int Nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE BoletaSancion SET idGerente = {0}, idEstado = 9 WHERE idBoleta in ({1});", new string[] { idUser, idBoleta }), conexion);
            SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE BoletaSancion SET  idJefe = {0}, idEstado = 1 WHERE idBoleta in ({1});", new string[] {  idUser, idBoleta }), conexion);
            SqlCommand cmd3 = new SqlCommand(string.Format("UPDATE BoletaSancion SET idEstado = 2 WHERE idBoleta IN ({1});", new string[] {  idUser, idBoleta }), conexion);

            int filasafectadas = 0;
            if (Nivel == 1)
            {
                filasafectadas = cmd.ExecuteNonQuery();
            }
            else if (Nivel == 2)
            {
                filasafectadas = cmd2.ExecuteNonQuery();
            }
            else if (Nivel == 3)
            {
                filasafectadas = cmd3.ExecuteNonQuery();
            }
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public DataTable MostrarDepartamentos()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select *from departamento order by nombre"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarHorarioAsignado()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select * from horario order by nombre"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }



        public bool RestarVacaciones(string dias, string idUser)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("update usuario set vacaciones = (vacaciones - {0}) where idUsuario = {1}", new string[] { dias, idUser }), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }


        public DataTable VacacionesOpcion1(string id, string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalD as DíasSolicitados, e.nombre as Estado from BoletaVacaciones b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0} and b.fechaSolicitud between '{1}' and '{2}'", new string[] { id, f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionesRangoFechas(string id, string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalH as HorasSolicitadas, e.nombre as Estado from BoletaReposicion b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0} and b.fechaSolicitud between '{1}' and '{2}'", new string[] { id, f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialesRangoFechas(string id, string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalH as HorasSolicitadas, e.nombre as Estado from BoletaEspecial b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0} and b.fechaSolicitud between '{1}' and '{2}'", new string[] { id, f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ConsultasRangoFechas(string id, string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalH as HorasSolicitadas, e.nombre as Estado from BoletaConsultaIGSS b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0} and b.fechaSolicitud between '{1}' and '{2}'", new string[] { id, f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable SuspensionesRangoFechas(string id, string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalD as DíasDeSuspensión, e.nombre as Estado from BoletaSuspencionIGSS b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0} and b.fechaSolicitud between '{1}' and '{2}'", new string[] { id, f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable SancionesRangoFechas(string id, string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; select b.idBoleta, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación, b.totalD as DíasDeSanción, e.nombre as Estado from BoletaSancion b inner join Estado e on b.idEstado = e.idEstado where b.idCreador = {0} and b.fechaSolicitud between '{1}' and '{2}'", new string[] { id, f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }


        public DataTable MostrarEstados()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select * from estado order by nombre"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable ObetenerDepartamentos()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select * from Departamento order by nombre"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarEmpleados(string idDepartamento)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select *from Usuario where idDepartamentoP = {0}", new string[] { idDepartamento }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable MostrarDias(string horario)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select d.nombre as Dia, d.entrada, d.salida from dia d where horario = {0}", new string[] { horario }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable VacacionesOp0()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) =  MONTH(GETDATE()) and YEAR(b.fechaSolicitud) = YEAR(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable VacacionesOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable VacacionesOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable VacacionesOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable VacacionesOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2,user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable VacacionesOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2,user,estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable VacacionesOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarVacaciones(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, totalD as DíasSolitados, e.nombre as Estado FROM BoletaVacaciones b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id}), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        //------Rep

        public DataTable ReposicionOp0()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) = MONTH(GETDATE()) and YEAR(b.fechaSolicitud) = YEAR(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOpEngaño()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) = MONTH(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionEngañoOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}'", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionEngañoOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionEngañoOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionEngañoOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionEngañoOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReposicionEngañoOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarReposicion(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarReposicionEngaño(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación' , u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5', nullif(b.fecha1R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 1', nullif(b.fecha2R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 2', nullif(b.fecha3R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 3', nullif(b.fecha4R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 4', nullif(b.fecha5R , '2000-01-01 00:00:00:000') as 'Fecha Reposición 5' FROM BoletaReposicion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        //------Esp

        public DataTable EspecialOp0()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) =  MONTH(GETDATE()) and YEAR(b.fechaSolicitud) =  YEAR(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngaño()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) = MONTH(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngañoOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngañoOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngañoOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngañoOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngañoOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable EspecialEngañoOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarEspecial(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarEspecialEngaño(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) 'Fecha De Creación', u.nombre as 'Solicitante', d.nombre as 'Departamento', b.totalH as 'Horas Solicitadas', e.nombre as 'Estado', nullif(b.fecha1 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 1', nullif(b.fecha2 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 2', nullif(b.fecha3 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 3', nullif(b.fecha4 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 4', nullif(b.fecha5 , '2000-01-01 00:00:00:000') as 'Fecha Ausencia 5' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        //------consultaIGGS

        public DataTable ConsultaOp0()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia, b.horaI1 as HoraInicial, b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) =  MONTH(GETDATE()) AND YEAR(b.fechaSolicitud) = YEAR(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ConsultaOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable ConsultaOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ConsultaOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable ConsultaOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable ConsultaOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ConsultaOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarConsulta(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fecha1, 103) as FechaDeAusencia,b.horaI1 as HoraInicial,  b.horaF1 as HoraFinal, b.totalH as HorasSolicitadas, e.nombre as Estado FROM BoletaConsultaIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        //------suspension

        public DataTable suspensionOp0()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) =  MONTH(GETDATE()) AND YEAR(b.fechaSolicitud) = YEAR(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable suspensionOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable suspensionOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable suspensionOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable suspensionOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable suspensionOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable suspensionOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarSuspension(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento,CONVERT(VARCHAR(10), b.fechaInicio, 103) as FechaInicial,CONVERT(VARCHAR(10), b.fechaFinal, 103) as FechaFinal,b.totalD as TotalDías, e.nombre as Estado FROM BoletaSuspencionIGSS b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        //------sancion

        public DataTable sancionOp0()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE MONTH(b.fechaSolicitud) =  MONTH(GETDATE()) AND YEAR(b.fechaSolicitud) = YEAR(GETDATE())"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable sancionOp1(string f1, string f2)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2 }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable sancionOp2(string f1, string f2, string dep)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and  b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable sancionOp3(string f1, string f2, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idEstado = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable sancionOp4(string f1, string f2, string user)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable sancionOp5(string f1, string f2, string user, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idSolicitante = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, user, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable sancionOp6(string f1, string f2, string dep, string estado)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idDepartamento = {2} and b.idEstado = {3} and b.fechaSolicitud between '{0}' and '{1}' ", new string[] { f1, f2, dep, estado }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable BuscarSancion(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) as FechaDeCreación,b.tipo as Tipo, u.nombre as Solicitante, d.nombre as Departamento, b.totalD as TotalDías, e.nombre as Estado FROM BoletaSancion b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado WHERE b.idBoleta like '{0}%' ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ObtenerDepartamento(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select u.idUsuario as ID, u.nombre,u.vacaciones, ud.nivel, h.nombre as Horario from UsuarioDep ud inner join Usuario u on ud.idUsuario = u.idUsuario inner join horario h on u.horario = h.idHorario where ud.idDepartamento = {0} order by ud.nivel  ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }
        public DataTable ObtenerDepartamentosXId(string id)
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select ud.idUsuarioDep as ID,u.nombre,d.nombre as Departemento, ud.nivel, h.nombre as Horario from UsuarioDep ud inner join Usuario u on ud.idUsuario = u.idUsuario inner join Departamento d on ud.idDepartamento = d.idDepartamento inner join horario h on u.horario = h.idHorario where ud.idUsuario = {0} ", new string[] { id }), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public bool CrearEmpleado(string usuario, string nombre, string contrasena, string puesto, string vacaciones, string fecha, string idEmpresa, string idDepartamentoP)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; insert into Usuario (usuario, nombre, contrasena, puesto, vacaciones, contador, inicioLabores,idEmpresa,idDepartamentoP) values ('{0}','{1}','{2}','{3}','{4}',0.00, '{5}', {6},{7})", new string[] {  usuario,  nombre,  contrasena,  puesto,  vacaciones,  fecha,  idEmpresa,  idDepartamentoP }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool EditarEmpleado(string nombre, string puesto,  string idEmpresa,  string fecha, string vacaciones, string idDepartamentoP, string id, string horario)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SET LANGUAGE SPANISH; UPDATE Usuario SET nombre = '{0}', puesto = '{1}', idEmpresa = {2}, inicioLabores = '{3}',vacaciones = {4}, idDepartamentoP = {5}, horario = {7} WHERE idUsuario = {6}", new string[] {  nombre,  puesto,  idEmpresa,  fecha,  vacaciones,  idDepartamentoP,  id, horario }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool AumentarVacaciones()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE Usuario SET vacaciones = vacaciones + 1.25"), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }


        public string ultimo;
        public void ObtenerUltimoId()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT MAX(idUsuario) AS id FROM Usuario"), conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ultimo = Convert.ToString(reader["id"]);
            reader.Close();
            conexion.Close();
        }

        public bool RegistrarEmpleado(string usuario, string depa, string nivel)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into UsuarioDep (idUsuario, idDepartamento, nivel) values ({0},{1},{2})", new string[] { usuario, depa,nivel  }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }


        public bool EliminarRegistro(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("Delete from UsuarioDep where idUsuarioDep = {0}", new string[] { id }), conexion);
            int filasafectadas = 0;
            filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }


        //reportes nuevos
        public DataTable ReporteVacaciones()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("select u.idUsuario as ID, u.nombre,u.vacaciones,d.nombre as Departamento, ud.nivel  from UsuarioDep ud inner join Usuario u on ud.idUsuario = u.idUsuario inner join departamento d on ud.idDepartamento = d.idDepartamento order by ud.nivel"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public DataTable ReporteFaltasJustificadas()
        {
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(string.Format("SET LANGUAGE SPANISH; SELECT b.idBoleta as ID, CONVERT(VARCHAR(10), b.fechaSolicitud, 103) FechaDeCreación , u.nombre as Solicitante, d.nombre as Departamento, b.totalH as 'Horas Solicitadas', e.nombre as Estado, b.fecha1 as 'Fecha Ausencia 1', b.fecha2 as 'Fecha Ausencia 2', b.fecha3 as 'Fecha Ausencia 3', b.fecha4 as 'Fecha Ausencia 4', b.fecha5 as 'Fecha Ausencia 5', b.observaciones1 as 'Comentarios Gerente / Jefe de área', b.observaciones2 as 'Comentarios subalterno' FROM BoletaEspecial b inner join Usuario u on b.idSolicitante = u.idUsuario inner join departamento d on d.idDepartamento = b.idDepartamento inner join Estado e on b.idEstado = e.idEstado order by ID desc"), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd2);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

    }
}
