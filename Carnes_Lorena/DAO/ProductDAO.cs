﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Entities;
using System.Data;

namespace DAO
{
    public class ProductDAO
    {
        public bool RegisterProduct(Product p)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.product(
                                      code, named, notes)
                                VALUES(:c, :n, :ns) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("c", p.Code);
                    cmd.Parameters.AddWithValue("n", p.Named);
                    cmd.Parameters.AddWithValue("ns", p.Notes);

                    p.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    con.Close();
                    return p.Id > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataSet GetAllProducts()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daProducts = new NpgsqlDataAdapter("SELECT * FROM public.product;", con);
                    DataSet ds = new DataSet();
                    daProducts.Fill(ds, "products");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable GetByCode(string code)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT * FROM public.product
                                    WHERE code = '" + code + "'";

                    var da = new NpgsqlDataAdapter(sql, con);
                    ds.Reset();

                    da.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public DataTable GetByName(string name)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT * FROM public.product
                                    WHERE named = '" + name + "'";

                    var da = new NpgsqlDataAdapter(sql, con);
                    ds.Reset();

                    da.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public DataTable Get_Products_Code()
        {
            var ds = new DataSet();
            var dt = new DataTable();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT code FROM public.product";
                    var da = new NpgsqlDataAdapter(sql, con);
                    ds.Reset();

                    da.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public DataTable Get_Products_Name()
        {
            var ds = new DataSet();
            var dt = new DataTable();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT named FROM public.product";
                    var da = new NpgsqlDataAdapter(sql, con);
                    ds.Reset();

                    da.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string Get_Product_Name(string code)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT named,id
                                   FROM public.product
                                   WHERE code = :c";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("c", code);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(0) + "%" + reader.GetInt16(1);
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Get_Code_By_Name(string name)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    string sql = @"SELECT code, id
                                   FROM public.product
                                   WHERE named = :n";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("n", name);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader.GetString(0) + "%" + reader.GetInt16(1);
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
