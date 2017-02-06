﻿using System;
using Npgsql;
using Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class SeveralsDAO
    {
        public bool RegisterSeveral(Severals sv)
        {
            Customers c = new Customers();
            c.Named = sv.Named;
            sv.Id_Global = Register(c);
            if (sv.Id_Global > 0)
            {
                NpgsqlTransaction tran = null;
                try
                {
                    using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        string sql = @"INSERT INTO public.schools(
                                      named, tel1, tel2, id_global)
                                VALUES(:n, :t1, :t2, :ig) returning id";

                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("n", sv.Named);
                        cmd.Parameters.AddWithValue("t1", sv.Phone1);
                        cmd.Parameters.AddWithValue("t2", sv.Phone2);
                        cmd.Parameters.AddWithValue("ig", sv.Id_Global);

                        sv.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        tran.Commit();
                        con.Close();
                        return sv.Id > 0;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return false;
        }

        public int Register(Customers c)
        {
            NpgsqlTransaction tran = null;
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    string sql = @"INSERT INTO public.customers(
                                    named, type)
                                 VALUES (:n, :t) returning id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("n", c.Named);
                    cmd.Parameters.AddWithValue("t", 3);
                    c.Id = Convert.ToInt32(cmd.ExecuteScalar());

                    tran.Commit();
                    con.Close();
                    return c.Id;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public DataSet GetAllSeverals()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlDataAdapter daSeverals = new NpgsqlDataAdapter("SELECT * FROM public.severals;", con);
                    DataSet ds = new DataSet();
                    daSeverals.Fill(ds, "severals");
                    con.Close();
                    return ds;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
                    string sql = @"SELECT * FROM public.severals
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
    }
}
