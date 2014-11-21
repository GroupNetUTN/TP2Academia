using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetAll_Planes", SqlConn);
                cmdGetAll.CommandType = CommandType.StoredProcedure;
                SqlDataReader drPlanes = cmdGetAll.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan p = new Plan();
                    p.ID = (int)drPlanes["id_plan"];
                    p.Descripcion = (string)drPlanes["desc_plan"];
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drPlanes["id_especialidad"];
                    esp.Descripcion = (string)drPlanes["desc_especialidad"];
                    p.Especialidad = esp;
                    planes.Add(p);
                }
                drPlanes.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los Planes.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan p = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("GetOne_Planes", SqlConn);
                cmdGetOne.CommandType = CommandType.StoredProcedure;
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdGetOne.ExecuteReader();
                if (drPlanes.Read())
                {
                    p.ID = (int)drPlanes["id_plan"];
                    p.Descripcion = (string)drPlanes["desc_plan"];
                    p.Especialidad.ID = (int)drPlanes["id_especialidad"];
                    p.Especialidad.Descripcion = (string)drPlanes["desc_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Plan.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return p;
        }

        public bool Existe(string desc)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select id_plan from " +
                    "dbo.planes where desc_plan=@desc", SqlConn);
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista este plan", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existe;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete_Planes", SqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Plan.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("Update_Planes", SqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdUpdate.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.Especialidad.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del Plan.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("Insert_Planes", SqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdInsert.Parameters.Add("@esp", SqlDbType.Int).Value = plan.Especialidad.ID;
                plan.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear un nuevo Plan.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
