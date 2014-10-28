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
        public List<ModuloUsuario> GetAll(int idUsuario)
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.modulos.id_modulo, dbo.modulos.desc_modulo, " + 
                "dbo.modulos_usuarios.id_modulo_usuario, dbo.modulos_usuarios.alta, dbo.modulos_usuarios.baja, dbo.modulos_usuarios.modificacion, " + 
                "dbo.modulos_usuarios.consulta, dbo.modulos_usuarios.id_usuario FROM dbo.modulos_usuarios RIGHT OUTER JOIN " +
                "dbo.modulos ON dbo.modulos_usuarios.id_modulo = dbo.modulos.id_modulo AND dbo.modulos_usuarios.id_usuario=@id", SqlConn);
                cmdGetAll.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdGetAll.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = drModulosUsuarios.IsDBNull(2)? modusu.ID=0 : (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = drModulosUsuarios.IsDBNull(7)? modusu.IdUsuario = idUsuario : (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = drModulosUsuarios.IsDBNull(3)? modusu.PermiteAlta=false : (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = drModulosUsuarios.IsDBNull(4)? modusu.PermiteBaja = false : (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = drModulosUsuarios.IsDBNull(5)? modusu.PermiteModificacion=false : (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = drModulosUsuarios.IsDBNull(6)? modusu.PermiteConsulta = false : (bool)drModulosUsuarios["consulta"];
                    modusu.Modulo.ID = (int)drModulosUsuarios["id_modulo"];
                    modusu.Modulo.Descripcion = (string)drModulosUsuarios["desc_modulo"];
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

                cmdInsert.Parameters.Add("@idmodulo", SqlDbType.Int).Value = modusu.Modulo.ID;
                cmdInsert.Parameters.Add("@idusuario", SqlDbType.Int).Value = modusu.IdUsuario;
                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdInsert.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdInsert.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
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
