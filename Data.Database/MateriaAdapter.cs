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
                SqlCommand cmdGetAll = new SqlCommand("GetAll_Materias", SqlConn);
                cmdGetAll.CommandType = CommandType.StoredProcedure;
                SqlDataReader drMaterias = cmdGetAll.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    mat.Plan.Descripcion = (string)drMaterias["desc_plan"];
                    mat.Plan.Especialidad.ID = (int)drMaterias["id_especialidad"];
                    mat.Plan.Especialidad.Descripcion = (string)drMaterias["desc_especialidad"];
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
                SqlCommand cmdGetOne = new SqlCommand("GetOne_Materias", SqlConn);
                cmdGetOne.CommandType = CommandType.StoredProcedure;
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
                    mat.Plan.Especialidad.ID = (int)drMaterias["id_especialidad"];
                    mat.Plan.Especialidad.Descripcion = (string)drMaterias["desc_especialidad"]; ;
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

        public bool Existe(int id_plan, string desc)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("Existe_Materias", SqlConn);
                cmdGetOne.CommandType = CommandType.StoredProcedure;
                cmdGetOne.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdGetOne.Parameters.Add("@id_plan", SqlDbType.Int).Value = id_plan;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al validar que no exista esta Materia", e);
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
                SqlCommand cmdDelete = new SqlCommand("Delete_Materias", SqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
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
                SqlCommand cmdUpdate = new SqlCommand("Update_Materias", SqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;

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
                SqlCommand cmdInsert = new SqlCommand("Insert_Materias", SqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;

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

        public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetMateriasParaInscripcion = new SqlCommand("GetMateriasParaInscripcion", SqlConn);
                cmdGetMateriasParaInscripcion.CommandType = CommandType.StoredProcedure;
                cmdGetMateriasParaInscripcion.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                cmdGetMateriasParaInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drMaterias = cmdGetMateriasParaInscripcion.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    materias.Add(mat);
                }
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias disponibles para el alumno.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }
    }
}