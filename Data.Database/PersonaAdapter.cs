using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {                
        public List<Persona> GetAll(int tipo)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAlumnos = new SqlCommand();
                cmdGetAlumnos.Connection = SqlConn;
                if (tipo != 0)
                {
                    cmdGetAlumnos.CommandText = "SELECT dbo.personas.*, dbo.planes.* FROM dbo.personas INNER JOIN dbo.planes " + 
                    "ON dbo.personas.id_plan=dbo.planes.id_plan WHERE dbo.personas.tipo_persona=@tipo";
                    cmdGetAlumnos.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                }
                else
                {
                    cmdGetAlumnos.CommandText = "SELECT dbo.personas.*, dbo.planes.* FROM dbo.personas INNER JOIN dbo.planes " + 
                    "ON dbo.personas.id_plan=dbo.planes.id_plan";
                }
                SqlDataReader drPersonas = cmdGetAlumnos.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona pers = new Persona();
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Email = (string)drPersonas["email"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"]) 
                    {
                        case 1:
                            pers.TipoPersona = "No docente";
                            break;
                        case 2:
                            pers.TipoPersona = "Alumno";
                            break;
                        case 3:
                            pers.TipoPersona = "Docente";
                            break;
                    }
                    pers.Plan.ID = (int)drPersonas["id_plan"];
                    pers.Plan.Descripcion = (string)drPersonas["desc_plan"];
                    personas.Add(pers);
                }
                drPersonas.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Personas.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona pers = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from personas where id_persona=@id", SqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdGetOne.ExecuteReader();
                if (drPersonas.Read())
                {
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Email = (string)drPersonas["email"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            pers.TipoPersona = "No docente";
                            break;
                        case 2:
                            pers.TipoPersona = "Alumno";
                            break;
                        case 3:
                            pers.TipoPersona = "Docente";
                            break;
                    }
                    pers.Plan.ID = (int)drPersonas["id_plan"];
                    pers.Plan.Descripcion = (string)drPersonas["desc_plan"];
                }

                drPersonas.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la Persona.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return pers;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona = @id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la Persona.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido, email=@email, direccion=@direc, telefono=@tel, fecha_nac=@fecha, legajo=@legajo, tipo_persona=@tipo_p, id_plan=@idplan WHERE id_persona=@id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                cmdUpdate.Parameters.Add("@direc", SqlDbType.VarChar).Value = persona.Direccion;
                cmdUpdate.Parameters.Add("@tel", SqlDbType.VarChar).Value = persona.Telefono;
                cmdUpdate.Parameters.Add("@fecha", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                switch (persona.TipoPersona)
                {
                    case "No docente":
                        cmdUpdate.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 1;
                        break;
                    case "Alumno":
                        cmdUpdate.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 2;
                        break;
                    case "Docente":
                        cmdUpdate.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 3;
                        break;
                }
                
                cmdUpdate.Parameters.Add("@idplan", SqlDbType.Int).Value = persona.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Persona.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert into personas(nombre,apellido,email,direccion,telefono,fecha_nac,legajo,tipo_persona,id_plan) values(@nombre,@apellido,@email,@direc,@tel,@fecha,@legajo,@tipo_P,@idplan) select @@identity", SqlConn);

                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                cmdInsert.Parameters.Add("@direc", SqlDbType.VarChar).Value = persona.Direccion;
                cmdInsert.Parameters.Add("@tel", SqlDbType.VarChar).Value = persona.Telefono;
                cmdInsert.Parameters.Add("@fecha", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                switch (persona.TipoPersona)
                {
                    case "No docente":
                        cmdInsert.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 1;
                        break;
                    case "Alumno":
                        cmdInsert.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 2;
                        break;
                    case "Docente":
                        cmdInsert.Parameters.Add("@tipo_p", SqlDbType.Int).Value = 3;
                        break;
                }
                cmdInsert.Parameters.Add("@idplan", SqlDbType.Int).Value = persona.Plan.ID;
                persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la Persona.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
