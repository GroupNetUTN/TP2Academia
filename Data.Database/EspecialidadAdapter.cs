using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetAll_Especialidades", SqlConn);
                cmdGetAll.CommandType = CommandType.StoredProcedure;
                SqlDataReader drEspecialidades = cmdGetAll.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    
                    especialidades.Add(esp);
                }
                drEspecialidades.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las especialidades", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("GetOne_Especialidades", SqlConn);
                cmdGetOne.CommandType = CommandType.StoredProcedure;
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidad = cmdGetOne.ExecuteReader();
                if (drEspecialidad.Read())
                {
                    esp.ID = (int)drEspecialidad["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidad["desc_especialidad"];
                }
                drEspecialidad.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete_Especialidades", SqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("Update_Especialidades", SqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar).Value = especialidad.Descripcion;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("Insert_Especialidades", SqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }   

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State== BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
