using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("select * from comisiones", SqlConn);
                SqlDataReader drComisiones = cmdGetAll.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision comi = new Comision();
                    comi.ID = (int)drComisiones["id_comision"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.IDPlan = (int)drComisiones["id_plan"];
                  
                    comisiones.Add(comi);
                }
                drComisiones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las Comisiones.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision comi = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from comisiones where id_comision=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdGetOne.ExecuteReader();
                if (drComisiones.Read())
                {
                    comi.ID = (int)drComisiones["id_comision"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.IDPlan = (int)drComisiones["id_plan"];
                }

                drComisiones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la Comision.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comi;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la Comision.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE comisiones SET desc_comision=@desc, anio_especialidad=@anios, id_plan=@plan WHERE id_usuario=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar).Value = comision.Descripcion;
                cmdUpdate.Parameters.Add("@anios", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdUpdate.Parameters.Add("@plan", SqlDbType.Int).Value = comision.IDPlan;
                
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

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into comisiones(desc_comision, anio_especialidad, id_plan) values(@desc, @anios, @plan) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@anios", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdInsert.Parameters.Add("@plan", SqlDbType.Int).Value = comision.IDPlan;
                
                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una Comision.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
