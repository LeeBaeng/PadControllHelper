using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PadControllHelper {
    public partial class FrmDebugDB : Form {
        SQLitePCH sqLite;
        string? currentTableName = null;
        DataSet? currentDataSet = null;
        DataTable? currentDataTable = null;

        public FrmDebugDB(SQLitePCH sqLite) {
            InitializeComponent();
            this.sqLite = sqLite;

            if(sqLite != null) {
                SQLiteConnection conn = new SQLiteConnection(sqLite.dataSource);
                conn.Open();
                DataTable dt = conn.GetSchema("Tables");
                foreach(DataRow row in dt.Rows) {
                    string tableName = (string)row[2];
                    comboBox1.Items.Add(tableName);
                }
                conn.Close();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e) {
            if(sender != null && sender is ComboBox && ((ComboBox)sender).SelectedItem != null) {
                currentTableName = ((ComboBox)sender).SelectedItem.ToString();
                var ds = sqLite.SelectDetail(currentTableName, "*");
                currentDataSet = ds;
                currentDataTable = currentDataSet.Tables[0];
                dataGridView1.DataSource = currentDataTable;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Delete && currentTableName != null) {
                if(MessageBox.Show("진짜 지울겨?", "확인용", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    try {
                        if(dataGridView1.SelectedRows.Count > 0) {
                            sqLite.DeleteDetail(currentTableName, SQLitePCH.VAR_Id, (int)(long)currentDataTable.Rows[dataGridView1.SelectedRows[0].Index][SQLitePCH.VAR_Id]);
                            //int selectedIndex = dataGridView1.SelectedRows[0].Index;
                            //int rowID = int.Parse(dataGridView1[0, selectedIndex].Value.ToString());
                            //SQLiteConnection dbConnection = new SQLiteConnection(sqLite.dataSource);
                            //dbConnection.Open();
                            //SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + currentTableName + " WHERE id='" + rowID + "'", dbConnection);
                            //cmd.ExecuteNonQuery();
                            //dbConnection.Close();
                        }
                    } catch(Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if(currentTableName != null && currentDataTable != null) {
                Debug.WriteLine("*1 : " + currentDataTable.Rows[e.RowIndex][e.ColumnIndex]);
                Debug.WriteLine("*2 : " + currentDataTable.Columns[e.ColumnIndex].ColumnName);

                string setCmd = currentDataTable.Columns[e.ColumnIndex].ColumnName + " = '" + currentDataTable.Rows[e.RowIndex][e.ColumnIndex] + "'";
                string whereCmd = "id = " + currentDataTable.Rows[e.RowIndex][SQLitePCH.VAR_Id];
                Debug.WriteLine("*3 : " + setCmd);
                Debug.WriteLine("*4 : " + whereCmd);
                sqLite.Update(currentTableName, setCmd, whereCmd);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
        }
    }
}
