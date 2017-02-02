﻿using System;
using Npgsql;
using Entities;
using System.Data;

namespace DAO
{
    public class OrdersDAO
    {
        public bool RegisterOrder(Orders o)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.orders(
                                      id_client, id_product, quantity, notes)
                                VALUES(:ic, :ip, :q, :n) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("ic", o.Id_Client);
                    cmd.Parameters.AddWithValue("ip", o.Id_Product);
                    cmd.Parameters.AddWithValue("q", o.Quantity);
                    cmd.Parameters.AddWithValue("n", o.Notes);

                    o.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Close();
                    return o.Id > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataSet GetAllOrders()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daOrders = new NpgsqlDataAdapter("SELECT * FROM public.orders;", con);
                    DataSet ds = new DataSet();
                    daOrders.Fill(ds, "orders");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Orders ShowOrder(int id)
        {
            Orders result = new Orders();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT * FROM public.orders WHERE id = :id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("id", id);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Id_Client = reader.GetInt32(1);
                        result.Id_Product = reader.GetString(2);
                        result.Quantity = double.Parse(reader.GetString(3));
                        result.Notes = reader.GetString(4);
                        // result.State = reader.GetBoolean(5);
                        result.State = false;
                    }
                    con.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateOrder(Orders o)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"UPDATE public.orders SET
                                      id_client = :ic, id_product = :ip, quantity = :q, notes = :n
                                   WHERE id = :id";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("id", o.Id);
                    cmd.Parameters.AddWithValue("ic", o.Id_Client);
                    cmd.Parameters.AddWithValue("ip", o.Id_Product);
                    cmd.Parameters.AddWithValue("q", o.Quantity);
                    cmd.Parameters.AddWithValue("n", o.Notes);

                    o.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Close();
                    return o.Id > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
