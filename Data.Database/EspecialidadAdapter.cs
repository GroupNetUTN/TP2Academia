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
          #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Especialidad> _Especialidades;

        private static List<Especialidad> Especialidades
        {
            get
            {
                if (_Especialidades == null)
                {
                    _Especialidades = new List<Especialidad>();
                    Especialidad esp = new Especialidad();;
                    esp.Descripcion = "Matematicas";
                    _Especialidades.Add(esp);

                    esp = new Especialidad();;
                    esp.Descripcion = "Historia";
                    _Especialidades.Add(esp);

                    esp = new Especialidad();;
                    esp.Descripcion = "Geografia";
                    _Especialidades.Add(esp);

                    esp = new Especialidad();;
                    esp.Descripcion = "Biologia";
                     _Especialidades.Add(esp);

                }
                return _Especialidades;   
            }
        }
        #endregion

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("select * from especialidades", SqlConn);
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
                SqlCommand cmdGetOne = new SqlCommand("select * from especialidades where id_especialidad=@id", SqlConn);
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
                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad = @id", SqlConn);
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
                SqlCommand cmdUpdate = new SqlCommand("UPDATE especialidades SET desc_especialidad=@desc " +
                    "WHERE id_especialidad=@id", SqlConn);

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
                SqlCommand cmdInsert = new SqlCommand("insert into especialidades(desc_especialidad)" +
                    "values(@desc) " +
                    "select @@identity", SqlConn);

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
