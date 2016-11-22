using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01.Repositorio
{
    public class RepositorioMarca
    {
        const string KConnString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\denis.baldo\Source\Repos\CursoCS\Exemplos\Database\lavaDB.mdf;Integrated Security=True;Connect Timeout=30";

        public void InserirMarca(Marca nova)
        {
            //Conectar no banco
            using (var conn = new SqlConnection(KConnString))
            {
                conn.Open();

                var cmd = new SqlCommand("INSERT INTO TB_MARCA VALUES (@nome) \n SELECT CAST(SCOPE_IDENTITY() AS INT)", conn);
                cmd.Parameters.AddWithValue("@nome", nova.Nome);

                nova.Id = (int)cmd.ExecuteScalar();

                conn.Close();
            }
        }

        public IEnumerable<Marca> ConsultarMarcas()
        {
            var list = new List<Marca>();

            //Conectar no banco
            using (var conn = new SqlConnection(KConnString))
            {
                conn.Open();

                var cmd = new SqlCommand("SELECT ID_MARCA, NM_MARCA FROM TB_MARCA", conn);
                using(var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        list.Add(new Marca() { Id = dr.GetInt32(0), Nome = dr.GetString(1) });
                    }
                }
            }

            return list;
        }

        public DataSet ConsultarMarcaDataSet()
        {
            var ds =  new DataSet();

            //Conectar no banco
            using (var conn = new SqlConnection(KConnString))
            {
                conn.Open();

                var cmdSelect = new SqlCommand("SELECT * FROM TB_MARCA", conn);
                var sqlAdapter = new SqlDataAdapter(cmdSelect);

                sqlAdapter.Fill(ds);

            }

            return ds;

        }
    }
}
