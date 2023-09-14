using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Clinica
{
    class Especialidades
    {
        string cadena;
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        private int especialidad;
        private string nombre; 

        public int Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public Especialidades()
        {
            cadena = "provider=microsoft.jet.oledb.4.0;data source=CLINICA.mdb";
            conector = new OleDbConnection(cadena);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Especialidades";

            adaptador = new OleDbDataAdapter(comando);

            tabla = new DataTable();

            adaptador.Fill(tabla); //Sube todos los registros de acces a la memoria

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["especialidad"];
            tabla.PrimaryKey = vec;
        }
        public void Grabar()
        {
            DataRow fila = tabla.NewRow();
            fila["especialidad"] = especialidad;
            fila["nombre"] = nombre;
            tabla.Rows.Add(fila);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador); //traducir el lenguaje c# en lenguaje SQL

            adaptador.Update(tabla); //Sube todos los registros de la memoria al acces
        }
        public void Borrar()
        {
            DataRow fila = tabla.Rows.Find(especialidad);
            if (fila != null)
            {
                fila.Delete();
                OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
                adaptador.Update(tabla);
            }
        }
    }
}
