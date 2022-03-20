using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppReclama.Models;
using System.Threading.Tasks;

namespace AppReclama.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _db;


        public SQLiteDataBaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Reclamacao>().Wait();
        }


        public Task<List<Reclamacao>> GetAllRows()
        {
            return _db.Table<Reclamacao>().OrderByDescending(i => i.Id).ToListAsync();
        }



        public Task<Reclamacao> GetById(int id)
        {
            return _db.Table<Reclamacao>().FirstAsync(i => i.Id == id);
        }


        public Task<int> Insert(Reclamacao model)
        {
            return _db.InsertAsync(model);
        }


        public Task<List<Reclamacao>> Update(Reclamacao model)
        {
            string sql = "UPDATE Atividade SET Descricao=?, Endereco=?, Imagem=?, WHERE Id=?";

            return _db.QueryAsync<Reclamacao>(
                sql,
                model.Descricao,
                model.Endereco,
                model.Imagem,
                model.Id
            );
        }

        public Task<int> Delete(int id)
        {
            return _db.Table<Reclamacao>().DeleteAsync(i => i.Id == id);
        }


        public Task<List<Reclamacao>> Search(string q)
        {
            string sql = "SELECT * FROM Reclamacao WHERE Descricao LIKE '%" + q + "%'";

            return _db.QueryAsync<Reclamacao>(sql);
        }
    }
}
