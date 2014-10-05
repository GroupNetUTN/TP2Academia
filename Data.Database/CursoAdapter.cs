﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.cursos.*, dbo.materias.*, dbo.comisiones.* FROM dbo.cursos " + 
                "INNER JOIN dbo.materias ON dbo.cursos.id_materia = dbo.materias.id_materia INNER JOIN dbo.comisiones " + 
                "ON dbo.cursos.id_comision = dbo.comisiones.id_comision", SqlConn);
                SqlDataReader drCursos = cmdGetAll.ExecuteReader();
                while(drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia.ID = (int)drCursos["id_materia"];
                    cur.Materia.Descripcion = (string)drCursos["desc_materia"];
                    cur.Materia.HSSemanales = (int)drCursos["hs_semanales"];
                    cur.Materia.HSTotales = (int)drCursos["hs_totales"];
                    cur.Materia.Plan.ID = (int)drCursos["id_plan"];
                    cur.Comision.ID = (int)drCursos["id_comision"];
                    cur.Comision.Descripcion = (string)drCursos["desc_comision"];
                    cur.Comision.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.Comision.Plan.ID = (int)drCursos["id_plan"];
                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch(Exception e)
            {   
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Cursos.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
               
            return cursos;  
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT dbo.cursos.*, dbo.materias.*, dbo.comisiones.* FROM dbo.cursos " +
                "INNER JOIN dbo.materias ON dbo.cursos.id_materia = dbo.materias.id_materia INNER JOIN dbo.comisiones " +
                "ON dbo.cursos.id_comision = dbo.comisiones.id_comision WHERE id_curso=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdGetOne.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Materia.ID = (int)drCursos["id_materia"];
                    cur.Materia.Descripcion = (string)drCursos["desc_materia"];
                    cur.Materia.HSSemanales = (int)drCursos["hs_semanales"];
                    cur.Materia.HSTotales = (int)drCursos["hs_totales"];
                    cur.Materia.Plan.ID = (int)drCursos["id_plan"];
                    cur.Comision.ID = (int)drCursos["id_comision"];
                    cur.Comision.Descripcion = (string)drCursos["desc_comision"];
                    cur.Comision.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    cur.Comision.Plan.ID = (int)drCursos["id_plan"];
                }
                drCursos.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Curso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Curso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }  
        }

        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE cursos SET id_comision=@id_com, id_materia=@id_mat, anio_calendario=@anio, " +
                    "cupo=@cupo WHERE id_curso=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdUpdate.Parameters.Add("@id_com", SqlDbType.Int).Value = curso.Comision.ID;
                cmdUpdate.Parameters.Add("@id_mat", SqlDbType.Int).Value = curso.Materia.ID;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del Curso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT into cursos(id_materia,id_comision,anio_calendario,cupo) values(@id_mat,@id_com,@anio,@cupo) select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@id_mat", SqlDbType.Int).Value = curso.Materia.ID;
                cmdInsert.Parameters.Add("@id_com", SqlDbType.Int).Value = curso.Comision.ID;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el Curso.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

    }
}
