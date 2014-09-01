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
                SqlCommand cmdGetAll = new SqlCommand("select * from planes", SqlConn);
                SqlDataReader drPlanes = cmdGetAll.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan p = new Plan();
                    p.ID = (int)drPlanes["id_plan"];
                    p.Descripcion = (string)drPlanes["desc_plan"];
                    p.IDEspecialidad = (int)drPlanes["id_especialidad"];

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
                SqlCommand cmdGetOne = new SqlCommand("select * from planes where id_plan=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdGetOne.ExecuteReader();
                if (drPlanes.Read())
                {
                    p.ID = (int)drPlanes["id_plan"];
                    p.Descripcion = (string)drPlanes["desc_plan"];
                    p.IDEspecialidad = (int)drPlanes["id_especialidad"];
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

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan = @id", SqlConn);
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
                SqlCommand cmdUpdate = new SqlCommand("UPDATE planes SET desc_plan=@desc, id_especialidad=@id_esp " +
                    "WHERE id_plan=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdUpdate.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;
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
                SqlCommand cmdInsert = new SqlCommand("insert into planes(desc_plan,id_especialidad) values(@desc,@esp) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdInsert.Parameters.Add("@esp", SqlDbType.Int).Value = plan.IDEspecialidad;
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
