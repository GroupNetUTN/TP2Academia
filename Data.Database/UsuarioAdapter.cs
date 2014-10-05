﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.usuarios.*, dbo.personas.* FROM dbo.personas " + 
                    "INNER JOIN dbo.usuarios ON dbo.personas.id_persona = dbo.usuarios.id_persona", SqlConn);
                SqlDataReader drUsuarios = cmdGetAll.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                    usr.Persona.IDPlan = (int)drUsuarios["id_plan"];
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
                    usr.Persona.Direccion = (string)drUsuarios["direccion"];
                    usr.Persona.Telefono = (string)drUsuarios["telefono"];
                    usr.Persona.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    usr.Persona.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            usr.Persona.TipoPersona = "No docente";
                            break;
                        case 2:
                            usr.Persona.TipoPersona = "Alumno";
                            break;
                        case 3:
                            usr.Persona.TipoPersona = "Docente";
                            break;
                    }
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT dbo.usuarios.*, dbo.personas.* FROM dbo.personas " +
                    "INNER JOIN dbo.usuarios ON dbo.personas.id_persona = dbo.usuarios.id_persona WHERE id_usuario=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdGetOne.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Persona.ID = (int)drUsuarios["id_persona"];
                    usr.Persona.IDPlan = (int)drUsuarios["id_plan"];
                    usr.Persona.Nombre = (string)drUsuarios["nombre"];
                    usr.Persona.Apellido = (string)drUsuarios["apellido"];
                    usr.Persona.Email = (string)drUsuarios["email"];
                    usr.Persona.Direccion = (string)drUsuarios["direccion"];
                    usr.Persona.Telefono = (string)drUsuarios["telefono"];
                    usr.Persona.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    usr.Persona.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
                    {
                        case 1:
                            usr.Persona.TipoPersona = "No docente";
                            break;
                        case 2:
                            usr.Persona.TipoPersona = "Alumno";
                            break;
                        case 3:
                            usr.Persona.TipoPersona = "Docente";
                            break;
                    }
                }

                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, " +
                    "habilitado=@habilitado, id_persona=@id_persona " +
                    "WHERE id_usuario=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdUpdate.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdUpdate.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdUpdate.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdUpdate.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into usuarios(nombre_usuario,clave,habilitado,id_persona)" +
                    "values(@nombre_usuario,@clave,@habilitado,@id_persona) " +
                    "select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.Persona.ID;
                usuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }   

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}