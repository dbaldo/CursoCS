using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_ADONet.Repositorio
{
    class RepositorioOperador
    {
        const string KConnString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\denis.baldo\Source\Repos\CursoCS\Exemplos\Database\lavaDB.mdf;Integrated Security=True;Connect Timeout=30";

        public void InserirOperador(Operador novo)
        {
            //Conectar no banco
            using (var conn = new SqlConnection(KConnString))
            {
                conn.Open();

                var cmd = new SqlCommand("INSERT INTO TB_OPERADOR VALUES (@nome, @login) \n SELECT CAST(SCOPE_IDENTITY() AS INT)", conn);
                cmd.Parameters.AddWithValue("@nome", novo.Nome);
                cmd.Parameters.AddWithValue("@login", novo.Login);

                novo.Id = (int)cmd.ExecuteScalar();

                conn.Close();
            }
        }

        public void AlterarOperador(Operador novo)
        {
            //Conectar no banco
            using (var conn = new SqlConnection(KConnString))
            {
                conn.Open();

                var cmd = new SqlCommand("UPDATE TB_OPERADOR SET NM_OPERADOR = @nome,  NM_LOGIN = @login WHERE ID_OPERADOR = @id", conn);
                cmd.Parameters.AddWithValue("@nome", novo.Nome);
                cmd.Parameters.AddWithValue("@login", novo.Login);
                cmd.Parameters.AddWithValue("@id", novo.Id);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public IEnumerable<Operador> ConsultarOperadores()
        {
            var list = new List<Operador>();

            //Conectar no banco
            using (var conn = new SqlConnection(KConnString))
            {
                conn.Open();

                var cmd = new SqlCommand("SELECT ID_OPERADOR, NM_OPERADOR, NM_LOGIN FROM TB_OPERADOR", conn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Operador() { Id = dr.GetInt32(0), Nome = dr.GetString(1), Login = dr.GetString(2) });
                    }
                }
            }

            return list;
        }


    }
}
