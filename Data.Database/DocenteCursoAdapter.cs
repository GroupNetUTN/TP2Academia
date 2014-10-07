using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT dbo.docentes_cursos.*, dbo.personas.* " +
                                                      "FROM dbo.docentes_cursos INNER JOIN dbo.personas ON dbo.docentes_cursos.id_docente = dbo.personas.id_persona", SqlConn);
                SqlDataReader drDocentes = cmdGetAll.ExecuteReader();
                while (drDocentes.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocentes["id_dictado"];
                    switch ((int)drDocentes["cargo"])
                    {
                        case 1:
                            dc.Cargo = "Titular";
                            break;
                        case 2:
                            dc.Cargo = "Auxiliar";
                            break;
                        case 3:
                            dc.Cargo = "Ayudante";
                            break;
                    }
                    dc.IDCurso = (int)drDocentes["id_curso"];
                    dc.Docente.ID = (int)drDocentes["id_persona"];
                    dc.Docente.Nombre = (string)drDocentes["nombre"];
                    dc.Docente.Apellido = (string)drDocentes["apellido"];
                    dc.Docente.Email = (string)drDocentes["email"];
                    dc.Docente.Direccion = (string)drDocentes["direccion"];
                    dc.Docente.Telefono = (string)drDocentes["telefono"];
                    dc.Docente.FechaNacimiento = (DateTime)drDocentes["fecha_nac"];
                    dc.Docente.Legajo = (int)drDocentes["legajo"];
                    switch ((int)drDocentes["tipo_persona"])
                    {
                        case 1:
                            dc.Docente.TipoPersona = "No docente";
                            break;
                        case 2:
                            dc.Docente.TipoPersona = "Alumno";
                            break;
                        case 3:
                            dc.Docente.TipoPersona = "Docente";
                            break;
                    }
                    dc.Docente.IDPlan = (int)drDocentes["id_plan"];
                    docentes.Add(dc);
                }
                drDocentes.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los docentes.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentes;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT dbo.docentes_cursos.*, dbo.personas.* " +
                                                      "FROM dbo.docentes_cursos INNER JOIN dbo.personas ON dbo.docentes_cursos.id_docente = dbo.personas.id_persona " + 
                                                      "WHERE id_dictado=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentes = cmdGetOne.ExecuteReader();
                if (drDocentes.Read())
                {
                    dc.ID = (int)drDocentes["id_dictado"];
                    switch ((int)drDocentes["cargo"])
                    {
                        case 1:
                            dc.Cargo = "Titular";
                            break;
                        case 2:
                            dc.Cargo = "Auxiliar";
                            break;
                        case 3:
                            dc.Cargo = "Ayudante";
                            break;
                    }
                    dc.IDCurso = (int)drDocentes["id_curso"];
                    dc.Docente.ID = (int)drDocentes["id_persona"];
                    dc.Docente.Nombre = (string)drDocentes["nombre"];
                    dc.Docente.Apellido = (string)drDocentes["apellido"];
                    dc.Docente.Email = (string)drDocentes["email"];
                    dc.Docente.Direccion = (string)drDocentes["direccion"];
                    dc.Docente.Telefono = (string)drDocentes["telefono"];
                    dc.Docente.FechaNacimiento = (DateTime)drDocentes["fecha_nac"];
                    dc.Docente.Legajo = (int)drDocentes["legajo"];
                    switch ((int)drDocentes["tipo_persona"])
                    {
                        case 1:
                            dc.Docente.TipoPersona = "No docente";
                            break;
                        case 2:
                            dc.Docente.TipoPersona = "Alumno";
                            break;
                        case 3:
                            dc.Docente.TipoPersona = "Docente";
                            break;
                    }
                    dc.Docente.IDPlan = (int)drDocentes["id_plan"];
                }

                drDocentes.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del Docente.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el Docente.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE docentes_cursos SET id_docente=@id_docente, id_curso=@id_curso, cargo=@cargo " +
                                                      "WHERE id_dictado=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdUpdate.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                cmdUpdate.Parameters.Add("@cargo", SqlDbType.VarChar).Value = dc.Cargo;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into docentes_cursos(id_docente, id_curso, cargo) " +
                                                      "values(@id_docente, @id_curso, @cargo) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = dc.Docente.ID;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = dc.IDCurso;
                switch (dc.Cargo)
                {
                    case "Titular":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                dc.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear un nuevo dictado.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }
}
