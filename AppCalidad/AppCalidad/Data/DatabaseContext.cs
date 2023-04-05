﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppCalidad.Tablas;

namespace AppCalidad.Data
{
    public class DatabaseContext
    {
        private readonly SQLiteAsyncConnection connection;

        public DatabaseContext(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Usuarios>().Wait();
            connection.CreateTableAsync<Proyectos>().Wait();
            connection.CreateTableAsync<ProyectoPeriodo>().Wait();
            connection.CreateTableAsync<ProyectoElemento>().Wait();
        }
        public async Task<List<T>> GetItemsAsync<T>() where T : new()
        {
            return await connection.Table<T>().ToListAsync();
        }

        public async Task<List<T>> FilterItemsAsync<T>(string table, string condition) where T : new()
        {
             return await connection.QueryAsync<T>($"SELECT * FROM {table} WHERE {condition} ");
        }

        public async Task<T> GetItemAsync<T>(string id) where T : new()
        {
            return await connection.FindAsync<T>(id);
        }

        public async Task<int> SaveItemAsync<T>(T item, bool isInsert) where T : new()
        {
            return (isInsert)
                ? await connection.InsertAsync(item)
                : await connection.UpdateAsync(item);
        }

        public async Task<int> DeleteItemAsync<T>(T item) where T : new()
        {
            return await connection.DeleteAsync(item);
        }
    }
}
