using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.planes.*, dbo.materias.* " +
                                                      "FROM  dbo.materias INNER JOIN dbo.planes ON dbo.materias.id_plan = dbo.planes.id_plan", SqlConn);
                SqlDataReader drMaterias = cmdGetAll.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    Plan plan = new Plan();
                    plan.ID = (int)drMaterias["id_plan"];
                    plan.Descripcion = (string)drMaterias["desc_plan"];
                    mat.Plan = plan;
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las materias.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT dbo.materias.*, dbo.planes.* " +
                                                      "FROM  dbo.materias INNER JOIN dbo.planes ON dbo.materias.id_plan = dbo.planes.id_plan " + 
                                                      "where id_materia=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdGetOne.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    mat.Plan.Descripcion = (string)drMaterias["desc_plan"];
                }

                drMaterias.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE materias SET desc_materia=@desc, hs_semanales=@hs_sem, hs_totales=@hs_tot, id_plan=@id_plan " +
                    "WHERE id_materia=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar).Value = mat.Descripcion;
                cmdUpdate.Parameters.Add("@hs_sem", SqlDbType.Int).Value = mat.HSSemanales;
                cmdUpdate.Parameters.Add("@hs_tot", SqlDbType.Int).Value = mat.HSTotales;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into materias(desc_materia,hs_semanales,hs_totales,id_plan) values(@desc,@hs_sem,@hs_tot,@id_plan) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar).Value = mat.Descripcion;
                cmdInsert.Parameters.Add("@hs_sem", SqlDbType.Int).Value = mat.HSSemanales;
                cmdInsert.Parameters.Add("@hs_tot", SqlDbType.Int).Value = mat.HSTotales;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.Plan.ID;
                mat.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una nueva materia.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }
    }
}
