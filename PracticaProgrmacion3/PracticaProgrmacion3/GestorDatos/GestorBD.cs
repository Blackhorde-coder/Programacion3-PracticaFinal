using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PracticaProgrmacion3.Models;

namespace PracticaProgrmacion3.GestorDatos
{
    public class GestorBD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public GestorBD()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            dr = null;
        }

        public List<Tipo> ListaTipos()
        {
            List<Tipo> lista = new List<Tipo>();

            string consultasql = "select * from tipos";
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            con.Open();
            cmd =new SqlCommand(consultasql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tipo = new Tipo();
                tipo.Idtipo = int.Parse(dr["idTipo"].ToString());
                tipo.Nombre = dr["nombre"].ToString();
                tipo.Precio = double.Parse(dr["precio"].ToString());
                lista.Add(tipo);
            }
            dr.Close();
            con.Close();
            return lista;
        }
        public Lavado BuscarLavado(int idLavado)
        {
            string consultasql = "select * from Lavados where idLavado = @idLavado";
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            con.Open();
            cmd = new SqlCommand(consultasql, con);
            cmd.Parameters.AddWithValue("@idLavado", idLavado);
            dr = cmd.ExecuteReader();
            dr.Read();
            Lavado lavado = new Lavado();
            lavado.Id = int.Parse(dr["idLavado"].ToString());
            lavado.Patente = dr["patente"].ToString();
            lavado.Taxi = bool.Parse(dr["taxi"].ToString());
            lavado.Habitual = bool.Parse(dr["habitual"].ToString());
            lavado.Idtipo = int.Parse(dr["idTipo"].ToString());
            dr.Close();
            con.Close();
            return lavado;
        }
        public void cargarLavado(Lavado l)
        {
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            try
            {
                String consultasql = " insert into lavados(patente, taxi, habitual, idTipo) values(@patente, @taxi, @habitual, @idtipo)";
                con.Open();
                cmd = new SqlCommand(consultasql, con);

                cmd.Parameters.AddWithValue("@patente", l.Patente);
                cmd.Parameters.AddWithValue("@taxi", l.Taxi);
                cmd.Parameters.AddWithValue("@habitual", l.Habitual);
                cmd.Parameters.AddWithValue("@idtipo", l.Idtipo);

                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
        public List<DTOlistado> listadoLavados()
        {
            List<DTOlistado> lista = new List<DTOlistado>();
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            string consultasql = @"select l.patente 'patente', t.nombre'tipo', t.precio'costo', l.idLavado 'idlavado'
                                    from lavados l 
                                    join tipos t on t.idTipo = l.idTipo";
            con.Open();
            cmd = new SqlCommand(consultasql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DTOlistado dto = new DTOlistado();
                dto.nombre = dr["tipo"].ToString();
                dto.patente = dr["patente"].ToString();
                dto.precio = double.Parse(dr["costo"].ToString());
                dto.idlavado = int.Parse(dr["idlavado"].ToString());
                lista.Add(dto);
            }
            dr.Close();
            con.Close();
            
            return lista;
        }
        public void editarLavado(Lavado l)
        {
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            try
            {
                String consultasql = @"update Lavados 
                                    set patente = @patente,
	                                    taxi = @taxi,
	                                    habitual=@habitual,
	                                    idTipo=@idtipo
                                    where idLavado =@idlavado";
                con.Open();
                cmd = new SqlCommand(consultasql, con);

                cmd.Parameters.AddWithValue("@patente", l.Patente);
                cmd.Parameters.AddWithValue("@taxi", l.Taxi);
                cmd.Parameters.AddWithValue("@habitual", l.Habitual);
                cmd.Parameters.AddWithValue("@idtipo", l.Idtipo);
                cmd.Parameters.AddWithValue("@idlavado", l.Id);

                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
        public void eliminarLavado(int idlavado)
        {
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            try
            {
                String consultasql = " delete from lavados where idlavado = @idlavado";
                con.Open();
                cmd = new SqlCommand(consultasql, con);
                cmd.Parameters.AddWithValue("@idlavado", idlavado);
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
        public void cargarTipo(Tipo t)
        {
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            try
            {
                String consultasql = "insert into tipos (nombre, precio) values (@nombre, @precio)";
                con.Open();
                cmd = new SqlCommand(consultasql, con);

                cmd.Parameters.AddWithValue("@nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@precio", t.Precio);

                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
        public List<DTOreporte> reporte()
        {
            List<DTOreporte> lista = new List<DTOreporte>();
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            string consultasql = @"select t.nombre 'servicio', sum( t.precio)'total', count(*)'cantidad'
                                    from lavados l 
                                    join tipos t on t.idTipo = l.idTipo
                                    group by t.idTIpo, t.nombre";
            con.Open();
            cmd = new SqlCommand(consultasql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DTOreporte dto = new DTOreporte();
                dto.servicio = dr["servicio"].ToString();
                dto.ventas = double.Parse(dr["total"].ToString());
                dto.cantidadventastotales = int.Parse(dr["cantidad"].ToString());
                lista.Add(dto);
            }
            dr.Close();
            con.Close();

            return lista;
        }

    }
}