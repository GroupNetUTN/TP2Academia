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
                SqlCommand cmdGetAll = new SqlCommand("GetAll_AlumnosInscripciones", SqlConn);
                cmdGetAll.CommandType = CommandType.StoredProcedure;
                SqlDataReader drInscripciones = cmdGetAll.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
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
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
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

        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("GetAllPorAlumno_AlumnosInscripciones", SqlConn);
                cmdGetAll.Parameters.Add("@id_pers", SqlDbType.Int).Value = IDAlumno;
                cmdGetAll.CommandType = CommandType.StoredProcedure;
                SqlDataReader drInscripciones = cmdGetAll.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
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
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
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
                SqlCommand cmdGetOne = new SqlCommand("GetOne_AlumnosInscripciones", SqlConn);
                cmdGetOne.CommandType = CommandType.StoredProcedure;
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
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
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
                SqlCommand cmdDelete = new SqlCommand("Delete_AlumnosInscripciones", SqlConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
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
                SqlCommand cmdUpdate = new SqlCommand("Update_AlumnosInscripciones", SqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;

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
                SqlCommand cmdInsert = new SqlCommand("Insert_AlumnosInscripciones", SqlConn);
                cmdInsert.CommandType = CommandType.StoredProcedure;

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
