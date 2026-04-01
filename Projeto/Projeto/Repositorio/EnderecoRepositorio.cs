using MySql.Data.MySqlClient;
using Projeto.Models;
using Projeto.Repositorio.Contrato;
using System.Data;

namespace Projeto.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly string _conexaoMySQL;
        public EnderecoRepositorio(IConfiguration conf)
        {
            //Ingeção de dependencia do banco
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Endereco endereco)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update tbEndereco set (CEP=@CEP, Estado=@Estado, Cidade=@Cidade, Bairro=@Bairro, " +
                    "Logradouro=@Logradouro, Complemento=@Complemento, Numero=@Numero;", conexao);

                cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = endereco.CEP;
                cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = endereco.Estado;
                cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = endereco.Cidade;
                cmd.Parameters.Add("@Bairro", MySqlDbType.VarChar).Value = endereco.Bairro;
                cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = endereco.Logradouro;
                cmd.Parameters.Add("@Complemento", MySqlDbType.VarChar).Value = endereco.Complemento;
                cmd.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = endereco.Numero;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Endereco endereco)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into tbEndereco(CEP, Estado, Cidade, Bairro, Logradouro, Complemento, Numero)" +
                        "values (@CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero)", conexao);

                    cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = endereco.CEP;
                    cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = endereco.Estado;
                    cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = endereco.Cidade;
                    cmd.Parameters.Add("@Bairro", MySqlDbType.VarChar).Value = endereco.Bairro;
                    cmd.Parameters.Add("@Logradouro", MySqlDbType.VarChar).Value = endereco.Logradouro;
                    cmd.Parameters.Add("@Complemento", MySqlDbType.VarChar).Value = endereco.Complemento;
                    cmd.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = endereco.Numero;

                    cmd.ExecuteNonQuery();
                    conexao.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco em cadastro cliente" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação em cadastro cliente" + ex.Message);
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from tbEndereco where Id=@Id", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Endereco ObterEndereco(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterTodosEnderecos()
        {
            List<Endereco> endList = new List<Endereco>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbEndereco", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    endList.Add(
                        new Endereco
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            CEP = Convert.ToString(dr["CEP"]),
                            Estado = Convert.ToString(dr["Estado"]),
                            Cidade = Convert.ToString(dr["Cidade"]),
                            Bairro = Convert.ToString(dr["Bairro"]),
                            Logradouro = Convert.ToString(dr["Logradouro"]),
                            Complemento = Convert.ToString(dr["Complemento"]),
                            Numero = Convert.ToString(dr["Numero"])
                        });
                }
                return endList;
            }
        }
    }
}
