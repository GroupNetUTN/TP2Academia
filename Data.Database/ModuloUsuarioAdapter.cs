using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.modulos_usuarios.*, dbo.modulos.* FROM dbo.modulos_usuarios INNER JOIN dbo.modulos ON dbo.modulos_usuarios.id_modulo = dbo.modulos.id_modulo", SqlConn);
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    modusu.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                    modusu.Modulo.Descripcion = (string)drModulosUsuarios["desc_modulo"];
                    modusu.Modulo.Ejecuta = (string)drModulosUsuarios["ejecuta"];
                    modulosusuarios.Add(modusu);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los permisos.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosusuarios;
        }

        protected void Update(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE dbo.modulos_usuarios SET id_modulo=@idmodulo, id_usuario=@idusuario, alta=@alta, baja=@baja, modificacion=@modif, consulta=@cons WHERE id_modulo_usuario=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modusu.ID;
                cmdUpdate.Parameters.Add("@idmodulo", SqlDbType.Int).Value = modusu.Modulo.ID;
                cmdUpdate.Parameters.Add("@idusuario", SqlDbType.Int).Value = modusu.IdUsuario;
                cmdUpdate.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdUpdate.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdUpdate.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdUpdate.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Comision.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into dbo.modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion,consulta) " +
                                                         "values(@idmodulo,@idusuario,@alta,@baja,@modif,@cons) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@idmodulo", SqlDbType.Int).Value = 2;
                cmdInsert.Parameters.Add("@idusuario", SqlDbType.Int).Value = 8;
                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdInsert.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdInsert.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
                //cmdInsert.ExecuteNonQuery();
                modusu.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una permiso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modusu)
        {
            if (modusu.State == BusinessEntity.States.New)
            {
                this.Insert(modusu);
            }
            else if (modusu.State == BusinessEntity.States.Modified)
            {
                this.Update(modusu);
            }
            modusu.State = BusinessEntity.States.Unmodified;
        }
    }
}
