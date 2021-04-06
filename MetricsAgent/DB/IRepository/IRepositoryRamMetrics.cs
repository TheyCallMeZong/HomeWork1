﻿
using MetricsAgent.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DB.IRepository
{
    public interface IRepositoryRamMetrics 
        : IRepository<RamMetrics>
    {
    }
    public class RamMetricsRepository : IRepositoryRamMetrics
    {
        private SQLiteConnection _connection;
        public RamMetricsRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Create(RamMetrics item)
        {
            using var command = new SQLiteCommand(_connection);
            command.CommandText = @"INSERT INTO rammetrics (value) VALUES (@value)";

            command.Parameters.AddWithValue("@value", item.Value);

            command.Prepare();
            command.ExecuteNonQuery();
        }

        public RamMetrics GetById(int id)
        {
            using var cmd = new SQLiteCommand(_connection);
            cmd.CommandText = "SELECT * FROM rammetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new RamMetrics
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(0)
                    };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
