using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace PadControllHelper {
    public class SQLite {
        static string DB_PATH = Application.StartupPath + @"\database.db";
        public string dataSource { get; set; } = $@"Data Source={DB_PATH}";
        SQLiteDataAdapter adpt;

        public SQLite() { }

        protected KeyValuePair<string, string> tableElement(string name, string typenetc) {
            return new KeyValuePair<string, string>(name, typenetc);
        }

        protected string getTableCreationCommand(bool onlyNotExist, bool columnId, string name, KeyValuePair<string, string>[] elements) {
            string ifnotexists = "IF NOT EXISTS", id = "'id' INTEGER PRIMARY KEY AUTOINCREMENT";
            string table = $"CREATE TABLE {(onlyNotExist ? ifnotexists : "")} '{name}'({id}";

            for(int i = 0; i < elements.Length; i++)
                table += $", '{elements[i].Key}' {elements[i].Value}";

            table += ");";
            return table;
        }

        public DataSet SelectAll(string table) {
            try {
                return SelectDetail(table, "*");
                //DataSet ds = new DataSet();

                //string sql = $"SELECT * FROM {table}";
                //printCmd(sql);
                //adpt = new SQLiteDataAdapter(sql, dataSource);
                //adpt.Fill(ds, table);

                //if(ds.Tables.Count > 0)
                //    return ds;
                //else
                //    return null;
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public DataSet SelectDetail(string table, string condition, string where = "") {
            try {
                DataSet ds = new DataSet();

                string sql = $"SELECT {condition} FROM {table} {where}";
                printCmd(sql);
                adpt = new SQLiteDataAdapter(sql, dataSource);
                adpt.Fill(ds, table);

                if(ds.Tables.Count > 0)
                    return ds;
                else
                    return null;
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void Insert(string table, string value) {
            try {
                using(SQLiteConnection conn = new SQLiteConnection(dataSource)) {
                    conn.Open();
                    string sql = $"INSERT INTO {table} VALUES ({value})";
                    printCmd(sql);
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void Update(string table, string setvalue, string wherevalue = "") {
            try {
                using(SQLiteConnection conn = new SQLiteConnection(dataSource)) {
                    conn.Open();
                    string sql = $"UPDATE {table} SET {setvalue} WHERE {wherevalue}";
                    printCmd(sql);
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void DeleteAll(string table) {
            try {
                using(SQLiteConnection conn = new SQLiteConnection(dataSource)) {
                    conn.Open();
                    string sql = $"DELETE FROM {table}";
                    printCmd(sql);
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void DeleteDetail(string table, string wherecol, string wherevalue) {
            try {
                using(SQLiteConnection conn = new SQLiteConnection(dataSource)) {
                    conn.Open();
                    string sql = $"DELETE FROM {table} WHERE {wherecol}='{wherevalue}'";
                    printCmd(sql);
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public void DeleteDetail(string table, string wherecol, int wherevalue) {
            try {
                using(SQLiteConnection conn = new SQLiteConnection(dataSource)) {
                    conn.Open();
                    string sql = $"DELETE FROM {table} WHERE {wherecol}={wherevalue}";
                    printCmd(sql);
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            } catch(Exception e) {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        protected void printCmd(string sql) {
            Debug.WriteLine("=== SQLite >>> cmd : " + sql);
        }
    }


}
