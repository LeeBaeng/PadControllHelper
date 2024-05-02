using System.Data.SQLite;

namespace PadControllHelper {
    public class SQLitePCH : SQLite{
        public const string TB_VAR = "var";
        public const string VAR_Id = "id";
        public const string VAR_NAME = "name";
        public const string VAR_VALUE = "value";

        public const string TB_MACRO = "macro";
        public const string MACRO_Id = "id";
        public const string MACRO_TITLE = "title";
        public const string MACRO_POINTX = "px";
        public const string MACRO_POINTY = "py";
        public const string MACRO_ACTION = "action";
        public const string MACRO_SHORTCUT = "shortCut";
        public const string MACRO_SWITCH = "switch";
        public const string MACRO_SWCONDITION = "sw_condition";
        public const string MACRO_POWER = "power";
        public const string MACRO_SWITCHTO = "switchTo";
        public const string MACRO_VALUETO = "valueTo";



        public SQLitePCH() : base(){
            try {
                SQLiteConnection conn = new SQLiteConnection(dataSource);
                using(var command = new SQLiteCommand(conn)) {
                    conn.Open();
                    command.CommandText = getTableCreationCommand(true, true, TB_VAR, new KeyValuePair<string, string>[]
                            {
                        tableElement(VAR_NAME,"nvarchar(50)"),
                        tableElement(VAR_VALUE,"nvarchar(10)") // 추후 boolean외 값을 저장할 예정
                            });
                    printCmd(command.CommandText);
                    command.ExecuteNonQuery();

                    //command.CommandText = "DROP TABLE " + TB_MACRO;
                    //printCmd(command.CommandText);
                    //command.ExecuteNonQuery();

                    command.CommandText = getTableCreationCommand(true, true, TB_MACRO, new KeyValuePair<string, string>[]
                            {
                        tableElement(MACRO_TITLE,"nvarchar(50)"),
                        tableElement(MACRO_POINTX,"INTEGER"),
                        tableElement(MACRO_POINTY,"INTEGER"),
                        tableElement(MACRO_ACTION,"INTEGER"), // action의 이름(click 등)
                        tableElement(MACRO_SHORTCUT,"INTEGER"), // keyCode
                        tableElement(MACRO_SWITCH,"INTEGER"), // switchId
                        tableElement(MACRO_SWCONDITION,"INTEGER"),
                        tableElement(MACRO_POWER,"nvarchar(6)"),
                            });
                    printCmd(command.CommandText);
                    command.ExecuteNonQuery();

                    //command.CommandText = "ALTER TABLE " + TB_MACRO + " ADD COLUMN " + MACRO_SWITCHTO + " INTEGER";
                    //command.ExecuteNonQuery();
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
