using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.alumnos_inscripciones.*, dbo.personas.*, dbo.materias.*, dbo.comisiones.*, dbo.cursos.* "+
                                                      "FROM dbo.alumnos_inscripciones INNER JOIN dbo.personas ON dbo.alumnos_inscripciones.id_alumno = dbo.personas.id_persona "+ 
                                                                                     "INNER JOIN dbo.cursos ON dbo.alumnos_inscripciones.id_curso = dbo.cursos.id_curso "+ 
                                                                                     "INNER JOIN dbo.materias ON dbo.cursos.id_materia = dbo.materias.id_materia "+ 
                                                                                     "INNER JOIN dbo.comisiones ON dbo.cursos.id_comision = dbo.comisiones.id_comision", SqlConn);
                SqlDataReader drInscripciones = cmdGetAll.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.IDPlan = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    ins.Curso.Comision.Descripcion = (string)drInscripciones["desc_comision"];
                    ins.Curso.Materia.Descripcion = (string)drInscripciones["desc_materia"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de las inscripciones.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT dbo.alumnos_inscripciones.*, dbo.personas.*, dbo.cursos.* " +
                    "FROM dbo.alumnos_inscripciones INNER JOIN dbo.personas ON " +
                    "dbo.alumnos_inscripciones.id_alumno = dbo.personas.id_persona " +
                    "INNER JOIN dbo.cursos ON dbo.alumnos_inscripciones.id_curso = dbo.cursos.id_curso WHERE id_materia=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdGetOne.ExecuteReader();
                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.IDPlan = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    ins.Curso.Comision.Descripcion = (string)drInscripciones["desc_comision"];
                    ins.Curso.Materia.Descripcion = (string)drInscripciones["desc_materia"];
                }

                drInscripciones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la inscripcion.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@id_alumno, id_curso=@id_curso, "
                + "condicion=@condicion, nota=@nota " +
                    "WHERE id_inscripcion=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = ins.ID;
                cmdUpdate.Parameters.Add("@id_alumno", SqlDbType.Int).Value = ins.Alumno.ID;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = ins.Curso.ID;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar).Value = ins.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota) " +
                    "values(@id_alumno,@id_curso,@condicion,@nota) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@id_alumno", SqlDbType.Int).Value = ins.Alumno.ID;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = ins.Curso.ID;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar).Value = ins.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;
                ins.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una nueva inscripcion.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion ins)
        {
            if (ins.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ins.ID);
            }
            else if (ins.State == BusinessEntity.States.New)
            {
                this.Insert(ins);
            }
            else if (ins.State == BusinessEntity.States.Modified)
            {
                this.Update(ins);
            }
            ins.State = BusinessEntity.States.Unmodified;
        }

    }
}
